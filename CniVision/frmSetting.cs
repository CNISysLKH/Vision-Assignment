using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CniVision
{
    public partial class frmSetting : Form
    {
        // Setting Form의 Sync Context
        private static SynchronizationContext syncContext = SynchronizationContext.Current;

        private CniIOControl ioControl = null;

        public frmSetting(CniIOControl ioControl)
        {
            Icon = Properties.Resources.Logo;
            this.ioControl = ioControl;

            InitializeComponent();

            gbxIOBoradSignalSetting.Enabled = ioControl.ConnectionStatus;       // IO 보드가 연결 되었을 경우에만 활성화

            // Signal 콤보박스 초기화
            for (int i = 0; i < 16; ++i)
            {
                cmbInputSignal.Items.Add($"Input Signal {i}");
                cmbOutputSignal.Items.Add($"Output Signal {i}");
                cmbInputPolarity.Items.Add($"Input {i}");
                cmbOutputAction.Items.Add($"Ouput {i}");
            }

            cmbInputSignal.SelectedIndex = 0;
            cmbOutputSignal.SelectedIndex = 0;
            cmbInputPolarity.SelectedIndex = 0;
            cmbOutputAction.SelectedIndex = 0;

        }

        #region 폼 관련 이벤트
        // 폼 불러올 때 설정 값 불러온 후 화면에 띄움
        private void frmSetting_Load(object sender, EventArgs e)
        {
            syncContext.Post(delegate
            {
                lblSaveImageDirectory.Text = CniIniArguments.SaveImageDirectory;
                lblSaveDataDirectory.Text = CniIniArguments.SaveDataDirectory;
                ckbSaveOriginImage.Checked = CniIniArguments.IsSaveOriginImage;
                ckbSaveResultImage.Checked = CniIniArguments.IsSaveResultImage;
                ckbSaveCSV.Checked = CniIniArguments.IsSaveCSV;
                ckbSaveTXT.Checked = CniIniArguments.IsSaveTXT;
            }, null);

        }

        // 이미지 저장위치 변경
        private void btnSaveImageDirectoryDialog_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                DialogResult dr = fbd.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    syncContext.Post(delegate
                    {
                        lblSaveImageDirectory.Text = fbd.SelectedPath;
                    }, null);

                    CniIniArguments.SaveImageDirectory = fbd.SelectedPath;

                }

            }

        }
        // 결과 데이터 저장위치 변경
        private void btnSaveDataDirectoryDialog_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                DialogResult dr = fbd.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    syncContext.Post(delegate
                    {
                        lblSaveDataDirectory.Text = fbd.SelectedPath;
                    }, null);

                    CniIniArguments.SaveDataDirectory = fbd.SelectedPath;
                }

            }
        }
        // 원본 이미지 저장 활성화
        private void ckbSaveOriginImage_CheckedChanged(object sender, EventArgs e)
        {
            CniIniArguments.IsSaveOriginImage = ckbSaveOriginImage.Checked;
        }
        // 결과 이미지 저장 활성화
        private void ckbSaveResultImage_CheckedChanged(object sender, EventArgs e)
        {
            CniIniArguments.IsSaveResultImage = ckbSaveResultImage.Checked;

        }
        // CSV 형식 결과 데이터 활성화
        private void ckbSaveCSV_CheckedChanged(object sender, EventArgs e)
        {
            CniIniArguments.IsSaveCSV = ckbSaveCSV.Checked;

        }
        // TXT 형식 결과 데이터 활성화
        private void ckbSaveTXT_CheckedChanged(object sender, EventArgs e)
        {
            CniIniArguments.IsSaveTXT = ckbSaveTXT.Checked;

        }
        #endregion

        #region I/O 연결 선택

        // Output 순번을 바꿀 Input 설정
        private void cmbInputSignal_SelectedIndexChanged(object sender, EventArgs e)
        {
            int inSignalIndex = cmbInputSignal.SelectedIndex;

            //int outSignalNum = ioControl.GetInputToOutputSignal(inSignalIndex);

            //if (outSignalNum != -1)
            //{
            //    cmbOutputSignal.SelectedIndex = outSignalNum;
            //}
            //else
            //{
            //    cmbOutputSignal.SelectedIndex = 0;
            //}

        }
        // Input 순번의 출력 Output 설정
        //private void cmbOutputSignal_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int outSignalIndex = cmbOutputSignal.SelectedIndex;

        //ioControl.SetInputToOutputSignal(cmbInputSignal.SelectedIndex, outSignalIndex);

        //}
        // Input 극성 콤보박스 목록 변경시
        private void cmbInputPolarity_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = cmbInputPolarity.SelectedIndex;

            bool state = ioControl.GetPolarity(idx);

            if (state)
            {
                rdbInputRisingEdge.Checked = true;
            }
            else
            {
                rdbInputFallingEdge.Checked = true;
            }
        }
        // Input 극성 상승 설정
        private void rdbInputRisingEdge_CheckedChanged(object sender, EventArgs e)
        {
            int idx = cmbInputPolarity.SelectedIndex;

            if (rdbInputRisingEdge.Checked)
            {
                ioControl.SetPolarity(idx, true);
            }
        }
        // Input 극성 하강 설정
        private void rdbInputFallingEdge_CheckedChanged(object sender, EventArgs e)
        {
            int idx = cmbInputPolarity.SelectedIndex;

            if (rdbInputFallingEdge.Checked)
            {
                ioControl.SetPolarity(idx, false);
            }
        }
        // Output 작업 콤보박스 목록 변경 시
        private void cmbOutputAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = cmbOutputAction.SelectedIndex;

            bool state = ioControl.GetOutputAction(idx);

            if (state)
            {
                rdbOutputOpen.Checked = true;
            }
            else
            {
                rdbOutputClose.Checked = true;
            }
        }
        // Output 열기 활성화
        private void rdbOutputOpen_CheckedChanged(object sender, EventArgs e)
        {
            int idx = cmbOutputAction.SelectedIndex;

            if (rdbOutputOpen.Checked)
            {
                ioControl.OutputOpen(idx);
            }
        }
        // Output 닫기 활성화
        private void rdbOutputClose_CheckedChanged(object sender, EventArgs e)
        {
            int idx = cmbOutputAction.SelectedIndex;

            if (rdbOutputClose.Checked)
            {
                ioControl.OutputClose(idx);
            }
        }

        #endregion
    }



}
