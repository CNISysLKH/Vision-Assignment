namespace CniVision
{
    partial class frmSetting
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
            this.grbSaveSetting = new System.Windows.Forms.GroupBox();
            this.ckbSaveTXT = new System.Windows.Forms.CheckBox();
            this.ckbSaveResultImage = new System.Windows.Forms.CheckBox();
            this.ckbSaveCSV = new System.Windows.Forms.CheckBox();
            this.ckbSaveOriginImage = new System.Windows.Forms.CheckBox();
            this.grbSaveImageDirectory = new System.Windows.Forms.GroupBox();
            this.btnSaveImageDirectoryDialog = new System.Windows.Forms.Button();
            this.lblSaveImageDirectory = new System.Windows.Forms.Label();
            this.grbSaveDataDirectory = new System.Windows.Forms.GroupBox();
            this.btnSaveDataDirectoryDialog = new System.Windows.Forms.Button();
            this.lblSaveDataDirectory = new System.Windows.Forms.Label();
            this.gbxIOBoradSignalSetting = new System.Windows.Forms.GroupBox();
            this.gbxInputToOutputSignal = new System.Windows.Forms.GroupBox();
            this.lblOutput = new System.Windows.Forms.Label();
            this.lblInput = new System.Windows.Forms.Label();
            this.cmbOutputSignal = new System.Windows.Forms.ComboBox();
            this.cmbInputSignal = new System.Windows.Forms.ComboBox();
            this.gbxInputPolarity = new System.Windows.Forms.GroupBox();
            this.cmbInputPolarity = new System.Windows.Forms.ComboBox();
            this.rdbInputRisingEdge = new System.Windows.Forms.RadioButton();
            this.rdbInputFallingEdge = new System.Windows.Forms.RadioButton();
            this.gbxOutputAction = new System.Windows.Forms.GroupBox();
            this.rdbOutputClose = new System.Windows.Forms.RadioButton();
            this.rdbOutputOpen = new System.Windows.Forms.RadioButton();
            this.cmbOutputAction = new System.Windows.Forms.ComboBox();
            this.grbSaveSetting.SuspendLayout();
            this.grbSaveImageDirectory.SuspendLayout();
            this.grbSaveDataDirectory.SuspendLayout();
            this.gbxIOBoradSignalSetting.SuspendLayout();
            this.gbxInputToOutputSignal.SuspendLayout();
            this.gbxInputPolarity.SuspendLayout();
            this.gbxOutputAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbSaveSetting
            // 
            this.grbSaveSetting.Controls.Add(this.ckbSaveTXT);
            this.grbSaveSetting.Controls.Add(this.ckbSaveResultImage);
            this.grbSaveSetting.Controls.Add(this.ckbSaveCSV);
            this.grbSaveSetting.Controls.Add(this.ckbSaveOriginImage);
            this.grbSaveSetting.Location = new System.Drawing.Point(12, 12);
            this.grbSaveSetting.Name = "grbSaveSetting";
            this.grbSaveSetting.Padding = new System.Windows.Forms.Padding(10);
            this.grbSaveSetting.Size = new System.Drawing.Size(269, 79);
            this.grbSaveSetting.TabIndex = 0;
            this.grbSaveSetting.TabStop = false;
            this.grbSaveSetting.Text = "저장 설정";
            // 
            // ckbSaveTXT
            // 
            this.ckbSaveTXT.AutoSize = true;
            this.ckbSaveTXT.Location = new System.Drawing.Point(135, 49);
            this.ckbSaveTXT.Name = "ckbSaveTXT";
            this.ckbSaveTXT.Size = new System.Drawing.Size(97, 16);
            this.ckbSaveTXT.TabIndex = 0;
            this.ckbSaveTXT.Text = ".txt 형식 저장";
            this.ckbSaveTXT.UseVisualStyleBackColor = true;
            this.ckbSaveTXT.CheckedChanged += new System.EventHandler(this.ckbSaveTXT_CheckedChanged);
            // 
            // ckbSaveResultImage
            // 
            this.ckbSaveResultImage.AutoSize = true;
            this.ckbSaveResultImage.Location = new System.Drawing.Point(135, 27);
            this.ckbSaveResultImage.Name = "ckbSaveResultImage";
            this.ckbSaveResultImage.Size = new System.Drawing.Size(116, 16);
            this.ckbSaveResultImage.TabIndex = 0;
            this.ckbSaveResultImage.Text = "결과 이미지 저장";
            this.ckbSaveResultImage.UseVisualStyleBackColor = true;
            this.ckbSaveResultImage.CheckedChanged += new System.EventHandler(this.ckbSaveResultImage_CheckedChanged);
            // 
            // ckbSaveCSV
            // 
            this.ckbSaveCSV.AutoSize = true;
            this.ckbSaveCSV.Location = new System.Drawing.Point(13, 49);
            this.ckbSaveCSV.Name = "ckbSaveCSV";
            this.ckbSaveCSV.Size = new System.Drawing.Size(104, 16);
            this.ckbSaveCSV.TabIndex = 0;
            this.ckbSaveCSV.Text = ".csv 형식 저장";
            this.ckbSaveCSV.UseVisualStyleBackColor = true;
            this.ckbSaveCSV.CheckedChanged += new System.EventHandler(this.ckbSaveCSV_CheckedChanged);
            // 
            // ckbSaveOriginImage
            // 
            this.ckbSaveOriginImage.AutoSize = true;
            this.ckbSaveOriginImage.Location = new System.Drawing.Point(13, 27);
            this.ckbSaveOriginImage.Name = "ckbSaveOriginImage";
            this.ckbSaveOriginImage.Size = new System.Drawing.Size(116, 16);
            this.ckbSaveOriginImage.TabIndex = 0;
            this.ckbSaveOriginImage.Text = "원본 이미지 저장";
            this.ckbSaveOriginImage.UseVisualStyleBackColor = true;
            this.ckbSaveOriginImage.CheckedChanged += new System.EventHandler(this.ckbSaveOriginImage_CheckedChanged);
            // 
            // grbSaveImageDirectory
            // 
            this.grbSaveImageDirectory.Controls.Add(this.btnSaveImageDirectoryDialog);
            this.grbSaveImageDirectory.Controls.Add(this.lblSaveImageDirectory);
            this.grbSaveImageDirectory.Location = new System.Drawing.Point(12, 98);
            this.grbSaveImageDirectory.Name = "grbSaveImageDirectory";
            this.grbSaveImageDirectory.Size = new System.Drawing.Size(269, 57);
            this.grbSaveImageDirectory.TabIndex = 1;
            this.grbSaveImageDirectory.TabStop = false;
            this.grbSaveImageDirectory.Text = "이미지 저장 위치";
            // 
            // btnSaveImageDirectoryDialog
            // 
            this.btnSaveImageDirectoryDialog.Location = new System.Drawing.Point(210, 21);
            this.btnSaveImageDirectoryDialog.Name = "btnSaveImageDirectoryDialog";
            this.btnSaveImageDirectoryDialog.Size = new System.Drawing.Size(53, 21);
            this.btnSaveImageDirectoryDialog.TabIndex = 1;
            this.btnSaveImageDirectoryDialog.Text = "...";
            this.btnSaveImageDirectoryDialog.UseVisualStyleBackColor = true;
            this.btnSaveImageDirectoryDialog.Click += new System.EventHandler(this.btnSaveImageDirectoryDialog_Click);
            // 
            // lblSaveImageDirectory
            // 
            this.lblSaveImageDirectory.AutoEllipsis = true;
            this.lblSaveImageDirectory.BackColor = System.Drawing.SystemColors.Window;
            this.lblSaveImageDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSaveImageDirectory.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSaveImageDirectory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSaveImageDirectory.Location = new System.Drawing.Point(7, 21);
            this.lblSaveImageDirectory.Name = "lblSaveImageDirectory";
            this.lblSaveImageDirectory.Size = new System.Drawing.Size(197, 21);
            this.lblSaveImageDirectory.TabIndex = 2;
            this.lblSaveImageDirectory.Text = "Save Image Directory";
            this.lblSaveImageDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grbSaveDataDirectory
            // 
            this.grbSaveDataDirectory.Controls.Add(this.btnSaveDataDirectoryDialog);
            this.grbSaveDataDirectory.Controls.Add(this.lblSaveDataDirectory);
            this.grbSaveDataDirectory.Location = new System.Drawing.Point(12, 161);
            this.grbSaveDataDirectory.Name = "grbSaveDataDirectory";
            this.grbSaveDataDirectory.Size = new System.Drawing.Size(269, 57);
            this.grbSaveDataDirectory.TabIndex = 2;
            this.grbSaveDataDirectory.TabStop = false;
            this.grbSaveDataDirectory.Text = "결과 데이터 저장 위치";
            // 
            // btnSaveDataDirectoryDialog
            // 
            this.btnSaveDataDirectoryDialog.Location = new System.Drawing.Point(210, 21);
            this.btnSaveDataDirectoryDialog.Name = "btnSaveDataDirectoryDialog";
            this.btnSaveDataDirectoryDialog.Size = new System.Drawing.Size(53, 21);
            this.btnSaveDataDirectoryDialog.TabIndex = 1;
            this.btnSaveDataDirectoryDialog.Text = "...";
            this.btnSaveDataDirectoryDialog.UseVisualStyleBackColor = true;
            this.btnSaveDataDirectoryDialog.Click += new System.EventHandler(this.btnSaveDataDirectoryDialog_Click);
            // 
            // lblSaveDataDirectory
            // 
            this.lblSaveDataDirectory.AutoEllipsis = true;
            this.lblSaveDataDirectory.BackColor = System.Drawing.SystemColors.Window;
            this.lblSaveDataDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSaveDataDirectory.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSaveDataDirectory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSaveDataDirectory.Location = new System.Drawing.Point(7, 21);
            this.lblSaveDataDirectory.Name = "lblSaveDataDirectory";
            this.lblSaveDataDirectory.Size = new System.Drawing.Size(197, 21);
            this.lblSaveDataDirectory.TabIndex = 3;
            this.lblSaveDataDirectory.Text = "Save Data Directory";
            this.lblSaveDataDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbxIOBoradSignalSetting
            // 
            this.gbxIOBoradSignalSetting.Controls.Add(this.gbxOutputAction);
            this.gbxIOBoradSignalSetting.Controls.Add(this.gbxInputPolarity);
            this.gbxIOBoradSignalSetting.Controls.Add(this.gbxInputToOutputSignal);
            this.gbxIOBoradSignalSetting.Location = new System.Drawing.Point(12, 225);
            this.gbxIOBoradSignalSetting.Name = "gbxIOBoradSignalSetting";
            this.gbxIOBoradSignalSetting.Size = new System.Drawing.Size(269, 212);
            this.gbxIOBoradSignalSetting.TabIndex = 3;
            this.gbxIOBoradSignalSetting.TabStop = false;
            this.gbxIOBoradSignalSetting.Text = "I/O 보드 세팅";
            // 
            // gbxInputToOutputSignal
            // 
            this.gbxInputToOutputSignal.Controls.Add(this.lblOutput);
            this.gbxInputToOutputSignal.Controls.Add(this.lblInput);
            this.gbxInputToOutputSignal.Controls.Add(this.cmbOutputSignal);
            this.gbxInputToOutputSignal.Controls.Add(this.cmbInputSignal);
            this.gbxInputToOutputSignal.Location = new System.Drawing.Point(7, 21);
            this.gbxInputToOutputSignal.Name = "gbxInputToOutputSignal";
            this.gbxInputToOutputSignal.Size = new System.Drawing.Size(256, 75);
            this.gbxInputToOutputSignal.TabIndex = 0;
            this.gbxInputToOutputSignal.TabStop = false;
            this.gbxInputToOutputSignal.Text = "Input To Output";
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOutput.Location = new System.Drawing.Point(6, 46);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(41, 12);
            this.lblOutput.TabIndex = 1;
            this.lblOutput.Text = "Output";
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblInput.Location = new System.Drawing.Point(6, 20);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(32, 12);
            this.lblInput.TabIndex = 1;
            this.lblInput.Text = "Input";
            // 
            // cmbOutputSignal
            // 
            this.cmbOutputSignal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOutputSignal.FormattingEnabled = true;
            this.cmbOutputSignal.Location = new System.Drawing.Point(58, 43);
            this.cmbOutputSignal.Name = "cmbOutputSignal";
            this.cmbOutputSignal.Size = new System.Drawing.Size(192, 20);
            this.cmbOutputSignal.TabIndex = 0;
            this.cmbOutputSignal.SelectedIndexChanged += new System.EventHandler(this.cmbOutputSignal_SelectedIndexChanged);
            // 
            // cmbInputSignal
            // 
            this.cmbInputSignal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInputSignal.FormattingEnabled = true;
            this.cmbInputSignal.Location = new System.Drawing.Point(58, 17);
            this.cmbInputSignal.Name = "cmbInputSignal";
            this.cmbInputSignal.Size = new System.Drawing.Size(192, 20);
            this.cmbInputSignal.TabIndex = 0;
            this.cmbInputSignal.SelectedIndexChanged += new System.EventHandler(this.cmbInputSignal_SelectedIndexChanged);
            // 
            // gbxInputPolarity
            // 
            this.gbxInputPolarity.Controls.Add(this.rdbInputFallingEdge);
            this.gbxInputPolarity.Controls.Add(this.rdbInputRisingEdge);
            this.gbxInputPolarity.Controls.Add(this.cmbInputPolarity);
            this.gbxInputPolarity.Location = new System.Drawing.Point(7, 103);
            this.gbxInputPolarity.Name = "gbxInputPolarity";
            this.gbxInputPolarity.Size = new System.Drawing.Size(256, 49);
            this.gbxInputPolarity.TabIndex = 1;
            this.gbxInputPolarity.TabStop = false;
            this.gbxInputPolarity.Text = "Input 극성 설정";
            // 
            // cmbInputPolarity
            // 
            this.cmbInputPolarity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInputPolarity.FormattingEnabled = true;
            this.cmbInputPolarity.Location = new System.Drawing.Point(7, 21);
            this.cmbInputPolarity.Name = "cmbInputPolarity";
            this.cmbInputPolarity.Size = new System.Drawing.Size(137, 20);
            this.cmbInputPolarity.TabIndex = 0;
            this.cmbInputPolarity.SelectedIndexChanged += new System.EventHandler(this.cmbInputPolarity_SelectedIndexChanged);
            // 
            // rdbInputRisingEdge
            // 
            this.rdbInputRisingEdge.AutoSize = true;
            this.rdbInputRisingEdge.Location = new System.Drawing.Point(150, 22);
            this.rdbInputRisingEdge.Name = "rdbInputRisingEdge";
            this.rdbInputRisingEdge.Size = new System.Drawing.Size(47, 16);
            this.rdbInputRisingEdge.TabIndex = 1;
            this.rdbInputRisingEdge.TabStop = true;
            this.rdbInputRisingEdge.Text = "상승";
            this.rdbInputRisingEdge.UseVisualStyleBackColor = true;
            this.rdbInputRisingEdge.CheckedChanged += new System.EventHandler(this.rdbInputRisingEdge_CheckedChanged);
            // 
            // rdbInputFallingEdge
            // 
            this.rdbInputFallingEdge.AutoSize = true;
            this.rdbInputFallingEdge.Location = new System.Drawing.Point(203, 22);
            this.rdbInputFallingEdge.Name = "rdbInputFallingEdge";
            this.rdbInputFallingEdge.Size = new System.Drawing.Size(47, 16);
            this.rdbInputFallingEdge.TabIndex = 1;
            this.rdbInputFallingEdge.TabStop = true;
            this.rdbInputFallingEdge.Text = "하강";
            this.rdbInputFallingEdge.UseVisualStyleBackColor = true;
            this.rdbInputFallingEdge.CheckedChanged += new System.EventHandler(this.rdbInputFallingEdge_CheckedChanged);
            // 
            // gbxOutputAction
            // 
            this.gbxOutputAction.Controls.Add(this.rdbOutputClose);
            this.gbxOutputAction.Controls.Add(this.rdbOutputOpen);
            this.gbxOutputAction.Controls.Add(this.cmbOutputAction);
            this.gbxOutputAction.Location = new System.Drawing.Point(7, 158);
            this.gbxOutputAction.Name = "gbxOutputAction";
            this.gbxOutputAction.Size = new System.Drawing.Size(256, 49);
            this.gbxOutputAction.TabIndex = 1;
            this.gbxOutputAction.TabStop = false;
            this.gbxOutputAction.Text = "Output 작업 설정";
            // 
            // rdbOutputClose
            // 
            this.rdbOutputClose.AutoSize = true;
            this.rdbOutputClose.Location = new System.Drawing.Point(203, 22);
            this.rdbOutputClose.Name = "rdbOutputClose";
            this.rdbOutputClose.Size = new System.Drawing.Size(47, 16);
            this.rdbOutputClose.TabIndex = 1;
            this.rdbOutputClose.TabStop = true;
            this.rdbOutputClose.Text = "닫힘";
            this.rdbOutputClose.UseVisualStyleBackColor = true;
            this.rdbOutputClose.CheckedChanged += new System.EventHandler(this.rdbOutputClose_CheckedChanged);
            // 
            // rdbOutputOpen
            // 
            this.rdbOutputOpen.AutoSize = true;
            this.rdbOutputOpen.Location = new System.Drawing.Point(150, 22);
            this.rdbOutputOpen.Name = "rdbOutputOpen";
            this.rdbOutputOpen.Size = new System.Drawing.Size(47, 16);
            this.rdbOutputOpen.TabIndex = 1;
            this.rdbOutputOpen.TabStop = true;
            this.rdbOutputOpen.Text = "열림";
            this.rdbOutputOpen.UseVisualStyleBackColor = true;
            this.rdbOutputOpen.CheckedChanged += new System.EventHandler(this.rdbOutputOpen_CheckedChanged);
            // 
            // cmbOutputAction
            // 
            this.cmbOutputAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOutputAction.FormattingEnabled = true;
            this.cmbOutputAction.Location = new System.Drawing.Point(7, 21);
            this.cmbOutputAction.Name = "cmbOutputAction";
            this.cmbOutputAction.Size = new System.Drawing.Size(137, 20);
            this.cmbOutputAction.TabIndex = 0;
            this.cmbOutputAction.SelectedIndexChanged += new System.EventHandler(this.cmbOutputAction_SelectedIndexChanged);
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 447);
            this.Controls.Add(this.gbxIOBoradSignalSetting);
            this.Controls.Add(this.grbSaveDataDirectory);
            this.Controls.Add(this.grbSaveImageDirectory);
            this.Controls.Add(this.grbSaveSetting);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(306, 476);
            this.Name = "frmSetting";
            this.Text = "설정 창";
            this.Load += new System.EventHandler(this.frmSetting_Load);
            this.grbSaveSetting.ResumeLayout(false);
            this.grbSaveSetting.PerformLayout();
            this.grbSaveImageDirectory.ResumeLayout(false);
            this.grbSaveDataDirectory.ResumeLayout(false);
            this.gbxIOBoradSignalSetting.ResumeLayout(false);
            this.gbxInputToOutputSignal.ResumeLayout(false);
            this.gbxInputToOutputSignal.PerformLayout();
            this.gbxInputPolarity.ResumeLayout(false);
            this.gbxInputPolarity.PerformLayout();
            this.gbxOutputAction.ResumeLayout(false);
            this.gbxOutputAction.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbSaveSetting;
        private System.Windows.Forms.CheckBox ckbSaveTXT;
        private System.Windows.Forms.CheckBox ckbSaveResultImage;
        private System.Windows.Forms.CheckBox ckbSaveCSV;
        private System.Windows.Forms.CheckBox ckbSaveOriginImage;
        private System.Windows.Forms.GroupBox grbSaveImageDirectory;
        private System.Windows.Forms.Button btnSaveImageDirectoryDialog;
        private System.Windows.Forms.GroupBox grbSaveDataDirectory;
        private System.Windows.Forms.Button btnSaveDataDirectoryDialog;
        private System.Windows.Forms.Label lblSaveImageDirectory;
        private System.Windows.Forms.Label lblSaveDataDirectory;
        private System.Windows.Forms.GroupBox gbxIOBoradSignalSetting;
        private System.Windows.Forms.GroupBox gbxInputToOutputSignal;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.ComboBox cmbOutputSignal;
        private System.Windows.Forms.ComboBox cmbInputSignal;
        private System.Windows.Forms.GroupBox gbxInputPolarity;
        private System.Windows.Forms.RadioButton rdbInputFallingEdge;
        private System.Windows.Forms.RadioButton rdbInputRisingEdge;
        private System.Windows.Forms.ComboBox cmbInputPolarity;
        private System.Windows.Forms.GroupBox gbxOutputAction;
        private System.Windows.Forms.RadioButton rdbOutputClose;
        private System.Windows.Forms.RadioButton rdbOutputOpen;
        private System.Windows.Forms.ComboBox cmbOutputAction;
    }
}