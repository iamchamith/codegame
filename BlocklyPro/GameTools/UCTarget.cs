using System.Windows.Forms;
using BlocklyPro.Utility;

namespace BlocklyPro.GameTools
{
    public partial class UCTarget : UserControl
    {
        public Enums.ControllerType Types { get; } = Enums.ControllerType.Target;
        public UCTarget()
        {
            InitializeComponent();
        }
    }
}
