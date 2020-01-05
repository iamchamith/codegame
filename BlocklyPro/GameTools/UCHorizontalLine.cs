using System.Windows.Forms;
using BlocklyPro.Utility;

namespace BlocklyPro.GameTools
{
    public partial class UCHorizontalLine : UserControl
    {
        public Enums.ControllerType Types { get; } = Enums.ControllerType.HorizontalLine;
        public UCHorizontalLine()
        {
            InitializeComponent();
        }
    }
}
