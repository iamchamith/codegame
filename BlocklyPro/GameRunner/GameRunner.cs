using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlocklyPro.Code;
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
        private int GameIndex = 1;
        private List<UserControl> Codes;
        private Enums.Derection _derection;
        private int X = 0;
        private int Y = 0;
        private UserControl _charactor;
        private int codeLine = 0;
        private int movePx;
        private int _selectedGameId = 0;
        private int _time = 1;
        private GameModel _selectedGameObject;
        public List<KeyValuePair<int, string>> _playGames = new List<KeyValuePair<int, string>>();

        public GameRunner(IGameServiceRepository gameServiceRepository)
        {
            _gameServiceRepository = gameServiceRepository;
            InitializeComponent();
        }

        public GameRunner(IGameServiceRepository gameServiceRepository, int gameIndex)
        {
            _gameServiceRepository = gameServiceRepository;
            InitializeComponent();
            GameIndex = gameIndex;
        }

        private async void GameRunner_Load(object sender, EventArgs e)
        {
            await LoadGames();
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
            codeIndex += 50;

            var move2 = new UcLoop();
            move2.Location = new Point(10, codeIndex);
            codeCore.Controls.Add(move2);
            Codes.Add(move2);
            codeIndex += 50;
        }

        private async void btnLoadGame_Click(object sender, System.EventArgs e)
        {
            try
            {
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
                var result = await _gameServiceRepository.GetPublishGames(new Request<bool>(false).SetToken());
                cmbGames.ComboBox.ValueMember = "key";
                cmbGames.ComboBox.DisplayMember = "value";
                cmbGames.ComboBox.DataSource = result;
                cmbGames.SelectedIndex = GameIndex;
                btnLoadGame.PerformClick();
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

        private int codeIndex = 0;

        private void sTATEMENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var move = new UcMoveForward(this);
            move.Location = new Point(20, codeIndex);
            codeCore.Controls.Add(move);
            Codes.Add(move);
            codeIndex += 50;
        }

        private void cONDITIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var move = new UcTurn(this);
            move.Location = new Point(20, codeIndex);
            codeCore.Controls.Add(move);
            Codes.Add(move);
            codeIndex += 100;
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
            foreach (UserControl item in Codes)
            {
                if (item is UcTurn)
                {
                    codeCore.Controls.Remove(item);
                    item.Location = new Point(20, codeIndex);
                    codeCore.Controls.Add(item);
                    codeIndex += 100;
                }
                else if (item is UcMoveForward)
                {
                    codeCore.Controls.Remove(item);
                    item.Location = new Point(20, codeIndex);
                    codeCore.Controls.Add(item);
                    codeIndex += 50;
                }
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            _derection = Enums.Derection.Right;
            ResetFontColor();
            codeLine = 0;
            movePx = 0;
            Run();
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
                else if (line is UcFunction || line is UcLoop)
                {
                    Run();
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                MessageBox.Show("Complete");
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
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            btnLoadGame.PerformClick();
            btnPlay.PerformClick();
        }

        private void lnkRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetCode();
        }

        private void BtnInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_selectedGameObject.Instructions);
        }

        private void CmbGames_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._selectedGameId = ((System.Collections.Generic.KeyValuePair<int, string>)cmbGames.SelectedItem).Key;
            btnLoadGame.PerformClick();
        }

        private void TmrClock_Tick(object sender, EventArgs e)
        {
            _time--;
            if (_time <= 0)
            {
                tmrClock.Stop();
                MessageBox.Show("Times up");
            }
            else
            {
                SetClock();
            }
        }

        private void BtnGo_Click(object sender, EventArgs e)
        {
            tmrClock.Start();
        }

        void SetClock()
        {
            lblTime.Text = $"{_time}s";
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Press Okay to save the game");
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
            else
            {
                throw new ArgumentException("Invalid code");
            }
        }

        private async void BtnLoadPlayGame_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Helper.Confirm("Do you need to load the game"))
                    return;

                btnClear.PerformClick();

                var result = await _gameServiceRepository.GetGamePlaysCode(
                    new Request<int>(((System.Collections.Generic.KeyValuePair<int, string>)cmbPlayGames.SelectedItem)
                        .Key).SetToken());

                var gameCodes = result.GameCodes.OrderBy(p => p.Order).ToList();

                for (int i = 2; i < gameCodes.Count; i++)
                {
                    var item = gameCodes[i];
                    var movex = item.CodeType == UcMoveForward.Identify ? new UcMoveForward(this)
                            .SetPayload(item.Payload.ToObject<Statement>()) :
                        item.CodeType == UcTurn.Identify ? new UcTurn(this).SetPayload(item.Payload.ToObject<Turn>()) :
                        throw new ArgumentException();
                    movex.Location = new Point(10, codeIndex);
                    codeCore.Controls.Add(movex);
                    Codes.Add(movex);
                    codeIndex += 50;
                }
            }
            catch (Exception exception)
            {
                new ExceptionHandler(exception);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (Codes.Count > 2)
                    Codes.RemoveRange(2, Codes.Count - 2);
                var needToRemove = new List<Control>();
                for (var i = 0; i < codeCore.Controls.Count; i++)
                {
                    if (codeCore.Controls[i] is UcMoveForward || codeCore.Controls[i] is UcTurn)
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
    }
}