namespace BlocklyPro.Code
{
    partial class UCLoop2
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblForStatement = new System.Windows.Forms.Label();
            this.lblFor1 = new System.Windows.Forms.Label();
            this.txtSteps = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.txtSteps)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInfo
            // 
            this.btnInfo.BackgroundImage = global::BlocklyPro.Properties.Resources.info;
            this.btnInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInfo.Location = new System.Drawing.Point(300, 24);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(26, 23);
            this.btnInfo.TabIndex = 9;
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = global::BlocklyPro.Properties.Resources.delete;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.Location = new System.Drawing.Point(300, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(26, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // lblForStatement
            // 
            this.lblForStatement.AutoSize = true;
            this.lblForStatement.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblForStatement.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForStatement.Location = new System.Drawing.Point(46, 47);
            this.lblForStatement.Name = "lblForStatement";
            this.lblForStatement.Size = new System.Drawing.Size(248, 20);
            this.lblForStatement.TabIndex = 7;
            this.lblForStatement.Text = "MOVE ONE STEP FORWARD";
            // 
            // lblFor1
            // 
            this.lblFor1.AutoSize = true;
            this.lblFor1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFor1.Location = new System.Drawing.Point(3, 17);
            this.lblFor1.Name = "lblFor1";
            this.lblFor1.Size = new System.Drawing.Size(164, 20);
            this.lblFor1.TabIndex = 12;
            this.lblFor1.Text = "FOR ( 0 <       ; I++)";
            // 
            // txtSteps
            // 
            this.txtSteps.Location = new System.Drawing.Point(90, 17);
            this.txtSteps.Name = "txtSteps";
            this.txtSteps.Size = new System.Drawing.Size(36, 20);
            this.txtSteps.TabIndex = 13;
            this.txtSteps.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // UCLoop2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.txtSteps);
            this.Controls.Add(this.lblFor1);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblForStatement);
            this.Name = "UCLoop2";
            this.Size = new System.Drawing.Size(329, 100);
            ((System.ComponentModel.ISupportInitialize)(this.txtSteps)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblForStatement;
        private System.Windows.Forms.Label lblFor1;
        private System.Windows.Forms.NumericUpDown txtSteps;
    }
}
