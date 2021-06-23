using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Cognex.VisionPro;
using Cognex.VisionPro.ToolGroup;
using Cognex.VisionPro.ImageProcessing;

namespace CniVision
{
    public partial class frmTools : Form
    {
        public CniToolProcess toolProcess;
        public frmTools(CniToolProcess tp)
        {
            Icon = Properties.Resources.Logo;

            InitializeComponent();
            toolProcess = tp;
            cToolGroupEdit.Subject = toolProcess.cToolGroup;

        }

        #region 폼 관련 이벤트
        // 확인 버튼 클릭 시 (저장, 적용, 닫기)
        private void btnYes_Click(object sender, EventArgs e)
        {
            CniToolProcess.SaveTool(toolProcess.cToolGroup, "IDReadToolGroup");
            toolProcess.RefreshTools();
            Close();
        }

        // 취소 버튼 클릭 시 (닫기)
        private void btnNo_Click(object sender, EventArgs e)
        {
            Close();
        }
        // 적용 버튼 클릭 시 (저장, 적용)
        private void btnApply_Click(object sender, EventArgs e)
        {
            CniToolProcess.SaveTool(toolProcess.cToolGroup, "IDReadToolGroup");
            toolProcess.RefreshTools();
        }
        #endregion
    }
}
