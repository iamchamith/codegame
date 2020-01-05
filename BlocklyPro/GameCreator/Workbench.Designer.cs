namespace BlocklyPro.GameCreator
{
    partial class Workbench
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Workbench));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnVerticalLine = new System.Windows.Forms.ToolStripButton();
            this.btnHorizontalLine = new System.Windows.Forms.ToolStripButton();
            this.btnChar = new System.Windows.Forms.ToolStripButton();
            this.btnTarget = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmbGames = new System.Windows.Forms.ToolStripComboBox();
            this.btnNewGame = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteGame = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnLoadGame = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.btnPlay = new System.Windows.Forms.ToolStripButton();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.btnUpdateGame = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnVerticalLine,
            this.btnHorizontalLine,
            this.btnChar,
            this.btnTarget,
            this.toolStripSeparator1,
            this.cmbGames,
            this.btnNewGame,
            this.btnUpdateGame,
            this.btnDeleteGame,
            this.toolStripSeparator2,
            this.btnSave,
            this.btnLoadGame,
            this.toolStripButton1,
            this.btnPlay});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(916, 32);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "Update this game";
            // 
            // btnVerticalLine
            // 
            this.btnVerticalLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVerticalLine.Name = "btnVerticalLine";
            this.btnVerticalLine.Size = new System.Drawing.Size(139, 29);
            this.btnVerticalLine.Text = "VERTICAL LINE";
            this.btnVerticalLine.Click += new System.EventHandler(this.btnVerticalLine_Click);
            // 
            // btnHorizontalLine
            // 
            this.btnHorizontalLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHorizontalLine.Name = "btnHorizontalLine";
            this.btnHorizontalLine.Size = new System.Drawing.Size(171, 29);
            this.btnHorizontalLine.Text = "HORIZONTAL LINE";
            this.btnHorizontalLine.Click += new System.EventHandler(this.btnHorizontalLine_Click);
            // 
            // btnChar
            // 
            this.btnChar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnChar.Name = "btnChar";
            this.btnChar.Size = new System.Drawing.Size(122, 29);
            this.btnChar.Text = "CHARACTOR";
            this.btnChar.Click += new System.EventHandler(this.btnChar_Click);
            // 
            // btnTarget
            // 
            this.btnTarget.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTarget.Name = "btnTarget";
            this.btnTarget.Size = new System.Drawing.Size(81, 29);
            this.btnTarget.Text = "TARGET";
            this.btnTarget.Click += new System.EventHandler(this.btnTarget_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // cmbGames
            // 
            this.cmbGames.Name = "cmbGames";
            this.cmbGames.Size = new System.Drawing.Size(121, 32);
            this.cmbGames.SelectedIndexChanged += new System.EventHandler(this.CmbGames_SelectedIndexChanged);
            this.cmbGames.Click += new System.EventHandler(this.CmbGames_Click);
            // 
            // btnNewGame
            // 
            this.btnNewGame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNewGame.Image = global::BlocklyPro.Properties.Resources.add;
            this.btnNewGame.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(23, 29);
            this.btnNewGame.Text = "Create a game";
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // btnDeleteGame
            // 
            this.btnDeleteGame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeleteGame.Image = global::BlocklyPro.Properties.Resources.deletegame;
            this.btnDeleteGame.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteGame.Name = "btnDeleteGame";
            this.btnDeleteGame.Size = new System.Drawing.Size(23, 29);
            this.btnDeleteGame.Text = "Delete Game";
            this.btnDeleteGame.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDeleteGame.Click += new System.EventHandler(this.btnDeleteGame_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 32);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::BlocklyPro.Properties.Resources.save2;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 29);
            this.btnSave.Text = "Save Workbench";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoadGame
            // 
            this.btnLoadGame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLoadGame.Image = global::BlocklyPro.Properties.Resources.load;
            this.btnLoadGame.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoadGame.Name = "btnLoadGame";
            this.btnLoadGame.Size = new System.Drawing.Size(23, 29);
            this.btnLoadGame.Text = "Reload game";
            this.btnLoadGame.Click += new System.EventHandler(this.btnLoadGame_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::BlocklyPro.Properties.Resources.delete;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 29);
            this.toolStripButton1.Text = "Delete Object";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPlay.Image = global::BlocklyPro.Properties.Resources.play;
            this.btnPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(23, 29);
            this.btnPlay.Text = "Play";
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Right;
            this.propertyGrid1.Location = new System.Drawing.Point(916, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(170, 533);
            this.propertyGrid1.TabIndex = 10;
            // 
            // btnUpdateGame
            // 
            this.btnUpdateGame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUpdateGame.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateGame.Image")));
            this.btnUpdateGame.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdateGame.Name = "btnUpdateGame";
            this.btnUpdateGame.Size = new System.Drawing.Size(23, 29);
            this.btnUpdateGame.Text = "toolStripButton2";
            this.btnUpdateGame.Click += new System.EventHandler(this.BtnUpdateGame_Click);
            // 
            // Workbench
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BlocklyPro.Properties.Resources.grid;
            this.ClientSize = new System.Drawing.Size(1086, 533);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.propertyGrid1);
            this.Name = "Workbench";
            this.Text = "Workbench";
            this.Load += new System.EventHandler(this.Workbench_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Workbench_KeyDown);
            this.MouseEnter += new System.EventHandler(this.Workbench_MouseEnter);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Workbench_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Workbench_MouseUp);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnVerticalLine;
        private System.Windows.Forms.ToolStripButton btnHorizontalLine;
        private System.Windows.Forms.ToolStripButton btnTarget;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.ToolStripButton btnChar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripComboBox cmbGames;
        private System.Windows.Forms.ToolStripButton btnLoadGame;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton btnPlay;
        private System.Windows.Forms.ToolStripButton btnNewGame;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnDeleteGame;
        private System.Windows.Forms.ToolStripButton btnUpdateGame;
    }
}