using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlocklyPro.GameTools;
using BlocklyPro.Models;
using BlocklyPro.Utility;
using BlocklyPro.ServiceRepository;
namespace BlocklyPro.GameCreator
{
    public partial class Workbench : Form
    {
        private readonly IGameServiceRepository _gameServiceRepository;

        #region attributs

        const int DRAG_HANDLE_SIZE = 7;
        int mouseX, mouseY;
        Control SelectedControl;
        Direction direction;
        Point newLocation;
        Size newSize;
        private int id = -1;
        int index;
        Control MouseClickedControl;
        private int _selectedGame = 0;
        enum Direction
        {
            NW,
            N,
            NE,
            W,
            E,
            SW,
            S,
            SE,
            None
        }

        #endregion

        public Workbench(IGameServiceRepository gameServiceRepository)
        {
            _gameServiceRepository = gameServiceRepository;
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private async void Workbench_Load(object sender, EventArgs e)
        {
            timer1.Start();
            await LoadGames();
        }

        #region events

        private void control_MouseEnter(object sender, EventArgs e)
        {
            timer1.Stop();
            Cursor = Cursors.SizeAll;
        }

        private void control_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            timer1.Start();
        }

        private void control_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Invalidate(); //unselect other control
                SelectedControl = (Control)sender;
                Control control = (Control)sender;
                mouseX = -e.X;
                mouseY = -e.Y;
                control.Invalidate();
                DrawControlBorder(sender);
                propertyGrid1.SelectedObject = SelectedControl;
            }
        }

        private void control_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Control control = (Control)sender;
                Point nextPosition = new Point();
                nextPosition = PointToClient(MousePosition);
                nextPosition.Offset(mouseX, mouseY);
                control.Location = nextPosition;
                Invalidate();
            }
        }

        private void control_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Control control = (Control)sender;
                Cursor.Clip = Rectangle.Empty;
                control.Invalidate();
                DrawControlBorder(control);
            }
        }

        private void control_keyDown(object sender, KeyEventArgs e)
        {
            Control objWall = (Control)sender;

            int x = 0, y = 0;

            if (e.KeyData == Keys.D)
            {
                x = objWall.Location.X;
                y = objWall.Location.Y;
                x++;
            }
            else if (e.KeyData == Keys.A)
            {

                x = objWall.Location.X;
                y = objWall.Location.Y;
                x--;

            }
            else if (e.KeyData == Keys.W)
            {
                y = objWall.Location.Y;
                x = objWall.Location.X;
                y--;
            }
            else if (e.KeyData == Keys.S)
            {
                y = objWall.Location.Y;
                x = objWall.Location.X;
                y++;
            }
            else
            {
                y = objWall.Location.Y;
                x = objWall.Location.X;
            }

            Point pt = new Point(x, y);
            objWall.Location = pt;

        }

        private void DrawControlBorder(object sender)
        {
            Control control = (Control)sender;
            //define the border to be drawn, it will be offset by DRAG_HANDLE_SIZE / 2
            //around the control, so when the drag handles are drawn they will be seem
            //connected in the middle.
            Rectangle Border = new Rectangle(
                new Point(control.Location.X - DRAG_HANDLE_SIZE / 2,
                    control.Location.Y - DRAG_HANDLE_SIZE / 2),
                new Size(control.Size.Width + DRAG_HANDLE_SIZE,
                    control.Size.Height + DRAG_HANDLE_SIZE));
            //define the 8 drag handles, that has the size of DRAG_HANDLE_SIZE
            Rectangle NW = new Rectangle(
                new Point(control.Location.X - DRAG_HANDLE_SIZE,
                    control.Location.Y - DRAG_HANDLE_SIZE),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle N = new Rectangle(
                new Point(control.Location.X + control.Width / 2 - DRAG_HANDLE_SIZE / 2,
                    control.Location.Y - DRAG_HANDLE_SIZE),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle NE = new Rectangle(
                new Point(control.Location.X + control.Width,
                    control.Location.Y - DRAG_HANDLE_SIZE),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle W = new Rectangle(
                new Point(control.Location.X - DRAG_HANDLE_SIZE,
                    control.Location.Y + control.Height / 2 - DRAG_HANDLE_SIZE / 2),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle E = new Rectangle(
                new Point(control.Location.X + control.Width,
                    control.Location.Y + control.Height / 2 - DRAG_HANDLE_SIZE / 2),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle SW = new Rectangle(
                new Point(control.Location.X - DRAG_HANDLE_SIZE,
                    control.Location.Y + control.Height),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle S = new Rectangle(
                new Point(control.Location.X + control.Width / 2 - DRAG_HANDLE_SIZE / 2,
                    control.Location.Y + control.Height),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle SE = new Rectangle(
                new Point(control.Location.X + control.Width,
                    control.Location.Y + control.Height),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));

            //get the form graphic
            Graphics g = CreateGraphics();
            //draw the border and drag handles
            ControlPaint.DrawBorder(g, Border, Color.Gray, ButtonBorderStyle.Dotted);
            ControlPaint.DrawGrabHandle(g, NW, true, true);
            ControlPaint.DrawGrabHandle(g, N, true, true);
            ControlPaint.DrawGrabHandle(g, NE, true, true);
            ControlPaint.DrawGrabHandle(g, W, true, true);
            ControlPaint.DrawGrabHandle(g, E, true, true);
            ControlPaint.DrawGrabHandle(g, SW, true, true);
            ControlPaint.DrawGrabHandle(g, S, true, true);
            ControlPaint.DrawGrabHandle(g, SE, true, true);
            g.Dispose();
        }


        #endregion

        #region form events

        private void Workbench_MouseMove(object sender, MouseEventArgs e)
        {
            if (SelectedControl != null && e.Button == MouseButtons.Left)
            {
                timer1.Stop();
                Invalidate();

                if (SelectedControl.Height < 20)
                {
                    SelectedControl.Height = 20;
                    direction = Direction.None;
                    Cursor = Cursors.Default;
                    return;
                }

                if (SelectedControl.Width < 20)
                {
                    SelectedControl.Width = 20;
                    direction = Direction.None;
                    Cursor = Cursors.Default;
                    return;
                }

                //get the current mouse position relative the the app
                Point pos = PointToClient(MousePosition);

                #region resize the control in 8 directions

                if (direction == Direction.NW)
                {
                    //north west, location and width, height change
                    newLocation = new Point(pos.X, pos.Y);
                    newSize = new Size(SelectedControl.Size.Width - (newLocation.X - SelectedControl.Location.X),
                        SelectedControl.Size.Height - (newLocation.Y - SelectedControl.Location.Y));
                    SelectedControl.Location = newLocation;
                    SelectedControl.Size = newSize;
                }
                else if (direction == Direction.SE)
                {
                    //south east, width and height change
                    newLocation = new Point(pos.X, pos.Y);
                    newSize = new Size(
                        SelectedControl.Size.Width +
                        (newLocation.X - SelectedControl.Size.Width - SelectedControl.Location.X),
                        SelectedControl.Height + (newLocation.Y - SelectedControl.Height - SelectedControl.Location.Y));
                    SelectedControl.Size = newSize;
                }
                else if (direction == Direction.N)
                {
                    //north, location and height change
                    newLocation = new Point(SelectedControl.Location.X, pos.Y);
                    newSize = new Size(SelectedControl.Width,
                        SelectedControl.Height - (pos.Y - SelectedControl.Location.Y));
                    SelectedControl.Location = newLocation;
                    SelectedControl.Size = newSize;
                }
                else if (direction == Direction.S)
                {
                    //south, only the height changes
                    newLocation = new Point(pos.X, pos.Y);
                    newSize = new Size(SelectedControl.Width,
                        pos.Y - SelectedControl.Location.Y);
                    SelectedControl.Size = newSize;
                }
                else if (direction == Direction.W)
                {
                    //west, location and width will change
                    newLocation = new Point(pos.X, SelectedControl.Location.Y);
                    newSize = new Size(SelectedControl.Width - (pos.X - SelectedControl.Location.X),
                        SelectedControl.Height);
                    SelectedControl.Location = newLocation;
                    SelectedControl.Size = newSize;
                }
                else if (direction == Direction.E)
                {
                    //east, only width changes
                    newLocation = new Point(pos.X, pos.Y);
                    newSize = new Size(pos.X - SelectedControl.Location.X,
                        SelectedControl.Height);
                    SelectedControl.Size = newSize;
                }
                else if (direction == Direction.SW)
                {
                    //south west, location, width and height change
                    newLocation = new Point(pos.X, SelectedControl.Location.Y);
                    newSize = new Size(SelectedControl.Width - (pos.X - SelectedControl.Location.X),
                        pos.Y - SelectedControl.Location.Y);
                    SelectedControl.Location = newLocation;
                    SelectedControl.Size = newSize;
                }
                else if (direction == Direction.NE)
                {
                    //north east, location, width and height change
                    newLocation = new Point(SelectedControl.Location.X, pos.Y);
                    newSize = new Size(pos.X - SelectedControl.Location.X,
                        SelectedControl.Height - (pos.Y - SelectedControl.Location.Y));
                    SelectedControl.Location = newLocation;
                    SelectedControl.Size = newSize;
                }

                #endregion
            }
        }

        private void Workbench_MouseUp(object sender, MouseEventArgs e)
        {
            if (SelectedControl != null)
                DrawControlBorder(SelectedControl);
            timer1.Start();
        }

        private void Workbench_MouseEnter(object sender, EventArgs e)
        {
        }

        private void Workbench_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && SelectedControl != null)
            {
                Controls.Remove(SelectedControl);
                propertyGrid1.SelectedObject = null;
                Invalidate();
            }
        }


        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            #region Get the direction and display correct cursor

            if (SelectedControl != null)
            {
                Point pos = PointToClient(MousePosition);
                //check if the mouse cursor is within the drag handle
                if ((pos.X >= SelectedControl.Location.X - DRAG_HANDLE_SIZE &&
                     pos.X <= SelectedControl.Location.X) &&
                    (pos.Y >= SelectedControl.Location.Y - DRAG_HANDLE_SIZE &&
                     pos.Y <= SelectedControl.Location.Y))
                {
                    direction = Direction.NW;
                    Cursor = Cursors.SizeNWSE;
                }
                else if ((pos.X >= SelectedControl.Location.X + SelectedControl.Width &&
                          pos.X <= SelectedControl.Location.X + SelectedControl.Width + DRAG_HANDLE_SIZE &&
                          pos.Y >= SelectedControl.Location.Y + SelectedControl.Height &&
                          pos.Y <= SelectedControl.Location.Y + SelectedControl.Height + DRAG_HANDLE_SIZE))
                {
                    direction = Direction.SE;
                    Cursor = Cursors.SizeNWSE;
                }
                else if ((pos.X >= SelectedControl.Location.X + SelectedControl.Width / 2 - DRAG_HANDLE_SIZE / 2) &&
                         pos.X <= SelectedControl.Location.X + SelectedControl.Width / 2 + DRAG_HANDLE_SIZE / 2 &&
                         pos.Y >= SelectedControl.Location.Y - DRAG_HANDLE_SIZE &&
                         pos.Y <= SelectedControl.Location.Y)
                {
                    direction = Direction.N;
                    Cursor = Cursors.SizeNS;
                }
                else if ((pos.X >= SelectedControl.Location.X + SelectedControl.Width / 2 - DRAG_HANDLE_SIZE / 2) &&
                         pos.X <= SelectedControl.Location.X + SelectedControl.Width / 2 + DRAG_HANDLE_SIZE / 2 &&
                         pos.Y >= SelectedControl.Location.Y + SelectedControl.Height &&
                         pos.Y <= SelectedControl.Location.Y + SelectedControl.Height + DRAG_HANDLE_SIZE)
                {
                    direction = Direction.S;
                    Cursor = Cursors.SizeNS;
                }
                else if ((pos.X >= SelectedControl.Location.X - DRAG_HANDLE_SIZE &&
                          pos.X <= SelectedControl.Location.X &&
                          pos.Y >= SelectedControl.Location.Y + SelectedControl.Height / 2 - DRAG_HANDLE_SIZE / 2 &&
                          pos.Y <= SelectedControl.Location.Y + SelectedControl.Height / 2 + DRAG_HANDLE_SIZE / 2))
                {
                    direction = Direction.W;
                    Cursor = Cursors.SizeWE;
                }
                else if ((pos.X >= SelectedControl.Location.X + SelectedControl.Width &&
                          pos.X <= SelectedControl.Location.X + SelectedControl.Width + DRAG_HANDLE_SIZE &&
                          pos.Y >= SelectedControl.Location.Y + SelectedControl.Height / 2 - DRAG_HANDLE_SIZE / 2 &&
                          pos.Y <= SelectedControl.Location.Y + SelectedControl.Height / 2 + DRAG_HANDLE_SIZE / 2))
                {
                    direction = Direction.E;
                    Cursor = Cursors.SizeWE;
                }
                else if ((pos.X >= SelectedControl.Location.X + SelectedControl.Width &&
                          pos.X <= SelectedControl.Location.X + SelectedControl.Width + DRAG_HANDLE_SIZE) &&
                         (pos.Y >= SelectedControl.Location.Y - DRAG_HANDLE_SIZE &&
                          pos.Y <= SelectedControl.Location.Y))
                {
                    direction = Direction.NE;
                    Cursor = Cursors.SizeNESW;
                }
                else if ((pos.X >= SelectedControl.Location.X - DRAG_HANDLE_SIZE &&
                          pos.X <= SelectedControl.Location.X + DRAG_HANDLE_SIZE) &&
                         (pos.Y >= SelectedControl.Location.Y + SelectedControl.Height - DRAG_HANDLE_SIZE &&
                          pos.Y <= SelectedControl.Location.Y + SelectedControl.Height + DRAG_HANDLE_SIZE))
                {
                    direction = Direction.SW;
                    Cursor = Cursors.SizeNESW;
                }
                else
                {
                    Cursor = Cursors.Default;
                    direction = Direction.None;
                }
            }
            else
            {
                direction = Direction.None;
                Cursor = Cursors.Default;
            }

            #endregion
        }

        private void btnVerticalLine_Click(object sender, EventArgs e)
        {
            var ctrl = new UCVerticalLine();
            ctrl.Location = new Point(50, 50);
            ctrl.Name = "ucVerticalLine_" + index;
            ctrl.MouseEnter += control_MouseEnter;
            ctrl.MouseLeave += control_MouseLeave;
            ctrl.MouseDown += control_MouseDown;
            ctrl.MouseMove += control_MouseMove;
            ctrl.MouseUp += control_MouseUp;
            ctrl.KeyDown += control_keyDown;
            ctrl.MouseClick += CtrlOnMouseClick;
            Controls.Add(ctrl);
            index++;
        }

        private void btnChar_Click(object sender, EventArgs e)
        {
            if (CheckUcIsThere("ucChar_"))
            {
                MessageBox.Show("This object already on workbench");
                return;
            }

            var ctrl = new UCCharactor();
            ctrl.Location = new Point(50, 50);
            ctrl.Name = "ucChar_" + index;
            ctrl.MouseEnter += control_MouseEnter;
            ctrl.MouseLeave += control_MouseLeave;
            ctrl.MouseDown += control_MouseDown;
            ctrl.MouseMove += control_MouseMove;
            ctrl.MouseUp += control_MouseUp;
            ctrl.KeyDown += control_keyDown;
            ctrl.MouseClick += CtrlOnMouseClick;
            Controls.Add(ctrl);
            index++;
        }

        private void btnTarget_Click(object sender, EventArgs e)
        {
            if (CheckUcIsThere("ucTarget_"))
            {
                MessageBox.Show("This object already on workbench");
                return;
            }
            var ctrl = new UCTarget();
            ctrl.Location = new Point(50, 50);
            ctrl.Name = "ucTarget_" + index;
            ctrl.MouseEnter += control_MouseEnter;
            ctrl.MouseLeave += control_MouseLeave;
            ctrl.MouseDown += control_MouseDown;
            ctrl.MouseMove += control_MouseMove;
            ctrl.MouseUp += control_MouseUp;
            ctrl.KeyDown += control_keyDown;
            ctrl.MouseClick += CtrlOnMouseClick;
            Controls.Add(ctrl);
            index++;
        }

        private void btnHorizontalLine_Click(object sender, EventArgs e)
        {
            var ctrl = new UCHorizontalLine();
            ctrl.Location = new Point(50, 50);
            ctrl.Name = "ucHorizontalLine_" + index;
            ctrl.MouseEnter += control_MouseEnter;
            ctrl.MouseLeave += control_MouseLeave;
            ctrl.MouseDown += control_MouseDown;
            ctrl.MouseMove += control_MouseMove;
            ctrl.MouseUp += control_MouseUp;
            ctrl.KeyDown += control_keyDown;
            ctrl.MouseClick += CtrlOnMouseClick;
            Controls.Add(ctrl);
            index++;
        }

        private void CtrlOnMouseClick(object sender, MouseEventArgs mouseEventArgs)
        {
            MouseClickedControl = (Control)sender;

        }


        private async void btnSave_Click(object sender, EventArgs e)
        {
            var gameId = ((System.Collections.Generic.KeyValuePair<int, string>)cmbGames.SelectedItem).Key;
            var gameMap = new List<GameMapModel>();
            Enums.ControllerType type;
            foreach (Control item in Controls)
            {
                UserControl itemx;
                if (item.Name.StartsWith("ucHorizontalLine_"))
                {
                    itemx = item as UCHorizontalLine;
                    type = Enums.ControllerType.HorizontalLine;
                }
                else if (item.Name.StartsWith("ucVerticalLine_"))
                {
                    itemx = item as UCVerticalLine;
                    type = Enums.ControllerType.VerticalLine;
                }
                else if (item.Name.StartsWith("ucTarget_"))
                {
                    itemx = item as UCTarget;
                    type = Enums.ControllerType.Target;
                }
                else if (item.Name.StartsWith("ucChar_"))
                {
                    itemx = item as UCCharactor;
                    type = Enums.ControllerType.Charactor;
                }
                else
                {
                    continue;
                }

                gameMap.Add(new GameMapModel
                {
                    ControllerType = type,
                    GameId = gameId,
                    Height = itemx.Height,
                    Width = itemx.Width,
                    PointX = itemx.Location.X,
                    PointY = itemx.Location.Y
                });
            }

            try
            {
                await _gameServiceRepository.SaveGameMap(new Request<int, List<GameMapModel>>(gameId, gameMap).SetToken());
                MessageBox.Show("Saved");
            }
            catch (Exception ex)
            {
                Helper.Error(ex: ex);
            }
        }

        private async void btnLoadGame_Click(object sender, EventArgs e)
        {
  
            var result = new List<GameMapModel>();
            try
            {
                result = await _gameServiceRepository.GetGameMap(new Request<int>(_selectedGame).SetToken());
            }
            catch (Exception ex)
            {
                Helper.Error(ex: ex);
                return;
            }
            RemoveItems();
            var name = string.Empty;
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
                        break;
                    case Enums.ControllerType.Target:
                        ctrl = new UCTarget();
                        name = "ucTarget_";
                        break;
                    default:
                        continue;
                }
                ctrl.Name = $"{name}{index}";
                ctrl.MouseEnter += control_MouseEnter;
                ctrl.MouseLeave += control_MouseLeave;
                ctrl.MouseDown += control_MouseDown;
                ctrl.MouseMove += control_MouseMove;
                ctrl.MouseUp += control_MouseUp;
                ctrl.KeyDown += control_keyDown;
                ctrl.MouseClick += CtrlOnMouseClick;
                ctrl.Location = new Point(item.PointX, item.PointY);
                ctrl.Size = new Size(item.Width, item.Height);
                Controls.Add(ctrl);
                index++;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (Helper.Confirm("Delete", "Delete?"))
            {
                Controls.Remove(MouseClickedControl);
            }
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            var createNewGame = new FrmNewGame(this, _gameServiceRepository);
            createNewGame.ShowDialog();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            var runner = new GameRunner.GameRunner(_gameServiceRepository, _selectedGame);
            runner.ShowDialog();
        }
        private async void btnDeleteGame_Click(object sender, EventArgs e)
        {
            if (Helper.Confirm("Do you want to delete this game?"))
            {
                try
                {
                    var gameItem = (System.Collections.Generic.KeyValuePair<int, string>)cmbGames.SelectedItem;
                    await _gameServiceRepository.DeleteGame(new Request<int>(gameItem.Key).SetToken());
                    await LoadGames();
                    MessageBox.Show("Deleted");
                }
                catch (Exception ex)
                {
                    Helper.Error(ex: ex);
                }
            }
        }
        #region private

        public async Task LoadGames()
        {
            try
            {
                var result = await _gameServiceRepository.GetMyGames(new Request<bool>(false).SetToken());
                cmbGames.ComboBox.ValueMember = "key";
                cmbGames.ComboBox.DisplayMember = "value";
                cmbGames.ComboBox.DataSource = result;
                btnLoadGame.PerformClick();
            }
            catch (Exception e)
            {
                Helper.Error(ex: e);
            }
        }

        private void RemoveItems()
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
            for (var i = 0; i < indexx; i++)
            {
                Controls.Remove(mustRemove[i]);
            }
        }

        private void BtnUpdateGame_Click(object sender, EventArgs e)
        {
            var createNewGame = new FrmNewGame(this, _gameServiceRepository, _selectedGame);
            createNewGame.ShowDialog();
        }

        private void CmbGames_Click(object sender, EventArgs e)
        {

        }

        private void CmbGames_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._selectedGame = ((System.Collections.Generic.KeyValuePair<int, string>)cmbGames.SelectedItem).Key;
            btnLoadGame.PerformClick();
        }

        private bool CheckUcIsThere(string controllerName)
        {
            foreach (Control item in Controls)
            {

                if (item.Name.StartsWith(controllerName, StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }


        #endregion
    }
}
