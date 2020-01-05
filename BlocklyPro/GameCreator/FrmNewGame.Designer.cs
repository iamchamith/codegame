namespace BlocklyPro.GameCreator
{
    partial class FrmNewGame
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnAddGame = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.NumericUpDown();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkIsPublish = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtTime)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(27, 32);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(185, 20);
            this.txtName.TabIndex = 0;
            // 
            // btnAddGame
            // 
            this.btnAddGame.Location = new System.Drawing.Point(357, 184);
            this.btnAddGame.Name = "btnAddGame";
            this.btnAddGame.Size = new System.Drawing.Size(75, 23);
            this.btnAddGame.TabIndex = 1;
            this.btnAddGame.Text = "CREATE";
            this.btnAddGame.UseVisualStyleBackColor = true;
            this.btnAddGame.Click += new System.EventHandler(this.btnAddGame_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name of the game";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Time to resolve (in minute)";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(28, 78);
            this.txtTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(101, 20);
            this.txtTime.TabIndex = 4;
            this.txtTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(30, 128);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(290, 79);
            this.txtDescription.TabIndex = 5;
            this.txtDescription.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Description";
            // 
            // chkIsPublish
            // 
            this.chkIsPublish.AutoSize = true;
            this.chkIsPublish.Location = new System.Drawing.Point(213, 81);
            this.chkIsPublish.Name = "chkIsPublish";
            this.chkIsPublish.Size = new System.Drawing.Size(60, 17);
            this.chkIsPublish.TabIndex = 7;
            this.chkIsPublish.Text = "Publish";
            this.chkIsPublish.UseVisualStyleBackColor = true;
            // 
            // FrmNewGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(444, 219);
            this.Controls.Add(this.chkIsPublish);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddGame);
            this.Controls.Add(this.txtName);
            this.Name = "FrmNewGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NEW GAME";
            this.Load += new System.EventHandler(this.FrmNewGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnAddGame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown txtTime;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkIsPublish;
    }
}