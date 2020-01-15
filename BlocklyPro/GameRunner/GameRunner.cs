using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlocklyPro.Code;
using BlocklyPro.Forcasting;
using BlocklyPro.GameTools;
using BlocklyPro.Models;
using BlocklyPro.Models.GamePayloads;
using BlocklyPro.Utility;
using BlocklyPro.ServiceRepository;

namespace BlocklyPro.GameRunner
{
    public partial class GameRunner : Form
    {
        private readonly IGameServiceRepository _gameServiceRepository;
        private List<UserControl> Codes;
        private Enums.Derection _derection;
        private int X = 0;
        private int Y = 0;
        private UserControl _charactor;
        private int codeLine = 0;
        private int movePx;
        private int _selectedGameId = 0;
        private int _time = 1;
        private bool _useToSubmitDefault = false;
        private GameModel _selectedGameObject;
        private List<KeyValuePair<int, string>> _playGames = new List<KeyValuePair<int, string>>();
        private PlayGameModel _correctSolution = new PlayGameModel();
        private bool _isGameRunning = false;
        public GameRunner(IGameServiceRepository gameServiceRepository)
        {
            _gameServiceRepository = gameServiceRepository;
            InitializeComponent();
        }

        public GameRunner(IGameServiceRepository gameServiceRepository, int gameIndex)
        {
            _gameServiceRepository = gameServiceRepository;
            this._selectedGameId = gameIndex;
            _useToSubmitDefault = true;
            InitializeComponent();
            SetAsDefaultSubmittionSettings();
        }

        void SetAsDefaultSubmittionSettings()
        {
            this.Text = $"{Text}-Default Submittion";
            cmbGames.Enabled = false;
            btnGo.Visible = lblTime.Visible =
                btnHint.Visible= btnForcast.Visible=
                cmbPlayGames.Visible = btnLoadPlayGame.Visible = false;
        }

        private async void GameRunner_Load(object sender, EventArgs e)
        {
            #region init
            Codes = new List<UserControl>();
            _derection = Enums.Derection.Right;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            codeCore.AutoScroll = false;
            codeCore.HorizontalScroll.Enabled = false;
            codeCore.HorizontalScroll.Visible = false;
            codeCore.HorizontalScroll.Maximum = 0;
            codeCore.AutoScroll = true;

            var move1 = new UcFunction();
            move1.Location = new Point(0, codeIndex);
            codeCore.Controls.Add(move1);
            Codes.Add(move1);
            codeIndex += UcFunction.Height;

            var move2 = new UcLoop();
            move2.Location = new Point(10, codeIndex);
            codeCore.Controls.Add(move2);
            Codes.Add(move2);
            codeIndex += UcLoop.Height;
            #endregion

            await LoadInit();
        }
        private async Task LoadInit()
        {
            await LoadGames();
            await LoadGameMap();
            await LoadSolution();
        }
        private async void btnLoadGame_Click(object sender, System.EventArgs e)
        {
            await LoadGameMap();
        }
        private async Task LoadGameMap()
        {
            try
            {
                codeCore.Visible = true;
                var index = 0;
                RemoveItems();
                var result = await _gameServiceRepository.GetGameMap(new Request<int>(this._selectedGameId).SetToken());
                await ReadGameInfo();
                await LoadPlayedGameList();
                var name = "";
                foreach (var item in result)
                {
                    UserControl ctrl;
                    switch (item.ControllerType)
                    {
                        case Enums.ControllerType.VerticalLine:
                            ctrl = new UCVerticalLine();
                            name = "ucVerticalLine_";
                            break;
                        case Enums.ControllerType.HorizontalLine:
                            ctrl = new UCHorizontalLine();
                            name = "ucHorizontalLine_";
                            break;
                        case Enums.ControllerType.Charactor:
                            ctrl = new UCCharactor();
                            name = "ucChar_";
                            _charactor = ctrl;
                            X = item.PointX;
                            Y = item.PointY;
                            break;
                        case Enums.ControllerType.Target:
                            ctrl = new UCTarget();
                            name = "ucTarget_";
                            break;
                        default:
                            continue;
                    }

                    ctrl.Name = $"{name}{index}";
                    ctrl.Location = new Point(item.PointX, item.PointY);
                    ctrl.Size = new Size(item.Width, item.Height);
                    Controls.Add(ctrl);
                    index++;
                }
            }
            catch (Exception ex)
            {
                new ExceptionHandler(ex);
            }
        }

        private async Task ReadGameInfo()
        {
            _selectedGameObject = await _gameServiceRepository.ReadGame(new Request<int>(this._selectedGameId).SetToken());
            _time = _selectedGameObject.Time * 60;
        }

        private async Task LoadPlayedGameList()
        {
            _playGames = await _gameServiceRepository.GetGamePlays(new Request<int>(_selectedGameId).SetToken());
            if (_playGames == null || _playGames.Count == 0)
            {
                return;
            }
            cmbPlayGames.ComboBox.ValueMember = "key";
            cmbPlayGames.ComboBox.DisplayMember = "value";
            cmbPlayGames.ComboBox.DataSource = _playGames;
            cmbPlayGames.SelectedIndex = 0;
        }
 
        private async Task LoadGames()
        {
            try
            {
                var result = _useToSubmitDefault
                    ? await _gameServiceRepository.GetMyGames(new Request<bool>(false).SetToken())
                    : await _gameServiceRepository.GetPublishGames(new Request<bool>(false).SetToken());
                cmbGames.ComboBox.ValueMember = "key";
                cmbGames.ComboBox.DisplayMember = "value";
                cmbGames.ComboBox.DataSource = result;
                cmbGames.SelectedItem = this._selectedGameId;

                //load default game solution
          
            }
            catch (Exception e)
            {
                new ExceptionHandler(e);
            }
        }

        private void RemoveItems()
        {
            try
            {
                var ucControllers = new[] { "ucHorizontalLine_", "ucVerticalLine_", "ucTarget_", "ucChar_" }.ToList();
                var mustRemove = new List<Control>();
                var indexx = 0;
                foreach (Control item in Controls)
                {
                    foreach (var item2 in ucControllers)
                    {
                        if (item.Name.StartsWith(item2, StringComparison.CurrentCultureIgnoreCase))
                        {
                            indexx++;
                            mustRemove.Add(item);
                        }
                    }
                }

                for (int i = 0; i < indexx; i++)
                {
                    Controls.Remove(mustRemove[i]);
                }
            }
            catch (Exception e)
            {
                new ExceptionHandler(e);
            }
        }

        #region manage codes

        private int codeIndex = 0;

        private void sTATEMENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var move = new UcMoveForward(this);
            move.Location = new Point(20, codeIndex);
            codeCore.Controls.Add(move);
            Codes.Add(move);
            codeIndex += UcMoveForward.Height;
        }

        private void cONDITIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var move = new UcTurn(this);
            move.Location = new Point(20, codeIndex);
            codeCore.Controls.Add(move);
            Codes.Add(move);
            codeIndex += UcTurn.Height;
        }
        private void LOOPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var move = new UCLoop2(this);
            move.Location = new Point(20, codeIndex);
            codeCore.Controls.Add(move);
            Codes.Add(move);
            codeIndex += UCLoop2.Height;
        }
        public void RemoveItem(UserControl uc)
        {
            codeCore.Controls.Remove(uc);
            Codes.Remove(uc);
            ResetCode();
        }
        public void ResetCode()
        {
            codeIndex = 100;
            foreach (var item in Codes)
            {
                if (item is UcTurn)
                {
                    codeCore.Controls.Remove(item);
                    item.Location = new Point(20, codeIndex);
                    codeCore.Controls.Add(item);
                    codeIndex += UcTurn.Height;
                }
                else if (item is UcMoveForward)
                {
                    codeCore.Controls.Remove(item);
                    item.Location = new Point(20, codeIndex);
                    codeCore.Controls.Add(item);
                    codeIndex += UcMoveForward.Height;
                }
                else if (item is UCLoop2)
                {
                    codeCore.Controls.Remove(item);
                    item.Location = new Point(20, codeIndex);
                    codeCore.Controls.Add(item);
                    codeIndex += UCLoop2.Height;
                }
            }
        }
        private void lnkRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetCode();
        }
        #endregion

        #region play game
        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (!_isGameRunning)
            {
                _derection = Enums.Derection.Right;
                ResetFontColor();
                codeLine = 0;
                movePx = 0;
                IsGameRunnning(true);
                Run();
            }
            else
            {
                timer1.Stop();
                IsGameRunnning(false);
            }
           
        }

        void IsGameRunnning(bool isGameRunning)
        {
            _isGameRunning = isGameRunning;
            btnPlay.Image = isGameRunning ? Properties.Resources.pause : Properties.Resources.play;
            btnCodeMenu.Enabled = !isGameRunning;
            btnLoadGame.Enabled = !isGameRunning;
            btnHint.Enabled = !isGameRunning;
            btnInfo.Enabled = !isGameRunning;
            btnClear.Enabled = !isGameRunning;
        }

        void Run()
        {
            try
            {
                var line = Codes[codeLine];
                codeLine++;
                if (line is UcTurn)
                {
                    var itemX = line as UcTurn;
                    itemX.HighlightsFontColor();
                    var derection = itemX.GetDerection();
                    GetDerection(derection);
                    Run();
                }
                else if (line is UcMoveForward)
                {
                    var itemX = line as UcMoveForward;
                    itemX.HighlightsFontColor();
                    timer1.Start();
                    movePx = itemX.GetStepCount();
                }
                else if (line is UCLoop2)
                {
                    var itemX = line as UCLoop2;
                    itemX.HighlightsFontColor();
                    timer1.Start();
                    movePx = itemX.GetStepCount();
                }
                else if (line is UcFunction || line is UcLoop)
                {
                    Run();
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                MessageBox.Show("Complete");
                IsGameRunnning(false);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (movePx <= 0)
            {
                timer1.Stop();
                Run();
            }

            var point = new Point(X, Y);
            switch (_derection)
            {
                case Enums.Derection.None:
                    break;
                case Enums.Derection.Right:
                    point.X += 1;
                    break;
                case Enums.Derection.Top:
                    point.Y -= 1;
                    break;
                case Enums.Derection.Left:
                    point.X -= 1;
                    break;
                case Enums.Derection.Down:
                    point.Y += 1;
                    break;
            }

            X = point.X;
            Y = point.Y;
            _charactor.Location = point;
            movePx--;
            //Console.Beep();
        }
        void GetDerection(Enums.Derection derection)
        {
            if (derection == Enums.Derection.Left)
            {
                switch (_derection)
                {
                    case Enums.Derection.None:
                        break;
                    case Enums.Derection.Right:
                        _derection = Enums.Derection.Top;
                        break;
                    case Enums.Derection.Top:
                        _derection = Enums.Derection.Left;
                        break;
                    case Enums.Derection.Left:
                        _derection = Enums.Derection.Down;
                        break;
                    case Enums.Derection.Down:
                        _derection = Enums.Derection.Right;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else if (derection == Enums.Derection.Right)
            {
                switch (_derection)
                {
                    case Enums.Derection.None:
                        break;
                    case Enums.Derection.Right:
                        _derection = Enums.Derection.Down;
                        break;
                    case Enums.Derection.Top:
                        _derection = Enums.Derection.Right;
                        break;
                    case Enums.Derection.Left:
                        _derection = Enums.Derection.Top;
                        break;
                    case Enums.Derection.Down:
                        _derection = Enums.Derection.Left;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
        void ResetFontColor()
        {
            foreach (UserControl item in Codes)
            {
                if (item is UcMoveForward)
                {
                    var itemx = item as UcMoveForward;
                    itemx.ResetFontColor();
                }
                else if (item is UCLoop2)
                {
                    var itemx = item as UCLoop2;
                    itemx.ResetFontColor();
                }
                else if (item is UcTurn)
                {
                    var itemx = item as UcTurn;
                    itemx.ResetFontColor();
                }
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            btnLoadGame.PerformClick();
            btnPlay.PerformClick();
        }
        #endregion

        private void BtnInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_selectedGameObject.Instructions);
        }

        private void CmbGames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_useToSubmitDefault)
                this._selectedGameId = ((System.Collections.Generic.KeyValuePair<int, string>)cmbGames.SelectedItem).Key;
            btnLoadGame.PerformClick();
        }

        private async void TmrClock_Tick(object sender, EventArgs e)
        {
            _time--;
            if (_time <= 0)
            {
                tmrClock.Stop();
                MessageBox.Show("Times up.Click Okay to save solution");
                isGameStarted(false);
                await SaveGame();
            }
            else
            {
                SetClock();
            }
        }

        private void BtnGo_Click(object sender, EventArgs e)
        {
            if (!Helper.Confirm("Are you sure Start game"))
                return;
            isGameStarted(true);
            tmrClock.Start();
        }

        void isGameStarted(bool isStarted)
        {
            btnHint.Enabled = !isStarted;
            btnGo.Enabled = !isStarted;
        }

        void SetClock()
        {
            lblTime.Text = $"{_time}s";
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            await SaveGame();
        }

        async Task SaveGame()
        {
            try
            {
                if (Helper.Confirm("Do you need to save the game?"))
                {

                    var index = 0;
                    var playGames = new PlayGameModel(_selectedGameId);
                    Codes.ForEach(item =>
                    {
                        var codeType = GetCodeType(item, out var payload);
                        playGames.AddGameCode(index++, codeType, payload);
                    });
                    await _gameServiceRepository.CreateGamePlays(new Request<PlayGameModel>(playGames).SetToken());
                    MessageBox.Show("Saved");
                }
            }
            catch (Exception exception)
            {
                new ExceptionHandler(exception);
            }
        }

        private int GetCodeType(UserControl uc, out string payload)
        {
            payload = string.Empty;
            if (uc is UcFunction)
            {
                payload = (uc as UcFunction).GetPayload();
                return UcFunction.Identify;
            }
            else if (uc is UcLoop)
            {
                payload = (uc as UcLoop).GetPayload();
                return UcLoop.Identify;
            }
            else if (uc is UcMoveForward)
            {
                payload = (uc as UcMoveForward).GetPayload();
                return UcMoveForward.Identify;
            }
            else if (uc is UcTurn)
            {
                payload = (uc as UcTurn).GetPayload();
                return UcTurn.Identify;
            }
            else if (uc is UCLoop2)
            {
                payload = (uc as UCLoop2).GetPayload();
                return UCLoop2.Identify;
            }
            else
            {
                throw new ArgumentException("Invalid code");
            }
        }

        private async void BtnLoadPlayGame_Click(object sender, EventArgs e)
        {
            var playgameId = ((System.Collections.Generic.KeyValuePair<int, string>)cmbPlayGames.SelectedItem).Key;
            var result = await _gameServiceRepository.GetGamePlaysCode(
                new Request<int>(playgameId).SetToken());
              LoadPlayGame(result);
              btnReset.PerformClick();
        }

        private void LoadPlayGame(PlayGameModel playGameModel)
        {

            try
            {
                //if (!Helper.Confirm("Do you need to load the game"))
                //    return;

                ClearCode();
                var gameCodes = playGameModel.GameCodes.OrderBy(p => p.Order).ToList();

                for (var i = 2; i < gameCodes.Count; i++)
                {
                    var item = gameCodes[i];
                    var movex = new UserControl();
                    if (item.CodeType == UcMoveForward.Identify)
                    {
                        movex = new UcMoveForward(this)
                            .SetPayload(item.Payload.ToObject<Statement>());
                        codeIndex += UcMoveForward.Height;
                    }
                    else if (item.CodeType == UcTurn.Identify)
                    {
                        movex = new UcTurn(this).SetPayload(item.Payload.ToObject<Turn>());
                        codeIndex += UcTurn.Height;
                    }
                    else if (item.CodeType == UCLoop2.Identify)
                    {
                        movex = new UCLoop2(this).SetPayload(item.Payload.ToObject<Loop2>());
                        codeIndex += UCLoop2.Height;
                    }
                    else
                        throw new ArgumentException();

                    movex.Location = new Point(10, codeIndex);
                    codeCore.Controls.Add(movex);
                    Codes.Add(movex);
                }
            }
            catch (Exception exception)
            {
                new ExceptionHandler(exception);
            }
        }

        private async Task LoadSolution()
        {
            try
            {
                this._correctSolution = await _gameServiceRepository.GetGameSolution(new Request<int>(_selectedGameId).SetToken());
            }
            catch (Exception exception)
            {
                new ExceptionHandler(exception);
            }
        }
        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearCode();
        }

        void ClearCode()
        {
            try
            {
                if (Codes.Count > 2)
                    Codes.RemoveRange(2, Codes.Count - 2);
                var needToRemove = new List<Control>();
                for (var i = 0; i < codeCore.Controls.Count; i++)
                {
                    if (codeCore.Controls[i] is UcMoveForward || codeCore.Controls[i] is UcTurn
                        || codeCore.Controls[i] is UCLoop2)
                    {
                        needToRemove.Add(codeCore.Controls[i]);
                    }
                }
                needToRemove.ForEach(item => { codeCore.Controls.Remove(item); codeIndex -= 50; });
            }
            catch (Exception exception)
            {
                new ExceptionHandler(exception);
            }
        }

        private void BtnForcast_Click(object sender, EventArgs e)
        {
            var obj = new FrmForcasting(_gameServiceRepository,_selectedGameId);
            obj.ShowDialog();
        }

        private void BtnHint_Click(object sender, EventArgs e)
        {
            codeCore.Visible = false;
            LoadPlayGame(_correctSolution);
            btnPlay.PerformClick();
        }

        private async void CmbPlayGames_SelectedIndexChanged(object sender, EventArgs e)
        { 
        }

        private void CodeCore_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            ResetCode();
        }
    }
}