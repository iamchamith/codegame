using System.Windows.Forms;
using BlocklyPro.Models.GamePayloads;
using BlocklyPro.Utility;

namespace BlocklyPro.Code
{
    public partial class UcLoop : UserControl
    {
        public const int Identify = 2;
        public UcLoop()
        {
            InitializeComponent();
        }

        private void btnInfo_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("Loops are used in programming to repeat a block of code until a specific condition is met. There are three loops in C programming:", "Loop");
        }
        public string GetPayload()
        {
            return new BasePayload
            {
            }.ToJsonString();
        }
    }
}
