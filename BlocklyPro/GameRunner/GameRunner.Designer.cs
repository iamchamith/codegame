namespace BlocklyPro.GameRunner
{
    partial class GameRunner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameRunner));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmbGames = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.sTATEMENTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cONDITIONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fUNCTIONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lOOPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLoadGame = new System.Windows.Forms.ToolStripButton();
            this.btnPlay = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnInfo = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.btnGo = new System.Windows.Forms.ToolStripButton();
            this.lblTime = new System.Windows.Forms.ToolStripLabel();
            this.codeCore = new System.Windows.Forms.Panel();
            this.lnkRefresh = new System.Windows.Forms.LinkLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tmrClock = new System.Windows.Forms.Timer(this.components);
            this.cmbPlayGames = new System.Windows.Forms.ToolStripComboBox();
            this.btnClear = new System.Windows.Forms.ToolStripButton();
            this.btnLoadPlayGame = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.codeCore.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.cmbGames,
            this.toolStripDropDownButton1,
            this.btnLoadGame,
            this.btnPlay,
            this.toolStripButton1,
            this.btnSave,
            this.btnInfo,
            this.btnClear,
            this.toolStripLabel1,
            this.btnGo,
            this.lblTime,
            this.btnLoadPlayGame,
            this.cmbPlayGames});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1218, 28);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // cmbGames
            // 
            this.cmbGames.Name = "cmbGames";
            this.cmbGames.Size = new System.Drawing.Size(121, 28);
            this.cmbGames.SelectedIndexChanged += new System.EventHandler(this.CmbGames_SelectedIndexChanged);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sTATEMENTToolStripMenuItem,
            this.cONDITIONToolStripMenuItem,
            this.fUNCTIONToolStripMenuItem,
            this.lOOPToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::BlocklyPro.Properties.Resources.code;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 25);
            this.toolStripDropDownButton1.Text = "Code";
            // 
            // sTATEMENTToolStripMenuItem
            // 
            this.sTATEMENTToolStripMenuItem.Name = "sTATEMENTToolStripMenuItem";
            this.sTATEMENTToolStripMenuItem.Size = new System.Drawing.Size(185, 30);
            this.sTATEMENTToolStripMenuItem.Text = "STATEMENT";
            this.sTATEMENTToolStripMenuItem.Click += new System.EventHandler(this.sTATEMENTToolStripMenuItem_Click);
            // 
            // cONDITIONToolStripMenuItem
            // 
            this.cONDITIONToolStripMenuItem.Name = "cONDITIONToolStripMenuItem";
            this.cONDITIONToolStripMenuItem.Size = new System.Drawing.Size(185, 30);
            this.cONDITIONToolStripMenuItem.Text = "CONDITION";
            this.cONDITIONToolStripMenuItem.Click += new System.EventHandler(this.cONDITIONToolStripMenuItem_Click);
            // 
            // fUNCTIONToolStripMenuItem
            // 
            this.fUNCTIONToolStripMenuItem.Enabled = false;
            this.fUNCTIONToolStripMenuItem.Name = "fUNCTIONToolStripMenuItem";
            this.fUNCTIONToolStripMenuItem.Size = new System.Drawing.Size(185, 30);
            this.fUNCTIONToolStripMenuItem.Text = "FUNCTION";
            // 
            // lOOPToolStripMenuItem
            // 
            this.lOOPToolStripMenuItem.Enabled = false;
            this.lOOPToolStripMenuItem.Name = "lOOPToolStripMenuItem";
            this.lOOPToolStripMenuItem.Size = new System.Drawing.Size(185, 30);
            this.lOOPToolStripMenuItem.Text = "LOOP";
            // 
            // btnLoadGame
            // 
            this.btnLoadGame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLoadGame.Image = global::BlocklyPro.Properties.Resources.load;
            this.btnLoadGame.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoadGame.Name = "btnLoadGame";
            this.btnLoadGame.Size = new System.Drawing.Size(23, 25);
            this.btnLoadGame.Text = "Reload";
            this.btnLoadGame.Click += new System.EventHandler(this.btnLoadGame_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPlay.Image = global::BlocklyPro.Properties.Resources.play;
            this.btnPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(23, 25);
            this.btnPlay.Text = "Play";
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::BlocklyPro.Properties.Resources.reset;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 25);
            this.toolStripButton1.Text = "Refresh";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::BlocklyPro.Properties.Resources.save;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 25);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnInfo.Image")));
            this.btnInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(23, 25);
            this.btnInfo.Text = "Instractions";
            this.btnInfo.Click += new System.EventHandler(this.BtnInfo_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(17, 25);
            this.toolStripLabel1.Text = "|";
            this.toolStripLabel1.ToolTipText = "|";
            // 
            // btnGo
            // 
            this.btnGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGo.Image = ((System.Drawing.Image)(resources.GetObject("btnGo.Image")));
            this.btnGo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(23, 25);
            this.btnGo.Text = "Go";
            this.btnGo.Click += new System.EventHandler(this.BtnGo_Click);
            // 
            // lblTime
            // 
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(40, 25);
            this.lblTime.Text = "00s";
            // 
            // codeCore
            // 
            this.codeCore.Controls.Add(this.lnkRefresh);
            this.codeCore.Dock = System.Windows.Forms.DockStyle.Right;
            this.codeCore.Location = new System.Drawing.Point(822, 28);
            this.codeCore.Name = "codeCore";
            this.codeCore.Size = new System.Drawing.Size(396, 505);
            this.codeCore.TabIndex = 11;
            // 
            // lnkRefresh
            // 
            this.lnkRefresh.AutoSize = true;
            this.lnkRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkRefresh.Location = new System.Drawing.Point(310, 14);
            this.lnkRefresh.Name = "lnkRefresh";
            this.lnkRefresh.Size = new System.Drawing.Size(65, 13);
            this.lnkRefresh.TabIndex = 0;
            this.lnkRefresh.TabStop = true;
            this.lnkRefresh.Text = "REFRESH";
            this.lnkRefresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRefresh_LinkClicked);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tmrClock
            // 
            this.tmrClock.Interval = 1000;
            this.tmrClock.Tick += new System.EventHandler(this.TmrClock_Tick);
            // 
            // cmbPlayGames
            // 
            this.cmbPlayGames.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmbPlayGames.Name = "cmbPlayGames";
            this.cmbPlayGames.Size = new System.Drawing.Size(121, 28);
            // 
            // btnClear
            // 
            this.btnClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(23, 25);
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // btnLoadPlayGame
            // 
            this.btnLoadPlayGame.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnLoadPlayGame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLoadPlayGame.Image = global::BlocklyPro.Properties.Resources.load;
            this.btnLoadPlayGame.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoadPlayGame.Name = "btnLoadPlayGame";
            this.btnLoadPlayGame.Size = new System.Drawing.Size(23, 25);
            this.btnLoadPlayGame.Text = "Load play game";
            this.btnLoadPlayGame.Click += new System.EventHandler(this.BtnLoadPlayGame_Click);
            // 
            // GameRunner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BlocklyPro.Properties.Resources.grid;
            this.ClientSize = new System.Drawing.Size(1218, 533);
            this.Controls.Add(this.codeCore);
            this.Controls.Add(this.toolStrip1);
            this.Name = "GameRunner";
            this.Text = "GAME RUNNER";
            this.Load += new System.EventHandler(this.GameRunner_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.codeCore.ResumeLayout(false);
            this.codeCore.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox cmbGames;
        private System.Windows.Forms.ToolStripButton btnLoadGame;
        private System.Windows.Forms.ToolStripButton btnPlay;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem sTATEMENTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cONDITIONToolStripMenuItem;
        private System.Windows.Forms.Panel codeCore;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem fUNCTIONToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lOOPToolStripMenuItem;
        private System.Windows.Forms.LinkLabel lnkRefresh;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnInfo;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton btnGo;
        private System.Windows.Forms.ToolStripLabel lblTime;
        private System.Windows.Forms.Timer tmrClock;
        private System.Windows.Forms.ToolStripButton btnClear;
        private System.Windows.Forms.ToolStripComboBox cmbPlayGames;
        private System.Windows.Forms.ToolStripButton btnLoadPlayGame;
    }
}