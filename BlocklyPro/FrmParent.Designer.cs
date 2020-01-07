namespace BlocklyPro
{
    partial class FrmParent
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aCTIONSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblUser = new System.Windows.Forms.ToolStripMenuItem();
            this.lOGOUTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cREATEAGAMEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pLAYAGAMEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aCTIONSToolStripMenuItem,
            this.cREATEAGAMEToolStripMenuItem,
            this.pLAYAGAMEToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(745, 36);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aCTIONSToolStripMenuItem
            // 
            this.aCTIONSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUser,
            this.lOGOUTToolStripMenuItem});
            this.aCTIONSToolStripMenuItem.Image = global::BlocklyPro.Properties.Resources.iconfinder_Streamline_75_185095;
            this.aCTIONSToolStripMenuItem.Name = "aCTIONSToolStripMenuItem";
            this.aCTIONSToolStripMenuItem.Size = new System.Drawing.Size(121, 32);
            this.aCTIONSToolStripMenuItem.Text = "ACTIONS";
            // 
            // lblUser
            // 
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(180, 32);
            this.lblUser.Text = "User";
            // 
            // lOGOUTToolStripMenuItem
            // 
            this.lOGOUTToolStripMenuItem.Name = "lOGOUTToolStripMenuItem";
            this.lOGOUTToolStripMenuItem.Size = new System.Drawing.Size(180, 32);
            this.lOGOUTToolStripMenuItem.Text = "LOGOUT";
            this.lOGOUTToolStripMenuItem.Click += new System.EventHandler(this.LOGOUTToolStripMenuItem_Click);
            // 
            // cREATEAGAMEToolStripMenuItem
            // 
            this.cREATEAGAMEToolStripMenuItem.Image = global::BlocklyPro.Properties.Resources.code;
            this.cREATEAGAMEToolStripMenuItem.Name = "cREATEAGAMEToolStripMenuItem";
            this.cREATEAGAMEToolStripMenuItem.Size = new System.Drawing.Size(184, 32);
            this.cREATEAGAMEToolStripMenuItem.Text = "CREATE A GAME";
            this.cREATEAGAMEToolStripMenuItem.Click += new System.EventHandler(this.cREATEAGAMEToolStripMenuItem_Click);
            // 
            // pLAYAGAMEToolStripMenuItem
            // 
            this.pLAYAGAMEToolStripMenuItem.Image = global::BlocklyPro.Properties.Resources.play;
            this.pLAYAGAMEToolStripMenuItem.Name = "pLAYAGAMEToolStripMenuItem";
            this.pLAYAGAMEToolStripMenuItem.Size = new System.Drawing.Size(162, 32);
            this.pLAYAGAMEToolStripMenuItem.Text = "PLAY A GAME";
            this.pLAYAGAMEToolStripMenuItem.Click += new System.EventHandler(this.pLAYAGAMEToolStripMenuItem_Click);
            // 
            // FrmParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 261);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimizeBox = false;
            this.Name = "FrmParent";
            this.Text = "BLOCKLY PRO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cREATEAGAMEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pLAYAGAMEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aCTIONSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lOGOUTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lblUser;
    }
}