using System.Drawing;
using System.Windows.Forms;
using BlocklyPro.Models.GamePayloads;
using BlocklyPro.Utility;

namespace BlocklyPro.Code
{
    public partial class UcTurn : UserControl
    {
        private readonly GameRunner.GameRunner _gameRunner;
        public const int Identify = 4;
        public UcTurn(GameRunner.GameRunner gameRunner)
        {
            _gameRunner = gameRunner;
            InitializeComponent();
            cmbTurn.SelectedItem = "Right";
        }
        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            _gameRunner.RemoveItem(this);
        }

        public Enums.Derection GetDerection()
        {
            return cmbTurn.SelectedItem == "Left" ? Enums.Derection.Left :
                Enums.Derection.Right;
        }

        public void HighlightsFontColor()
        {
            label1.ForeColor = Color.Red;
        }

        public void ResetFontColor()
        {
            label1.ForeColor = Color.Black;
        }

        private void btnInfo_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("In computer science, conditional statements, conditional expressions and conditional constructs are features of a programming language, which perform different computations or actions depending on whether a programmer-specified boolean condition evaluates to true or false.", "Condition");
        }

        public string GetPayload()
        {
            return new Turn()
            {
                Direction = cmbTurn.SelectedIndex
            }.ToJsonString();
        }

        public UserControl SetPayload(Turn item)
        {
            cmbTurn.SelectedIndex = item.Direction;
            return this;
        }

    }
}
