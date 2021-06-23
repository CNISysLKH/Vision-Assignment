namespace CniVision
{
    partial class frmCamera
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCamera));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnLive = new System.Windows.Forms.Button();
            this.btnGainApply = new System.Windows.Forms.Button();
            this.btnExposureApply = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txbGain = new System.Windows.Forms.TextBox();
            this.lblExposure = new System.Windows.Forms.Label();
            this.txbExposure = new System.Windows.Forms.TextBox();
            this.lblCameraIndex = new System.Windows.Forms.Label();
            this.cbCameraIndex = new System.Windows.Forms.ComboBox();
            this.cRecordDisplay = new Cognex.VisionPro.CogRecordDisplay();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cRecordDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btnLive);
            this.pnlTop.Controls.Add(this.btnGainApply);
            this.pnlTop.Controls.Add(this.btnExposureApply);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.txbGain);
            this.pnlTop.Controls.Add(this.lblExposure);
            this.pnlTop.Controls.Add(this.txbExposure);
            this.pnlTop.Controls.Add(this.lblCameraIndex);
            this.pnlTop.Controls.Add(this.cbCameraIndex);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(914, 64);
            this.pnlTop.TabIndex = 0;
            // 
            // btnLive
            // 
            this.btnLive.Location = new System.Drawing.Point(788, 23);
            this.btnLive.Name = "btnLive";
            this.btnLive.Size = new System.Drawing.Size(75, 23);
            this.btnLive.TabIndex = 5;
            this.btnLive.Text = "라이브";
            this.btnLive.UseVisualStyleBackColor = true;
            this.btnLive.Click += new System.EventHandler(this.btnLive_Click);
            // 
            // btnGainApply
            // 
            this.btnGainApply.Location = new System.Drawing.Point(677, 23);
            this.btnGainApply.Name = "btnGainApply";
            this.btnGainApply.Size = new System.Drawing.Size(75, 23);
            this.btnGainApply.TabIndex = 4;
            this.btnGainApply.Text = "적용";
            this.btnGainApply.UseVisualStyleBackColor = true;
            this.btnGainApply.Click += new System.EventHandler(this.btnGainApply_Click);
            // 
            // btnExposureApply
            // 
            this.btnExposureApply.Location = new System.Drawing.Point(432, 23);
            this.btnExposureApply.Name = "btnExposureApply";
            this.btnExposureApply.Size = new System.Drawing.Size(75, 23);
            this.btnExposureApply.TabIndex = 4;
            this.btnExposureApply.Text = "적용";
            this.btnExposureApply.UseVisualStyleBackColor = true;
            this.btnExposureApply.Click += new System.EventHandler(this.btnExposureApply_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(523, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 39);
            this.label2.TabIndex = 3;
            this.label2.Text = "Gain";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbGain
            // 
            this.txbGain.Location = new System.Drawing.Point(588, 23);
            this.txbGain.Name = "txbGain";
            this.txbGain.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txbGain.Size = new System.Drawing.Size(83, 21);
            this.txbGain.TabIndex = 2;
            this.txbGain.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbGain_KeyPress);
            // 
            // lblExposure
            // 
            this.lblExposure.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblExposure.Location = new System.Drawing.Point(248, 12);
            this.lblExposure.Name = "lblExposure";
            this.lblExposure.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblExposure.Size = new System.Drawing.Size(92, 39);
            this.lblExposure.TabIndex = 3;
            this.lblExposure.Text = "Exposure";
            this.lblExposure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbExposure
            // 
            this.txbExposure.Location = new System.Drawing.Point(346, 23);
            this.txbExposure.Name = "txbExposure";
            this.txbExposure.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txbExposure.Size = new System.Drawing.Size(80, 21);
            this.txbExposure.TabIndex = 2;
            this.txbExposure.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbExposure_KeyPress);
            // 
            // lblCameraIndex
            // 
            this.lblCameraIndex.Font = new System.Drawing.Font("Gulim", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCameraIndex.Location = new System.Drawing.Point(12, 12);
            this.lblCameraIndex.Name = "lblCameraIndex";
            this.lblCameraIndex.Size = new System.Drawing.Size(92, 39);
            this.lblCameraIndex.TabIndex = 1;
            this.lblCameraIndex.Text = "카메라";
            this.lblCameraIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbCameraIndex
            // 
            this.cbCameraIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCameraIndex.Font = new System.Drawing.Font("Gulim", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbCameraIndex.FormattingEnabled = true;
            this.cbCameraIndex.Location = new System.Drawing.Point(110, 18);
            this.cbCameraIndex.Name = "cbCameraIndex";
            this.cbCameraIndex.Size = new System.Drawing.Size(121, 28);
            this.cbCameraIndex.TabIndex = 0;
            this.cbCameraIndex.SelectedIndexChanged += new System.EventHandler(this.cbCameraIndex_SelectedIndexChanged);
            // 
            // cRecordDisplay
            // 
            this.cRecordDisplay.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cRecordDisplay.ColorMapLowerRoiLimit = 0D;
            this.cRecordDisplay.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cRecordDisplay.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cRecordDisplay.ColorMapUpperRoiLimit = 1D;
            this.cRecordDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRecordDisplay.DoubleTapZoomCycleLength = 2;
            this.cRecordDisplay.DoubleTapZoomSensitivity = 2.5D;
            this.cRecordDisplay.Location = new System.Drawing.Point(0, 64);
            this.cRecordDisplay.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cRecordDisplay.MouseWheelSensitivity = 1D;
            this.cRecordDisplay.Name = "cRecordDisplay";
            this.cRecordDisplay.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cRecordDisplay.OcxState")));
            this.cRecordDisplay.Size = new System.Drawing.Size(914, 484);
            this.cRecordDisplay.TabIndex = 1;
            // 
            // frmCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 548);
            this.Controls.Add(this.cRecordDisplay);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Name = "frmCamera";
            this.Text = "카메라 설정";
            this.Load += new System.EventHandler(this.frmCamera_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cRecordDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private Cognex.VisionPro.CogRecordDisplay cRecordDisplay;
        private System.Windows.Forms.Label lblCameraIndex;
        private System.Windows.Forms.ComboBox cbCameraIndex;
        private System.Windows.Forms.Button btnGainApply;
        private System.Windows.Forms.Button btnExposureApply;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbGain;
        private System.Windows.Forms.Label lblExposure;
        private System.Windows.Forms.TextBox txbExposure;
        private System.Windows.Forms.Button btnLive;
    }
}