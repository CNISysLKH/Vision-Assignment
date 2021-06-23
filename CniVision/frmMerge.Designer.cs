namespace CniVision
{
    partial class frmMerge
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMerge));
            this.pnlCams = new System.Windows.Forms.Panel();
            this.pnlCam3 = new System.Windows.Forms.Panel();
            this.cRecDisp3 = new Cognex.VisionPro.CogRecordDisplay();
            this.lblCam3 = new System.Windows.Forms.Label();
            this.pnlCam2 = new System.Windows.Forms.Panel();
            this.cRecDisp2 = new Cognex.VisionPro.CogRecordDisplay();
            this.lblCam2 = new System.Windows.Forms.Label();
            this.pnlCam1 = new System.Windows.Forms.Panel();
            this.cRecDisp1 = new Cognex.VisionPro.CogRecordDisplay();
            this.lblCam1 = new System.Windows.Forms.Label();
            this.pnlCamCrtl = new System.Windows.Forms.Panel();
            this.btnSaveRegion = new System.Windows.Forms.Button();
            this.gbShowCameraNum = new System.Windows.Forms.GroupBox();
            this.cbxShowCameraNumber = new System.Windows.Forms.ComboBox();
            this.gbShowDispCount = new System.Windows.Forms.GroupBox();
            this.rdbCount3 = new System.Windows.Forms.RadioButton();
            this.rdbCount2 = new System.Windows.Forms.RadioButton();
            this.rdbCount1 = new System.Windows.Forms.RadioButton();
            this.btnGrabImage = new System.Windows.Forms.Button();
            this.lblMergeImageTitle = new System.Windows.Forms.Label();
            this.cMergeRecDisp = new Cognex.VisionPro.CogRecordDisplay();
            this.cCamRecDisp3 = new Cognex.VisionPro.CogRecordDisplay();
            this.cCamRecDisp2 = new Cognex.VisionPro.CogRecordDisplay();
            this.pnlCams.SuspendLayout();
            this.pnlCam3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cRecDisp3)).BeginInit();
            this.pnlCam2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cRecDisp2)).BeginInit();
            this.pnlCam1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cRecDisp1)).BeginInit();
            this.pnlCamCrtl.SuspendLayout();
            this.gbShowCameraNum.SuspendLayout();
            this.gbShowDispCount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cMergeRecDisp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cCamRecDisp3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cCamRecDisp2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCams
            // 
            this.pnlCams.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlCams.Controls.Add(this.pnlCam3);
            this.pnlCams.Controls.Add(this.pnlCam2);
            this.pnlCams.Controls.Add(this.pnlCam1);
            this.pnlCams.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCams.Location = new System.Drawing.Point(0, 0);
            this.pnlCams.Name = "pnlCams";
            this.pnlCams.Size = new System.Drawing.Size(661, 259);
            this.pnlCams.TabIndex = 4;
            this.pnlCams.Resize += new System.EventHandler(this.pnlCams_Resize);
            // 
            // pnlCam3
            // 
            this.pnlCam3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCam3.Controls.Add(this.cRecDisp3);
            this.pnlCam3.Controls.Add(this.lblCam3);
            this.pnlCam3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCam3.Location = new System.Drawing.Point(439, 0);
            this.pnlCam3.Name = "pnlCam3";
            this.pnlCam3.Size = new System.Drawing.Size(218, 255);
            this.pnlCam3.TabIndex = 2;
            // 
            // cRecDisp3
            // 
            this.cRecDisp3.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cRecDisp3.ColorMapLowerRoiLimit = 0D;
            this.cRecDisp3.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cRecDisp3.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cRecDisp3.ColorMapUpperRoiLimit = 1D;
            this.cRecDisp3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRecDisp3.DoubleTapZoomCycleLength = 2;
            this.cRecDisp3.DoubleTapZoomSensitivity = 2.5D;
            this.cRecDisp3.Location = new System.Drawing.Point(0, 49);
            this.cRecDisp3.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cRecDisp3.MouseWheelSensitivity = 1D;
            this.cRecDisp3.Name = "cRecDisp3";
            this.cRecDisp3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cRecDisp3.OcxState")));
            this.cRecDisp3.Size = new System.Drawing.Size(216, 204);
            this.cRecDisp3.TabIndex = 2;
            // 
            // lblCam3
            // 
            this.lblCam3.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCam3.Font = new System.Drawing.Font("Gulim", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCam3.Location = new System.Drawing.Point(0, 0);
            this.lblCam3.Name = "lblCam3";
            this.lblCam3.Size = new System.Drawing.Size(216, 49);
            this.lblCam3.TabIndex = 1;
            this.lblCam3.Text = "영역 설정 화면 3";
            this.lblCam3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCam2
            // 
            this.pnlCam2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCam2.Controls.Add(this.cRecDisp2);
            this.pnlCam2.Controls.Add(this.lblCam2);
            this.pnlCam2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlCam2.Location = new System.Drawing.Point(212, 0);
            this.pnlCam2.Name = "pnlCam2";
            this.pnlCam2.Size = new System.Drawing.Size(227, 255);
            this.pnlCam2.TabIndex = 1;
            // 
            // cRecDisp2
            // 
            this.cRecDisp2.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cRecDisp2.ColorMapLowerRoiLimit = 0D;
            this.cRecDisp2.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cRecDisp2.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cRecDisp2.ColorMapUpperRoiLimit = 1D;
            this.cRecDisp2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRecDisp2.DoubleTapZoomCycleLength = 2;
            this.cRecDisp2.DoubleTapZoomSensitivity = 2.5D;
            this.cRecDisp2.Location = new System.Drawing.Point(0, 49);
            this.cRecDisp2.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cRecDisp2.MouseWheelSensitivity = 1D;
            this.cRecDisp2.Name = "cRecDisp2";
            this.cRecDisp2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cRecDisp2.OcxState")));
            this.cRecDisp2.Size = new System.Drawing.Size(225, 204);
            this.cRecDisp2.TabIndex = 2;
            // 
            // lblCam2
            // 
            this.lblCam2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCam2.Font = new System.Drawing.Font("Gulim", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCam2.Location = new System.Drawing.Point(0, 0);
            this.lblCam2.Name = "lblCam2";
            this.lblCam2.Size = new System.Drawing.Size(225, 49);
            this.lblCam2.TabIndex = 1;
            this.lblCam2.Text = "영역 설정 화면 2";
            this.lblCam2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCam1
            // 
            this.pnlCam1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCam1.Controls.Add(this.cRecDisp1);
            this.pnlCam1.Controls.Add(this.lblCam1);
            this.pnlCam1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlCam1.Location = new System.Drawing.Point(0, 0);
            this.pnlCam1.Name = "pnlCam1";
            this.pnlCam1.Size = new System.Drawing.Size(212, 255);
            this.pnlCam1.TabIndex = 0;
            // 
            // cRecDisp1
            // 
            this.cRecDisp1.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cRecDisp1.ColorMapLowerRoiLimit = 0D;
            this.cRecDisp1.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cRecDisp1.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cRecDisp1.ColorMapUpperRoiLimit = 1D;
            this.cRecDisp1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRecDisp1.DoubleTapZoomCycleLength = 2;
            this.cRecDisp1.DoubleTapZoomSensitivity = 2.5D;
            this.cRecDisp1.Location = new System.Drawing.Point(0, 49);
            this.cRecDisp1.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cRecDisp1.MouseWheelSensitivity = 1D;
            this.cRecDisp1.Name = "cRecDisp1";
            this.cRecDisp1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cRecDisp1.OcxState")));
            this.cRecDisp1.Size = new System.Drawing.Size(210, 204);
            this.cRecDisp1.TabIndex = 1;
            // 
            // lblCam1
            // 
            this.lblCam1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCam1.Font = new System.Drawing.Font("Gulim", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCam1.Location = new System.Drawing.Point(0, 0);
            this.lblCam1.Name = "lblCam1";
            this.lblCam1.Size = new System.Drawing.Size(210, 49);
            this.lblCam1.TabIndex = 0;
            this.lblCam1.Text = "영역 설정 화면 1";
            this.lblCam1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCamCrtl
            // 
            this.pnlCamCrtl.Controls.Add(this.btnSaveRegion);
            this.pnlCamCrtl.Controls.Add(this.gbShowCameraNum);
            this.pnlCamCrtl.Controls.Add(this.gbShowDispCount);
            this.pnlCamCrtl.Controls.Add(this.btnGrabImage);
            this.pnlCamCrtl.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCamCrtl.Location = new System.Drawing.Point(661, 0);
            this.pnlCamCrtl.Name = "pnlCamCrtl";
            this.pnlCamCrtl.Size = new System.Drawing.Size(192, 556);
            this.pnlCamCrtl.TabIndex = 0;
            // 
            // btnSaveRegion
            // 
            this.btnSaveRegion.Location = new System.Drawing.Point(9, 442);
            this.btnSaveRegion.Name = "btnSaveRegion";
            this.btnSaveRegion.Size = new System.Drawing.Size(171, 48);
            this.btnSaveRegion.TabIndex = 3;
            this.btnSaveRegion.Text = "영역 저장";
            this.btnSaveRegion.UseVisualStyleBackColor = true;
            this.btnSaveRegion.Click += new System.EventHandler(this.btnSaveRegion_Click);
            // 
            // gbShowCameraNum
            // 
            this.gbShowCameraNum.Controls.Add(this.cbxShowCameraNumber);
            this.gbShowCameraNum.Location = new System.Drawing.Point(9, 113);
            this.gbShowCameraNum.Name = "gbShowCameraNum";
            this.gbShowCameraNum.Size = new System.Drawing.Size(171, 51);
            this.gbShowCameraNum.TabIndex = 2;
            this.gbShowCameraNum.TabStop = false;
            this.gbShowCameraNum.Text = "화면 시작 카메라";
            // 
            // cbxShowCameraNumber
            // 
            this.cbxShowCameraNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxShowCameraNumber.FormattingEnabled = true;
            this.cbxShowCameraNumber.Location = new System.Drawing.Point(7, 21);
            this.cbxShowCameraNumber.Name = "cbxShowCameraNumber";
            this.cbxShowCameraNumber.Size = new System.Drawing.Size(158, 20);
            this.cbxShowCameraNumber.TabIndex = 0;
            this.cbxShowCameraNumber.SelectedIndexChanged += new System.EventHandler(this.cbxShowCameraNumber_SelectedIndexChanged);
            // 
            // gbShowDispCount
            // 
            this.gbShowDispCount.Controls.Add(this.rdbCount3);
            this.gbShowDispCount.Controls.Add(this.rdbCount2);
            this.gbShowDispCount.Controls.Add(this.rdbCount1);
            this.gbShowDispCount.Location = new System.Drawing.Point(9, 12);
            this.gbShowDispCount.Name = "gbShowDispCount";
            this.gbShowDispCount.Size = new System.Drawing.Size(171, 94);
            this.gbShowDispCount.TabIndex = 1;
            this.gbShowDispCount.TabStop = false;
            this.gbShowDispCount.Text = "화면 출력 개수";
            // 
            // rdbCount3
            // 
            this.rdbCount3.AutoSize = true;
            this.rdbCount3.Location = new System.Drawing.Point(6, 65);
            this.rdbCount3.Name = "rdbCount3";
            this.rdbCount3.Size = new System.Drawing.Size(97, 16);
            this.rdbCount3.TabIndex = 0;
            this.rdbCount3.Text = "출력 화면 3개";
            this.rdbCount3.UseVisualStyleBackColor = true;
            this.rdbCount3.CheckedChanged += new System.EventHandler(this.rdbCount3_CheckedChanged);
            // 
            // rdbCount2
            // 
            this.rdbCount2.AutoSize = true;
            this.rdbCount2.Location = new System.Drawing.Point(7, 43);
            this.rdbCount2.Name = "rdbCount2";
            this.rdbCount2.Size = new System.Drawing.Size(97, 16);
            this.rdbCount2.TabIndex = 0;
            this.rdbCount2.Text = "출력 화면 2개";
            this.rdbCount2.UseVisualStyleBackColor = true;
            this.rdbCount2.CheckedChanged += new System.EventHandler(this.rdbCount2_CheckedChanged);
            // 
            // rdbCount1
            // 
            this.rdbCount1.AutoSize = true;
            this.rdbCount1.Location = new System.Drawing.Point(7, 21);
            this.rdbCount1.Name = "rdbCount1";
            this.rdbCount1.Size = new System.Drawing.Size(97, 16);
            this.rdbCount1.TabIndex = 0;
            this.rdbCount1.Text = "출력 화면 1개";
            this.rdbCount1.UseVisualStyleBackColor = true;
            this.rdbCount1.CheckedChanged += new System.EventHandler(this.rdbCount1_CheckedChanged);
            // 
            // btnGrabImage
            // 
            this.btnGrabImage.Location = new System.Drawing.Point(9, 496);
            this.btnGrabImage.Name = "btnGrabImage";
            this.btnGrabImage.Size = new System.Drawing.Size(171, 48);
            this.btnGrabImage.TabIndex = 0;
            this.btnGrabImage.Text = "이미지 그랩";
            this.btnGrabImage.UseVisualStyleBackColor = true;
            this.btnGrabImage.Click += new System.EventHandler(this.btnGrabImage_Click);
            // 
            // lblMergeImageTitle
            // 
            this.lblMergeImageTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMergeImageTitle.Font = new System.Drawing.Font("Gulim", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMergeImageTitle.Location = new System.Drawing.Point(0, 259);
            this.lblMergeImageTitle.Name = "lblMergeImageTitle";
            this.lblMergeImageTitle.Size = new System.Drawing.Size(661, 45);
            this.lblMergeImageTitle.TabIndex = 2;
            this.lblMergeImageTitle.Text = "병합 이미지";
            this.lblMergeImageTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cMergeRecDisp
            // 
            this.cMergeRecDisp.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cMergeRecDisp.ColorMapLowerRoiLimit = 0D;
            this.cMergeRecDisp.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cMergeRecDisp.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cMergeRecDisp.ColorMapUpperRoiLimit = 1D;
            this.cMergeRecDisp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cMergeRecDisp.DoubleTapZoomCycleLength = 2;
            this.cMergeRecDisp.DoubleTapZoomSensitivity = 2.5D;
            this.cMergeRecDisp.Location = new System.Drawing.Point(0, 304);
            this.cMergeRecDisp.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cMergeRecDisp.MouseWheelSensitivity = 1D;
            this.cMergeRecDisp.Name = "cMergeRecDisp";
            this.cMergeRecDisp.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cMergeRecDisp.OcxState")));
            this.cMergeRecDisp.Size = new System.Drawing.Size(661, 252);
            this.cMergeRecDisp.TabIndex = 3;
            // 
            // cCamRecDisp3
            // 
            this.cCamRecDisp3.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cCamRecDisp3.ColorMapLowerRoiLimit = 0D;
            this.cCamRecDisp3.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cCamRecDisp3.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cCamRecDisp3.ColorMapUpperRoiLimit = 1D;
            this.cCamRecDisp3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cCamRecDisp3.DoubleTapZoomCycleLength = 2;
            this.cCamRecDisp3.DoubleTapZoomSensitivity = 2.5D;
            this.cCamRecDisp3.Location = new System.Drawing.Point(223, 47);
            this.cCamRecDisp3.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cCamRecDisp3.MouseWheelSensitivity = 1D;
            this.cCamRecDisp3.Name = "cCamRecDisp3";
            this.cCamRecDisp3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cCamRecDisp3.OcxState")));
            this.cCamRecDisp3.Size = new System.Drawing.Size(214, 179);
            this.cCamRecDisp3.TabIndex = 1;
            // 
            // cCamRecDisp2
            // 
            this.cCamRecDisp2.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cCamRecDisp2.ColorMapLowerRoiLimit = 0D;
            this.cCamRecDisp2.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cCamRecDisp2.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cCamRecDisp2.ColorMapUpperRoiLimit = 1D;
            this.cCamRecDisp2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cCamRecDisp2.DoubleTapZoomCycleLength = 2;
            this.cCamRecDisp2.DoubleTapZoomSensitivity = 2.5D;
            this.cCamRecDisp2.Location = new System.Drawing.Point(3, 47);
            this.cCamRecDisp2.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cCamRecDisp2.MouseWheelSensitivity = 1D;
            this.cCamRecDisp2.Name = "cCamRecDisp2";
            this.cCamRecDisp2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cCamRecDisp2.OcxState")));
            this.cCamRecDisp2.Size = new System.Drawing.Size(214, 179);
            this.cCamRecDisp2.TabIndex = 4;
            // 
            // frmMerge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 556);
            this.Controls.Add(this.cMergeRecDisp);
            this.Controls.Add(this.lblMergeImageTitle);
            this.Controls.Add(this.pnlCams);
            this.Controls.Add(this.pnlCamCrtl);
            this.Name = "frmMerge";
            this.Text = "병합 설정 창";
            this.pnlCams.ResumeLayout(false);
            this.pnlCam3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cRecDisp3)).EndInit();
            this.pnlCam2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cRecDisp2)).EndInit();
            this.pnlCam1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cRecDisp1)).EndInit();
            this.pnlCamCrtl.ResumeLayout(false);
            this.gbShowCameraNum.ResumeLayout(false);
            this.gbShowDispCount.ResumeLayout(false);
            this.gbShowDispCount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cMergeRecDisp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cCamRecDisp3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cCamRecDisp2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCamCrtl;
        private System.Windows.Forms.Label lblMergeImageTitle;
        private Cognex.VisionPro.CogRecordDisplay cMergeRecDisp;
        private System.Windows.Forms.GroupBox gbShowDispCount;
        private System.Windows.Forms.RadioButton rdbCount3;
        private System.Windows.Forms.RadioButton rdbCount2;
        private System.Windows.Forms.RadioButton rdbCount1;
        private System.Windows.Forms.Button btnGrabImage;
        private System.Windows.Forms.GroupBox gbShowCameraNum;
        private System.Windows.Forms.ComboBox cbxShowCameraNumber;
        private Cognex.VisionPro.CogRecordDisplay cCamRecDisp3;
        private Cognex.VisionPro.CogRecordDisplay cCamRecDisp2;
        private System.Windows.Forms.Panel pnlCams;
        private System.Windows.Forms.Panel pnlCam3;
        private System.Windows.Forms.Label lblCam3;
        private System.Windows.Forms.Panel pnlCam2;
        private System.Windows.Forms.Label lblCam2;
        private System.Windows.Forms.Panel pnlCam1;
        private System.Windows.Forms.Label lblCam1;
        private Cognex.VisionPro.CogRecordDisplay cRecDisp3;
        private Cognex.VisionPro.CogRecordDisplay cRecDisp2;
        private Cognex.VisionPro.CogRecordDisplay cRecDisp1;
        private System.Windows.Forms.Button btnSaveRegion;
    }
}