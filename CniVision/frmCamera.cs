using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace CniVision
{
    public partial class frmCamera : Form
    {
        private SynchronizationContext sync = SynchronizationContext.Current;       // 폼 Context
        public CniCamera[] Cameras { get; set; } = null;                            // 현재 변경 가능한 카메라 배열
        private int iSelectedIndex = -1;                                            // 현재 선택된 목록 인덱스

        public frmCamera()
        {
            Icon = Properties.Resources.Logo;

            InitializeComponent();
        }

        #region 폼 관련 이벤트

        // 폼 로드시 카메라 목록에 현재 선언된 카메라 삽입
        private void frmCamera_Load(object sender, EventArgs e)
        {
            if (Cameras != null)
            {
                foreach (CniCamera cam in Cameras)
                {
                    cbCameraIndex.Items.Add("Camera" + cam.Number);
                }

                cbCameraIndex.SelectedIndex = 0;
            }
            else
            {
                txbExposure.Enabled = false;
                txbGain.Enabled = false;
                btnExposureApply.Enabled = false;
                btnGainApply.Enabled = false;
                btnLive.Enabled = false;
                cbCameraIndex.Enabled = false;
            }
        }

        // 목록 변경시 변경된 카메라의 노출 및 게인 값 가져오기
        private void cbCameraIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            iSelectedIndex = cbCameraIndex.SelectedIndex;

            sync.Post(delegate
            {
                if (cRecordDisplay.LiveDisplayRunning)
                {
                    btnLive.BackColor = SystemColors.Control;
                    cRecordDisplay.StopLiveDisplay();
                }

                txbExposure.Text = ((int)Cameras[iSelectedIndex].GetExposure()).ToString();
                txbGain.Text = ((int)Cameras[iSelectedIndex].GetGain()).ToString();
            }, null);


        }

        // 라이브 버튼 클릭시
        private void btnLive_Click(object sender, EventArgs e)
        {
            if (!cRecordDisplay.LiveDisplayRunning)
            {
                btnLive.BackColor = SystemColors.ActiveCaption;
                cRecordDisplay.StartLiveDisplay(Cameras[iSelectedIndex].Camera);
                cRecordDisplay.Fit(false);
            }
            else
            {
                btnLive.BackColor = SystemColors.Control;
                cRecordDisplay.StopLiveDisplay();
            }
        }

        // 노출 값 적용 버튼 클릭시
        private void btnExposureApply_Click(object sender, EventArgs e)
        {
            Cameras[iSelectedIndex].SetExposure(double.Parse(txbExposure.Text));
        }

        // 게인 값 적용 버튼 클릭시
        private void btnGainApply_Click(object sender, EventArgs e)
        {
            Cameras[iSelectedIndex].SetGain(double.Parse(txbGain.Text));

        }

        // 노출 값에 숫자만 입력
        private void txbExposure_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        // 게인 값에 숫자만 입력
        private void txbGain_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}
