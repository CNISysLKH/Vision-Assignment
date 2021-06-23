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

using Cognex.VisionPro;
using Cognex.VisionPro.ImageProcessing;

namespace CniVision
{
    public partial class frmMerge : Form
    {
        private SynchronizationContext syncContext = SynchronizationContext.Current;
        private CniCamera[] cams = null;                                                    // 연결된 카메라
        private CniMerge mergeTool = null;                                                  // 병합 도구 
        private ICogImage[] images = null;                                                  // 촬영된 이미지들
        private ICogImage mergeImage = null;                                                // 병합된 이미지

        // 기본 생성자
        public frmMerge(CniCamera[] cams, CniMerge mergeTool, ICogImage[] images, ICogImage mergeImage)
        {
            this.cams = cams;
            this.mergeTool = mergeTool;
            this.images = images;
            this.mergeImage = mergeImage;
            InitializeComponent();
            InitializeForm();
        }

        // 폼 초기화 
        private void InitializeForm()
        {
            Icon = Properties.Resources.Logo;                                   // 로고 삽입
            rdbCount1.Checked = true;                                           // 기본은 출력 화면 1개

            if (cams != null && cams.Length > 0)                                // 연결된 카메라의 개수에 따라 콤보박스에 텍스트 추가
            {
                syncContext.Post(delegate
                {
                    for (int i = 0; i < cams.Length; ++i)
                    {
                        cbxShowCameraNumber.Items.Add($"카메라 {i + 1}");
                    }

                    cbxShowCameraNumber.SelectedIndex = 0;
                }, null);

            }

            if (images != null && images.Length > 0)                            // 한번이라도 촬영 되었을 경우 화면에 출력 
            {                                                                   // 화면 총 3개로 이미지의 개수에 따라 각 화면에 출력 기본적으로 1번 카메라 부터 출력

                for (int i = 0; i < images.Length; ++i)
                {
                    switch (i)
                    {
                        case 0:
                            cRecDisp1.Image = images[i];
                            cRecDisp1.Fit(false);
                            cRecDisp1.InteractiveGraphics.Add(((mergeTool.cMergeRegions.Tools[i] as CogIPOneImageTool).Region as CogRectangleAffine), "", false);
                            break;
                        case 1:
                            cRecDisp2.Image = images[i];
                            cRecDisp3.Fit(false);
                            cRecDisp2.InteractiveGraphics.Add(((mergeTool.cMergeRegions.Tools[i] as CogIPOneImageTool).Region as CogRectangleAffine), "", false);
                            break;
                        case 2:
                            cRecDisp3.Image = images[i];
                            cRecDisp3.Fit(false);
                            cRecDisp3.InteractiveGraphics.Add(((mergeTool.cMergeRegions.Tools[i] as CogIPOneImageTool).Region as CogRectangleAffine), "", false);
                            break;
                    }
                }

            }

            if (mergeImage != null)                                                                 // 병합된 이미지가 있을 경우 화면에 출력
            {
                syncContext.Post(delegate
                {
                    cMergeRecDisp.Image = mergeImage;
                    cMergeRecDisp.Fit(true);
                }, null);
            }

        }
        // 화면 1개 표시
        #region 폼 관련 이벤트
        private void rdbCount1_CheckedChanged(object sender, EventArgs e)                          // 기본적으로 실행, 화면 출력 1개 일 경우 화면을 가득 채움
        {
            // Cam 1만 표시
            if (rdbCount1.Checked)
            {
                pnlCam1.Visible = true;
                pnlCam2.Visible = false;
                pnlCam3.Visible = false;
            }

            // 디스플레이 사이즈 변경
            pnlCam1.Dock = DockStyle.Fill;

            syncContext.Post(delegate
            {
                this.Invalidate();
            }, null);
        }
        // 화면 2개 표시
        private void rdbCount2_CheckedChanged(object sender, EventArgs e)                           // 화면 2개 출력시 사이즈 변경
        {
            // Cam 1,2 표시
            if (rdbCount2.Checked)
            {
                pnlCam1.Visible = true;
                pnlCam2.Visible = true;
                pnlCam3.Visible = false;
            }
            // 디스플레이 사이즈 변경
            pnlCam2.Size = new Size(pnlCams.Size.Width / 2, pnlCams.Size.Height);
            pnlCam1.Size = new Size(pnlCams.Size.Width / 2, pnlCams.Size.Height);

            pnlCam2.Location = new Point(pnlCams.Size.Width / 2, 0);
            pnlCam1.Location = new Point(0, 0);

            pnlCam2.Dock = DockStyle.None;
            pnlCam1.Dock = DockStyle.None;
            syncContext.Post(delegate
            {
                this.Invalidate();
            }, null);
        }

        // 화면 3개 표시
        private void rdbCount3_CheckedChanged(object sender, EventArgs e)
        {
            // Cam 모듀 표시
            if (rdbCount3.Checked)
            {
                pnlCam1.Visible = true;
                pnlCam2.Visible = true;
                pnlCam3.Visible = true;
            }

            // 디스플레이 사이즈 변경
            pnlCam3.Size = new Size(pnlCams.Size.Width / 3, pnlCams.Size.Height);
            pnlCam2.Size = new Size(pnlCams.Size.Width / 3, pnlCams.Size.Height);
            pnlCam1.Size = new Size(pnlCams.Size.Width / 3, pnlCams.Size.Height);

            pnlCam3.Location = new Point((pnlCams.Size.Width / 3) * 2, 0);
            pnlCam2.Location = new Point(pnlCams.Size.Width / 3, 0);
            pnlCam1.Location = new Point(0, 0);

            pnlCam3.Dock = DockStyle.None;
            pnlCam2.Dock = DockStyle.None;
            pnlCam1.Dock = DockStyle.None;

            syncContext.Post(delegate
            {
                this.Invalidate();
            }, null);
        }

        // 화면에 보여줄 카메라 순서 변경시 활성화 함수
        private void cbxShowCameraNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            syncContext.Post(delegate
            {
                cRecDisp1.Image = null;
                cRecDisp2.Image = null;
                cRecDisp3.Image = null;

                cRecDisp1.InteractiveGraphics.Clear();
                cRecDisp2.InteractiveGraphics.Clear();
                cRecDisp3.InteractiveGraphics.Clear();

                cRecDisp1.ClearImage8GreyColorMap();
                cRecDisp2.ClearImage8GreyColorMap();
                cRecDisp3.ClearImage8GreyColorMap();

                for (int i = cbxShowCameraNumber.SelectedIndex; i < cams.Length; ++i)
                {
                    switch (i - cbxShowCameraNumber.SelectedIndex)
                    {
                        case 0:
                            cRecDisp1.Image = images[i];
                            cRecDisp1.Fit(false);
                            cRecDisp1.InteractiveGraphics.Add(((mergeTool.cMergeRegions.Tools[i] as CogIPOneImageTool).Region as CogRectangleAffine), "", false);
                            break;
                        case 1:
                            cRecDisp2.Image = images[i];
                            cRecDisp2.Fit(false);
                            cRecDisp2.InteractiveGraphics.Add(((mergeTool.cMergeRegions.Tools[i] as CogIPOneImageTool).Region as CogRectangleAffine), "", false);
                            break;
                        case 2:
                            cRecDisp3.Image = images[i];
                            cRecDisp3.Fit(false);
                            cRecDisp3.InteractiveGraphics.Add(((mergeTool.cMergeRegions.Tools[i] as CogIPOneImageTool).Region as CogRectangleAffine), "", false);
                            break;
                    }
                }


            }, null);


        }

        // 이미지 촬영 버튼
        private void btnGrabImage_Click(object sender, EventArgs e)
        {
            if (cams != null && cams.Length > 0)
            {
                foreach (CniCamera cam in cams)
                {
                    cam.Grab();
                }
            }
        }

        private void btnSaveRegion_Click(object sender, EventArgs e)
        {
            mergeTool.SaveMergeRegion();
        }

        // 촬영한 이미지 가져오는 함수
        public void SetMergeImage(ICogImage[] arrImg)
        {
            images = arrImg;

            // 이미지 자름
            List<ICogImage> clipImages = mergeTool.ImageClipConvert(images.ToList());

            List<Bitmap> bitmapList = mergeTool.ICogImageToBitmapConvert(clipImages);

            Bitmap bImage = mergeTool.Merge(bitmapList);

            CogImage8Grey cImage8Grey = new CogImage8Grey(bImage);  // Bitmap에서 cogimage로 변환

            syncContext.Post(delegate
            {
                cMergeRecDisp.Image = cImage8Grey;
                cMergeRecDisp.Fit(false);

                for (int i = cbxShowCameraNumber.SelectedIndex; i < cams.Length; ++i)
                {
                    switch (i - cbxShowCameraNumber.SelectedIndex)
                    {
                        case 0:
                            cRecDisp1.Image = images[i];
                            cRecDisp1.Fit(false);
                            break;
                        case 1:
                            cRecDisp2.Image = images[i];
                            cRecDisp2.Fit(false);
                            break;
                        case 2:
                            cRecDisp3.Image = images[i];
                            cRecDisp3.Fit(false);
                            break;
                    }
                }


            }, null);
        }
        // 폼 크기 변할 때마다 카메라 디스플레이 크기 변경
        private void pnlCams_Resize(object sender, EventArgs e)
        {
            if (rdbCount2.Checked)
            {
                syncContext.Post(delegate
                {
                    pnlCam2.Size = new Size(pnlCams.Size.Width / 2, pnlCams.Size.Height);
                    pnlCam1.Size = new Size(pnlCams.Size.Width / 2, pnlCams.Size.Height);

                    pnlCam2.Location = new Point(pnlCams.Size.Width / 2, 0);
                    pnlCam1.Location = new Point(0, 0);


                }, null);
            }
            else if (rdbCount3.Checked)
            {
                syncContext.Post(delegate
                {
                    pnlCam3.Size = new Size(pnlCams.Size.Width / 3, pnlCams.Size.Height);
                    pnlCam2.Size = new Size(pnlCams.Size.Width / 3, pnlCams.Size.Height);
                    pnlCam1.Size = new Size(pnlCams.Size.Width / 3, pnlCams.Size.Height);

                    pnlCam3.Location = new Point((pnlCams.Size.Width / 3) * 2, 0);
                    pnlCam2.Location = new Point(pnlCams.Size.Width / 3, 0);
                    pnlCam1.Location = new Point(0, 0);

                }, null);
            }
            this.Invalidate();
        }
        #endregion

    }
}
