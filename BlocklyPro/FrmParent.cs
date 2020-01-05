using System;
using System.Windows.Forms;
using BlocklyPro.GameCreator;
using BlocklyPro.ServiceRepository;
using BlocklyPro.Utility;

namespace BlocklyPro
{
    public partial class FrmParent : Form
    {
        private readonly FrmLogin _frmlogin;
        private readonly IGameServiceRepository _gameServiceRepository;

        public FrmParent(FrmLogin frmlogin,IGameServiceRepository gameServiceRepository)
        {
            _frmlogin = frmlogin;
            _gameServiceRepository = gameServiceRepository;
            InitializeComponent();
            lblUser.Text = GlobalConfig.User;
        }

        private void cREATEAGAMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var createAGame = new Workbench(_gameServiceRepository);
            createAGame.MdiParent = this;
            createAGame.Show();
        }

        private void pLAYAGAMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var gameRunner = new GameRunner.GameRunner(_gameServiceRepository);
            gameRunner.MdiParent = this;
            gameRunner.Show();
        }

        private void EXCITToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void LOGOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            _frmlogin.Show();
        }
    }
}
