using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlocklyPro.Models;
using BlocklyPro.Utility;
using BlocklyPro.ServiceRepository;
namespace BlocklyPro.GameCreator
{
    public partial class FrmNewGame : Form
    {
        private Workbench _parentWorkbench;
        private bool _isCreate = false;
        private IGameServiceRepository _gameServiceRepository { get; }
        private int _gameId;
        public FrmNewGame(Workbench parentWorkbench, IGameServiceRepository gameServiceRepository)
        {
            InitializeComponent();
            _gameServiceRepository = gameServiceRepository;
            _parentWorkbench = parentWorkbench;
            this.Text = btnAddGame.Text = "CREATE GAME";
            _isCreate = true;
        }
        public FrmNewGame(Workbench parentWorkbench, IGameServiceRepository gameServiceRepository,
            int gameId)
        {
            InitializeComponent();
            _gameServiceRepository = gameServiceRepository;
            _parentWorkbench = parentWorkbench;
            this.Text = btnAddGame.Text = "UPDATE GAME";
            _isCreate = false;
            _gameId = gameId;
        }

        async Task LoadGame()
        {
            var result = await _gameServiceRepository.ReadGame(new Request<int>(_gameId).SetToken());
            txtDescription.Text = result.Instructions;
            txtName.Text = result.Name;
            txtTime.Value = result.Time;
            chkIsPublish.Checked = result.IsPublish;
        }

        private async void btnAddGame_Click(object sender, EventArgs e)
        {
            try
            {
                if (_isCreate)
                    CreateGame();
                else
                    UpdateGame();
            }
            catch (Exception exception)
            {
                new ExceptionHandler(exception);
            }
        }

        private async void CreateGame()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                Helper.Info(message: "Please provide the game name");
            }
            if (Helper.Confirm())
            {
                var request = new GameModel()
                {
                    Name = txtName.Text,
                    Time = Convert.ToInt32(txtTime.Value),
                    Instructions = txtDescription.Text,
                    IsPublish = chkIsPublish.Checked
                };
                var x = new Request<GameModel>(request)
                    .SetToken();
                await _gameServiceRepository.CreateGame(x);
                await _parentWorkbench.LoadGames();
                this.Close();
            }
        }

        private async void UpdateGame()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                Helper.Info(message: "Please provide the game name");
            }
            if (Helper.Confirm())
            {
                var request = new GameModel()
                {
                    Id = _gameId,
                    Name = txtName.Text,
                    Time = Convert.ToInt32(txtTime.Value),
                    Instructions = txtDescription.Text,
                    IsPublish = chkIsPublish.Checked
                };
                var x = new Request<GameModel>(request)
                    .SetToken();
                await _gameServiceRepository.UpdateGame(x);
                await _parentWorkbench.LoadGames();
                MessageBox.Show("Updated");
                this.Close();
            }
        }

        private async void FrmNewGame_Load(object sender, EventArgs e)
        {
            if (!_isCreate)
            {
                try
                {
                    await LoadGame();
                }
                catch (Exception exception)
                {
                    new ExceptionHandler(exception);
                }
            }
        }
    }
}
