using System;
using System.Drawing;
using System.Windows.Forms;
using BlocklyPro.Models.GamePayloads;
using BlocklyPro.Utility;

namespace BlocklyPro.Code
{
    public partial class UCLoop2 : UserControl
    {
        private const int _oneStep = 50;
        public const int Identify = 5;
        private readonly GameRunner.GameRunner _gameRunner;
        public const int Height = 100;
        public UCLoop2(GameRunner.GameRunner gameRunner)
        {
            _gameRunner = gameRunner;
            InitializeComponent();
        }
        public void HighlightsFontColor()
        {
            lblForStatement.ForeColor = lblFor1.ForeColor = Color.Red;
        }

        private void btnInfo_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("Loops are used in programming to repeat a block of code until a specific condition is met. There are three loops in C programming:", "Loop");
        }

        private void BtnDelete_Click(object sender, System.EventArgs e)
        {
            _gameRunner.RemoveItem(this);
        }
        public int GetStepCount()
        {
            return Convert.ToInt32(txtSteps.Value) * _oneStep;
        }

        public string GetPayload()
        {
            return new Loop2()
            {
                Step = Convert.ToInt32(txtSteps.Value)
            }.ToJsonString();
        }

        public UserControl SetPayload(Loop2 item)
        {
            txtSteps.Value = item.Step;
            return this;
        }

        public void ResetFontColor()
        {
            lblForStatement.ForeColor = lblFor1.ForeColor = Color.Black;
        }
    }
}
