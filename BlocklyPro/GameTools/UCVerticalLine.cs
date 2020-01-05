using System.Windows.Forms;
using BlocklyPro.Utility;

namespace BlocklyPro.GameTools
{
    public partial class UCVerticalLine : UserControl
    {
        public Enums.ControllerType Types { get; } = Enums.ControllerType.VerticalLine;
        public UCVerticalLine()
        {
            InitializeComponent();
        }
    }
}
