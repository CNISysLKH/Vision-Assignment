namespace CniVision
{
    partial class frmTools
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.cToolGroupEdit = new Cognex.VisionPro.ToolGroup.CogToolGroupEditV2();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cToolGroupEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnApply);
            this.panel1.Controls.Add(this.btnNo);
            this.panel1.Controls.Add(this.btnYes);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 498);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(915, 71);
            this.panel1.TabIndex = 0;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(828, 18);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 41);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "적용";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnNo
            // 
            this.btnNo.Location = new System.Drawing.Point(738, 18);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(75, 41);
            this.btnNo.TabIndex = 1;
            this.btnNo.Text = "취소";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(646, 18);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(75, 41);
            this.btnYes.TabIndex = 0;
            this.btnYes.Text = "확인";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // cToolGroupEdit
            // 
            this.cToolGroupEdit.AllowDrop = true;
            this.cToolGroupEdit.ContextMenuCustomizer = null;
            this.cToolGroupEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cToolGroupEdit.Location = new System.Drawing.Point(0, 0);
            this.cToolGroupEdit.MinimumSize = new System.Drawing.Size(489, 0);
            this.cToolGroupEdit.Name = "cToolGroupEdit";
            this.cToolGroupEdit.ShowNodeToolTips = true;
            this.cToolGroupEdit.Size = new System.Drawing.Size(915, 498);
            this.cToolGroupEdit.SuspendElectricRuns = false;
            this.cToolGroupEdit.TabIndex = 1;
            // 
            // frmTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 569);
            this.Controls.Add(this.cToolGroupEdit);
            this.Controls.Add(this.panel1);
            this.Name = "frmTools";
            this.Text = "도구 설정 창";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cToolGroupEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Button btnYes;
        private Cognex.VisionPro.ToolGroup.CogToolGroupEditV2 cToolGroupEdit;
    }
}