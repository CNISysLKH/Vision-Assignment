namespace CniVision
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cRecordDisplay = new Cognex.VisionPro.CogRecordDisplay();
            this.pnlTactTime = new System.Windows.Forms.Panel();
            this.lblTactTime = new System.Windows.Forms.Label();
            this.lblDataCount = new System.Windows.Forms.Label();
            this.tlpControls = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Symbology = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTriggerCount = new System.Windows.Forms.Panel();
            this.lblTriggerCount = new System.Windows.Forms.Label();
            this.btnTriggerCountReset = new System.Windows.Forms.Button();
            this.tlpControlsButton = new System.Windows.Forms.TableLayoutPanel();
            this.btnMergeControl = new System.Windows.Forms.Button();
            this.btnSetupControl = new System.Windows.Forms.Button();
            this.btnToolControl = new System.Windows.Forms.Button();
            this.btnCameraControl = new System.Windows.Forms.Button();
            this.rtxLog = new System.Windows.Forms.RichTextBox();
            this.tmCurrentTime = new System.Windows.Forms.Timer(this.components);
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cRecordDisplay)).BeginInit();
            this.pnlTactTime.SuspendLayout();
            this.tlpControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlTriggerCount.SuspendLayout();
            this.tlpControlsButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.Controls.Add(this.button1);
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Controls.Add(this.lblTime);
            this.pnlTitle.Controls.Add(this.picLogo);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(1208, 104);
            this.pnlTitle.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(821, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 36);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.White;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Yu Gothic UI", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblTitle.Location = new System.Drawing.Point(124, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(894, 104);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "C&I Vision";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.UseMnemonic = false;
            // 
            // lblTime
            // 
            this.lblTime.BackColor = System.Drawing.Color.White;
            this.lblTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTime.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTime.Location = new System.Drawing.Point(1018, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(190, 104);
            this.lblTime.TabIndex = 1;
            this.lblTime.Text = "Time";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // picLogo
            // 
            this.picLogo.BackgroundImage = global::CniVision.Properties.Resources.Logo1;
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.picLogo.Location = new System.Drawing.Point(0, 0);
            this.picLogo.Name = "picLogo";
            this.picLogo.Padding = new System.Windows.Forms.Padding(2);
            this.picLogo.Size = new System.Drawing.Size(124, 104);
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            this.picLogo.DoubleClick += new System.EventHandler(this.picLogo_DoubleClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 104);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cRecordDisplay);
            this.splitContainer1.Panel1.Controls.Add(this.pnlTactTime);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tlpControls);
            this.splitContainer1.Size = new System.Drawing.Size(1208, 459);
            this.splitContainer1.SplitterDistance = 920;
            this.splitContainer1.TabIndex = 1;
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
            this.cRecordDisplay.Location = new System.Drawing.Point(0, 73);
            this.cRecordDisplay.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cRecordDisplay.MouseWheelSensitivity = 1D;
            this.cRecordDisplay.Name = "cRecordDisplay";
            this.cRecordDisplay.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cRecordDisplay.OcxState")));
            this.cRecordDisplay.Size = new System.Drawing.Size(920, 386);
            this.cRecordDisplay.TabIndex = 1;
            // 
            // pnlTactTime
            // 
            this.pnlTactTime.Controls.Add(this.lblTactTime);
            this.pnlTactTime.Controls.Add(this.lblDataCount);
            this.pnlTactTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTactTime.Location = new System.Drawing.Point(0, 0);
            this.pnlTactTime.Name = "pnlTactTime";
            this.pnlTactTime.Padding = new System.Windows.Forms.Padding(5);
            this.pnlTactTime.Size = new System.Drawing.Size(920, 73);
            this.pnlTactTime.TabIndex = 0;
            // 
            // lblTactTime
            // 
            this.lblTactTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTactTime.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTactTime.Location = new System.Drawing.Point(246, 5);
            this.lblTactTime.Name = "lblTactTime";
            this.lblTactTime.Padding = new System.Windows.Forms.Padding(5);
            this.lblTactTime.Size = new System.Drawing.Size(669, 63);
            this.lblTactTime.TabIndex = 1;
            this.lblTactTime.Text = "Tact Time";
            this.lblTactTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDataCount
            // 
            this.lblDataCount.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblDataCount.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDataCount.Location = new System.Drawing.Point(5, 5);
            this.lblDataCount.Name = "lblDataCount";
            this.lblDataCount.Size = new System.Drawing.Size(241, 63);
            this.lblDataCount.TabIndex = 2;
            this.lblDataCount.Text = "찾은 개수 : ";
            this.lblDataCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpControls
            // 
            this.tlpControls.ColumnCount = 1;
            this.tlpControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpControls.Controls.Add(this.dataGridView1, 0, 0);
            this.tlpControls.Controls.Add(this.pnlTriggerCount, 0, 1);
            this.tlpControls.Controls.Add(this.tlpControlsButton, 0, 2);
            this.tlpControls.Controls.Add(this.rtxLog, 0, 3);
            this.tlpControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpControls.Location = new System.Drawing.Point(0, 0);
            this.tlpControls.Name = "tlpControls";
            this.tlpControls.RowCount = 4;
            this.tlpControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tlpControls.Size = new System.Drawing.Size(284, 459);
            this.tlpControls.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.Data,
            this.Symbology});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(278, 80);
            this.dataGridView1.TabIndex = 0;
            // 
            // Number
            // 
            this.Number.FillWeight = 30F;
            this.Number.HeaderText = "No.";
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            // 
            // Data
            // 
            this.Data.FillWeight = 108.6719F;
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            // 
            // Symbology
            // 
            this.Symbology.FillWeight = 60F;
            this.Symbology.HeaderText = "Symbology";
            this.Symbology.Name = "Symbology";
            this.Symbology.ReadOnly = true;
            // 
            // pnlTriggerCount
            // 
            this.pnlTriggerCount.Controls.Add(this.lblTriggerCount);
            this.pnlTriggerCount.Controls.Add(this.btnTriggerCountReset);
            this.pnlTriggerCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTriggerCount.Location = new System.Drawing.Point(3, 89);
            this.pnlTriggerCount.Name = "pnlTriggerCount";
            this.pnlTriggerCount.Size = new System.Drawing.Size(278, 94);
            this.pnlTriggerCount.TabIndex = 1;
            // 
            // lblTriggerCount
            // 
            this.lblTriggerCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTriggerCount.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTriggerCount.Location = new System.Drawing.Point(0, 0);
            this.lblTriggerCount.Name = "lblTriggerCount";
            this.lblTriggerCount.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblTriggerCount.Size = new System.Drawing.Size(199, 94);
            this.lblTriggerCount.TabIndex = 1;
            this.lblTriggerCount.Text = "Trigger Count";
            this.lblTriggerCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnTriggerCountReset
            // 
            this.btnTriggerCountReset.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnTriggerCountReset.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnTriggerCountReset.Location = new System.Drawing.Point(199, 0);
            this.btnTriggerCountReset.Name = "btnTriggerCountReset";
            this.btnTriggerCountReset.Size = new System.Drawing.Size(79, 94);
            this.btnTriggerCountReset.TabIndex = 0;
            this.btnTriggerCountReset.Text = "Reset";
            this.btnTriggerCountReset.UseVisualStyleBackColor = true;
            this.btnTriggerCountReset.Click += new System.EventHandler(this.btnTriggerCountReset_Click);
            // 
            // tlpControlsButton
            // 
            this.tlpControlsButton.ColumnCount = 2;
            this.tlpControlsButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpControlsButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpControlsButton.Controls.Add(this.btnMergeControl, 1, 1);
            this.tlpControlsButton.Controls.Add(this.btnSetupControl, 0, 1);
            this.tlpControlsButton.Controls.Add(this.btnToolControl, 1, 0);
            this.tlpControlsButton.Controls.Add(this.btnCameraControl, 0, 0);
            this.tlpControlsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpControlsButton.Location = new System.Drawing.Point(3, 189);
            this.tlpControlsButton.Name = "tlpControlsButton";
            this.tlpControlsButton.RowCount = 2;
            this.tlpControlsButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpControlsButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpControlsButton.Size = new System.Drawing.Size(278, 94);
            this.tlpControlsButton.TabIndex = 3;
            // 
            // btnMergeControl
            // 
            this.btnMergeControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMergeControl.Location = new System.Drawing.Point(142, 50);
            this.btnMergeControl.Name = "btnMergeControl";
            this.btnMergeControl.Size = new System.Drawing.Size(133, 41);
            this.btnMergeControl.TabIndex = 3;
            this.btnMergeControl.Text = "병합";
            this.btnMergeControl.UseVisualStyleBackColor = true;
            this.btnMergeControl.Click += new System.EventHandler(this.btnMergeControl_Click);
            // 
            // btnSetupControl
            // 
            this.btnSetupControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSetupControl.Location = new System.Drawing.Point(3, 50);
            this.btnSetupControl.Name = "btnSetupControl";
            this.btnSetupControl.Size = new System.Drawing.Size(133, 41);
            this.btnSetupControl.TabIndex = 2;
            this.btnSetupControl.Text = "설정";
            this.btnSetupControl.UseVisualStyleBackColor = true;
            this.btnSetupControl.Click += new System.EventHandler(this.btnSetupControl_Click);
            // 
            // btnToolControl
            // 
            this.btnToolControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnToolControl.Location = new System.Drawing.Point(142, 3);
            this.btnToolControl.Name = "btnToolControl";
            this.btnToolControl.Size = new System.Drawing.Size(133, 41);
            this.btnToolControl.TabIndex = 1;
            this.btnToolControl.Text = "도구";
            this.btnToolControl.UseVisualStyleBackColor = true;
            this.btnToolControl.Click += new System.EventHandler(this.btnToolControl_Click);
            // 
            // btnCameraControl
            // 
            this.btnCameraControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCameraControl.Location = new System.Drawing.Point(3, 3);
            this.btnCameraControl.Name = "btnCameraControl";
            this.btnCameraControl.Size = new System.Drawing.Size(133, 41);
            this.btnCameraControl.TabIndex = 0;
            this.btnCameraControl.Text = "카메라";
            this.btnCameraControl.UseVisualStyleBackColor = true;
            this.btnCameraControl.Click += new System.EventHandler(this.btnCameraControl_Click);
            // 
            // rtxLog
            // 
            this.rtxLog.BackColor = System.Drawing.SystemColors.InfoText;
            this.rtxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxLog.ForeColor = System.Drawing.SystemColors.Window;
            this.rtxLog.Location = new System.Drawing.Point(3, 289);
            this.rtxLog.Name = "rtxLog";
            this.rtxLog.Size = new System.Drawing.Size(278, 167);
            this.rtxLog.TabIndex = 4;
            this.rtxLog.Text = "";
            this.rtxLog.TextChanged += new System.EventHandler(this.rtxLog_TextChanged);
            // 
            // tmCurrentTime
            // 
            this.tmCurrentTime.Interval = 1;
            this.tmCurrentTime.Tick += new System.EventHandler(this.tmCurrentTime_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 563);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pnlTitle);
            this.Name = "frmMain";
            this.Text = "CNI Vision";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cRecordDisplay)).EndInit();
            this.pnlTactTime.ResumeLayout(false);
            this.tlpControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnlTriggerCount.ResumeLayout(false);
            this.tlpControlsButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Timer tmCurrentTime;
        private System.Windows.Forms.TableLayoutPanel tlpControls;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Symbology;
        private System.Windows.Forms.Panel pnlTriggerCount;
        private System.Windows.Forms.Button btnTriggerCountReset;
        private System.Windows.Forms.Label lblTriggerCount;
        private System.Windows.Forms.TableLayoutPanel tlpControlsButton;
        private System.Windows.Forms.RichTextBox rtxLog;
        private System.Windows.Forms.Button btnMergeControl;
        private System.Windows.Forms.Button btnSetupControl;
        private System.Windows.Forms.Button btnToolControl;
        private System.Windows.Forms.Button btnCameraControl;
        private Cognex.VisionPro.CogRecordDisplay cRecordDisplay;
        private System.Windows.Forms.Panel pnlTactTime;
        private System.Windows.Forms.Label lblTactTime;
        private System.Windows.Forms.Label lblDataCount;
        private System.Windows.Forms.Button button1;
    }
}

