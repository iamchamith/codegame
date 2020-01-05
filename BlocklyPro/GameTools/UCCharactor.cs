using System.Windows.Forms;
using BlocklyPro.Utility;

namespace BlocklyPro.GameTools
{
    public partial class UCCharactor : UserControl
    {
        public Enums.ControllerType Types { get; } = Enums.ControllerType.Charactor; 
        public UCCharactor()
        {
            InitializeComponent();
        }
    }
}
