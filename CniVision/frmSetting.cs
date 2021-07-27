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
using System.Text.Json;
using System.Text.Json.Serialization;

using CniVision.IO;

namespace CniVision
{


    public partial class frmSetting : Form
    {
        /// <summary>
        /// Form을 불러올 때 사용 할 Sync Context
        /// </summary>
        private static SynchronizationContext syncContext = SynchronizationContext.Current;

        /// <summary>
        ///  생성자
        /// </summary>
        /// <param name="control"></param>
        public frmSetting(CniIOControl control)
        {
            Icon = Properties.Resources.Logo;
            IOControl = control;

            InitializeComponent();
            InitializeControls();
        }


        /// <summary>
        /// 프로그램 IO 클래스
        /// </summary>
        private CniIOControl IOControl = null;


        /// <summary>
        /// 설정 화면 컨트롤 초기화
        /// </summary>
        private void InitializeControls()
        {
            // 시스템 설정 초기화


            // Input 신호 설정 초기화


            // Output 신호 설정 초기화


        }





        private void InitializeInputSignalConfiguration()
        {

            for (int i = 0; i < CniIOControl.ISArray.Length; ++i)
            {

                if (CniIOControl.ISArray[i].TriggerEnable)
                {
                    ((CheckBox)tlpInputSignalConfiguration.GetControlFromPosition(i + 1, 2)).Checked = true;
                }
                else
                {
                    ((CheckBox)tlpInputSignalConfiguration.GetControlFromPosition(i + 1, 2)).Checked = false;

                }

                if (CniIOControl.ISArray[i].Polarity)
                {
                    ((CheckBox)tlpInputSignalConfiguration.GetControlFromPosition(i + 1, 4)).Checked = true;
                    ((CheckBox)tlpInputSignalConfiguration.GetControlFromPosition(i + 1, 5)).Checked = false;
                }
                else
                {
                    ((CheckBox)tlpInputSignalConfiguration.GetControlFromPosition(i + 1, 4)).Checked = false;
                    ((CheckBox)tlpInputSignalConfiguration.GetControlFromPosition(i + 1, 5)).Checked = true;
                }

                ((NumericUpDown)tlpInputSignalConfiguration.GetControlFromPosition(i + 1, 6)).Value = CniIOControl.ISArray[i].DebounceTime;

            }
        }

        private void InitializeOutputSignalConfiguration()
        {
            for (int i = 0; i < CniIOControl.OSArray.Length; ++i)
            {

                if (CniIOControl.OSArray[i].ReadEnable)
                {
                    ((CheckBox)tlpInputSignalConfiguration.GetControlFromPosition(i + 1, 2)).Checked = true;
                }
                else
                {
                    ((CheckBox)tlpInputSignalConfiguration.GetControlFromPosition(i + 1, 2)).Checked = false;

                }

                if (CniIOControl.OSArray[i].NoReadEnable)
                {
                    ((CheckBox)tlpInputSignalConfiguration.GetControlFromPosition(i + 1, 3)).Checked = true;
                }
                else
                {
                    ((CheckBox)tlpInputSignalConfiguration.GetControlFromPosition(i + 1, 3)).Checked = false;

                }

                if (CniIOControl.OSArray[i].Action)
                {
                    ((CheckBox)tlpInputSignalConfiguration.GetControlFromPosition(i + 1, 5)).Checked = true;
                    ((CheckBox)tlpInputSignalConfiguration.GetControlFromPosition(i + 1, 6)).Checked = false;
                }
                else
                {
                    ((CheckBox)tlpInputSignalConfiguration.GetControlFromPosition(i + 1, 5)).Checked = false;
                    ((CheckBox)tlpInputSignalConfiguration.GetControlFromPosition(i + 1, 6)).Checked = true;
                }

              ((NumericUpDown)tlpInputSignalConfiguration.GetControlFromPosition(i + 1, 7)).Value = CniIOControl.OSArray[i].PulseWidth;

            }
        }

        private void SaveInputSignalConfigValues()
        {
            for (int i = 0; i < CniIOControl.ISArray.Length; ++i)
            {

                CniIOControl.ISArray[i].TriggerEnable = ((CheckBox)tlpInputSignalConfiguration.GetControlFromPosition(i + 1, 2)).Checked;

                if (((CheckBox)tlpInputSignalConfiguration.GetControlFromPosition(i + 1, 4)).Checked)
                {
                    CniIOControl.ISArray[i].Polarity = true;
                }
                else
                {
                    CniIOControl.ISArray[i].Polarity = false;
                }

                CniIOControl.ISArray[i].DebounceTime = decimal.ToInt32(((NumericUpDown)tlpInputSignalConfiguration.GetControlFromPosition(i + 1, 6)).Value);
            }
        }

        private void SaveOutputSignalConfigValues()
        {
            for (int i = 0; i < CniIOControl.OSArray.Length; ++i)
            {

                CniIOControl.OSArray[i].ReadEnable = ((CheckBox)tlpInputSignalConfiguration.GetControlFromPosition(i + 1, 2)).Checked;
                CniIOControl.OSArray[i].NoReadEnable = ((CheckBox)tlpInputSignalConfiguration.GetControlFromPosition(i + 1, 3)).Checked;

                if (((CheckBox)tlpInputSignalConfiguration.GetControlFromPosition(i + 1, 5)).Checked)
                {
                    CniIOControl.OSArray[i].Action = true;
                }
                else
                {
                    CniIOControl.OSArray[i].Action = false;
                }

                CniIOControl.OSArray[i].PulseWidth = decimal.ToInt32(((NumericUpDown)tlpInputSignalConfiguration.GetControlFromPosition(i + 1, 7)).Value);
            }
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



    }
}
