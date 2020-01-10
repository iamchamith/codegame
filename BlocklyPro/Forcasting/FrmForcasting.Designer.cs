namespace BlocklyPro.Forcasting
{
    partial class FrmForcasting
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
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.cmdARS = new System.Windows.Forms.Button();
            this.cmdES = new System.Windows.Forms.Button();
            this.cmdWMA = new System.Windows.Forms.Button();
            this.cmdSMA = new System.Windows.Forms.Button();
            this.cmdNaive = new System.Windows.Forms.Button();
            this.lblMeanSquaredError = new System.Windows.Forms.Label();
            this.lblTrackingSignal = new System.Windows.Forms.Label();
            this.lblMeanAbsolutePercentError = new System.Windows.Forms.Label();
            this.lblMeanPercentError = new System.Windows.Forms.Label();
            this.lblMeanAbsoluteDeviation = new System.Windows.Forms.Label();
            this.lblMeanSignedDeviaiton = new System.Windows.Forms.Label();
            this.grdResults = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdResults)).BeginInit();
            this.SuspendLayout();
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(132, 82);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(42, 13);
            this.Label2.TabIndex = 60;
            this.Label2.Text = "Results";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(16, 82);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(61, 13);
            this.Label1.TabIndex = 59;
            this.Label1.Text = "Input (CSV)";
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(12, 98);
            this.TextBox1.Multiline = true;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(117, 216);
            this.TextBox1.TabIndex = 58;
            // 
            // cmdARS
            // 
            this.cmdARS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdARS.Location = new System.Drawing.Point(894, 69);
            this.cmdARS.Name = "cmdARS";
            this.cmdARS.Size = new System.Drawing.Size(51, 23);
            this.cmdARS.TabIndex = 57;
            this.cmdARS.Text = "ARS";
            this.cmdARS.UseVisualStyleBackColor = true;
            this.cmdARS.Click += new System.EventHandler(this.CmdARS_Click);
            // 
            // cmdES
            // 
            this.cmdES.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdES.Location = new System.Drawing.Point(837, 69);
            this.cmdES.Name = "cmdES";
            this.cmdES.Size = new System.Drawing.Size(51, 23);
            this.cmdES.TabIndex = 56;
            this.cmdES.Text = "ES";
            this.cmdES.UseVisualStyleBackColor = true;
            this.cmdES.Click += new System.EventHandler(this.CmdES_Click);
            // 
            // cmdWMA
            // 
            this.cmdWMA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdWMA.Location = new System.Drawing.Point(780, 69);
            this.cmdWMA.Name = "cmdWMA";
            this.cmdWMA.Size = new System.Drawing.Size(51, 23);
            this.cmdWMA.TabIndex = 55;
            this.cmdWMA.Text = "WMA";
            this.cmdWMA.UseVisualStyleBackColor = true;
            this.cmdWMA.Click += new System.EventHandler(this.CmdWMA_Click);
            // 
            // cmdSMA
            // 
            this.cmdSMA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSMA.Location = new System.Drawing.Point(723, 69);
            this.cmdSMA.Name = "cmdSMA";
            this.cmdSMA.Size = new System.Drawing.Size(51, 23);
            this.cmdSMA.TabIndex = 54;
            this.cmdSMA.Text = "SMA";
            this.cmdSMA.UseVisualStyleBackColor = true;
            this.cmdSMA.Click += new System.EventHandler(this.CmdSMA_Click);
            // 
            // cmdNaive
            // 
            this.cmdNaive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdNaive.Location = new System.Drawing.Point(666, 69);
            this.cmdNaive.Name = "cmdNaive";
            this.cmdNaive.Size = new System.Drawing.Size(51, 23);
            this.cmdNaive.TabIndex = 53;
            this.cmdNaive.Text = "Naive";
            this.cmdNaive.UseVisualStyleBackColor = true;
            this.cmdNaive.Click += new System.EventHandler(this.CmdNaive_Click);
            // 
            // lblMeanSquaredError
            // 
            this.lblMeanSquaredError.AutoSize = true;
            this.lblMeanSquaredError.Location = new System.Drawing.Point(472, 45);
            this.lblMeanSquaredError.Name = "lblMeanSquaredError";
            this.lblMeanSquaredError.Size = new System.Drawing.Size(96, 13);
            this.lblMeanSquaredError.TabIndex = 52;
            this.lblMeanSquaredError.Text = "MeanSquaredError";
            // 
            // lblTrackingSignal
            // 
            this.lblTrackingSignal.AutoSize = true;
            this.lblTrackingSignal.Location = new System.Drawing.Point(472, 27);
            this.lblTrackingSignal.Name = "lblTrackingSignal";
            this.lblTrackingSignal.Size = new System.Drawing.Size(78, 13);
            this.lblTrackingSignal.TabIndex = 51;
            this.lblTrackingSignal.Text = "TrackingSignal";
            // 
            // lblMeanAbsolutePercentError
            // 
            this.lblMeanAbsolutePercentError.AutoSize = true;
            this.lblMeanAbsolutePercentError.Location = new System.Drawing.Point(472, 9);
            this.lblMeanAbsolutePercentError.Name = "lblMeanAbsolutePercentError";
            this.lblMeanAbsolutePercentError.Size = new System.Drawing.Size(134, 13);
            this.lblMeanAbsolutePercentError.TabIndex = 50;
            this.lblMeanAbsolutePercentError.Text = "MeanAbsolutePercentError";
            // 
            // lblMeanPercentError
            // 
            this.lblMeanPercentError.AutoSize = true;
            this.lblMeanPercentError.Location = new System.Drawing.Point(9, 45);
            this.lblMeanPercentError.Name = "lblMeanPercentError";
            this.lblMeanPercentError.Size = new System.Drawing.Size(93, 13);
            this.lblMeanPercentError.TabIndex = 49;
            this.lblMeanPercentError.Text = "MeanPercentError";
            // 
            // lblMeanAbsoluteDeviation
            // 
            this.lblMeanAbsoluteDeviation.AutoSize = true;
            this.lblMeanAbsoluteDeviation.Location = new System.Drawing.Point(9, 27);
            this.lblMeanAbsoluteDeviation.Name = "lblMeanAbsoluteDeviation";
            this.lblMeanAbsoluteDeviation.Size = new System.Drawing.Size(120, 13);
            this.lblMeanAbsoluteDeviation.TabIndex = 48;
            this.lblMeanAbsoluteDeviation.Text = "MeanAbsoluteDeviation";
            // 
            // lblMeanSignedDeviaiton
            // 
            this.lblMeanSignedDeviaiton.AutoSize = true;
            this.lblMeanSignedDeviaiton.Location = new System.Drawing.Point(9, 9);
            this.lblMeanSignedDeviaiton.Name = "lblMeanSignedDeviaiton";
            this.lblMeanSignedDeviaiton.Size = new System.Drawing.Size(112, 13);
            this.lblMeanSignedDeviaiton.TabIndex = 47;
            this.lblMeanSignedDeviaiton.Text = "MeanSignedDeviation";
            // 
            // grdResults
            // 
            this.grdResults.AllowUserToAddRows = false;
            this.grdResults.AllowUserToDeleteRows = false;
            this.grdResults.AllowUserToOrderColumns = true;
            this.grdResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdResults.Location = new System.Drawing.Point(135, 98);
            this.grdResults.Name = "grdResults";
            this.grdResults.ReadOnly = true;
            this.grdResults.Size = new System.Drawing.Size(810, 216);
            this.grdResults.TabIndex = 46;
            // 
            // Forcasting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 360);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.cmdARS);
            this.Controls.Add(this.cmdES);
            this.Controls.Add(this.cmdWMA);
            this.Controls.Add(this.cmdSMA);
            this.Controls.Add(this.cmdNaive);
            this.Controls.Add(this.lblMeanSquaredError);
            this.Controls.Add(this.lblTrackingSignal);
            this.Controls.Add(this.lblMeanAbsolutePercentError);
            this.Controls.Add(this.lblMeanPercentError);
            this.Controls.Add(this.lblMeanAbsoluteDeviation);
            this.Controls.Add(this.lblMeanSignedDeviaiton);
            this.Controls.Add(this.grdResults);
            this.Name = "FrmForcasting";
            this.Text = "FrmForcasting";
            this.Load += new System.EventHandler(this.Forcasting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox TextBox1;
        internal System.Windows.Forms.Button cmdARS;
        internal System.Windows.Forms.Button cmdES;
        internal System.Windows.Forms.Button cmdWMA;
        internal System.Windows.Forms.Button cmdSMA;
        internal System.Windows.Forms.Button cmdNaive;
        internal System.Windows.Forms.Label lblMeanSquaredError;
        internal System.Windows.Forms.Label lblTrackingSignal;
        internal System.Windows.Forms.Label lblMeanAbsolutePercentError;
        internal System.Windows.Forms.Label lblMeanPercentError;
        internal System.Windows.Forms.Label lblMeanAbsoluteDeviation;
        internal System.Windows.Forms.Label lblMeanSignedDeviaiton;
        internal System.Windows.Forms.DataGridView grdResults;
    }
}