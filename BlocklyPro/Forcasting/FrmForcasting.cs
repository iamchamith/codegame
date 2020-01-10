using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlocklyPro.Forcasting
{
    public partial class FrmForcasting : Form
    {
        public FrmForcasting()
        {
            InitializeComponent();
        }

        private void CmdNaive_Click(object sender, EventArgs e)
        {
            ForecastTable dt = TimeSeries.naive(GetInput(), 5, 0);
            grdResults.DataSource = dt;

            updateMeasurements(dt);
        }

        private void CmdSMA_Click(object sender, EventArgs e)
        {
            ForecastTable dt = TimeSeries.simpleMovingAverage(GetInput(), 5, 3, 0);
            grdResults.DataSource = dt;

            updateMeasurements(dt);
        }

        private void CmdWMA_Click(object sender, EventArgs e)
        {
            ForecastTable dt = TimeSeries.weightedMovingAverage(GetInput(), 5, (Decimal)0.05, (Decimal)0.15, (Decimal)0.8);
            grdResults.DataSource = dt;

            updateMeasurements(dt);
        }

        private void CmdES_Click(object sender, EventArgs e)
        {
            ForecastTable dt = TimeSeries.exponentialSmoothing(GetInput(), 5, (Decimal)0.8);
            grdResults.DataSource = dt;

            updateMeasurements(dt);
        }

        private void CmdARS_Click(object sender, EventArgs e)
        {
            ForecastTable dt = TimeSeries.adaptiveRateSmoothing(GetInput(), 5, (Decimal)0.2, (Decimal)0.8);
            grdResults.DataSource = dt;

            updateMeasurements(dt);
        }
        private void updateMeasurements(ForecastTable dt)
        {
            if (dt == null) return;

            lblMeanSignedDeviaiton.Text = "MSD: " + TimeSeries.MeanSignedError(dt, false, TimeSeries.DEFAULT_IGNORE).ToString();
            lblMeanAbsoluteDeviation.Text = "MAD: " + TimeSeries.MeanAbsoluteError(dt, false, TimeSeries.DEFAULT_IGNORE).ToString();
            lblMeanAbsolutePercentError.Text = "MAPE: " + TimeSeries.MeanAbsolutePercentError(dt, false, TimeSeries.DEFAULT_IGNORE).ToString();
            lblMeanPercentError.Text = "MPE: " + TimeSeries.MeanPercentError(dt, false, TimeSeries.DEFAULT_IGNORE).ToString();
            lblMeanSquaredError.Text = "MSE: " + TimeSeries.MeanSquaredError(dt, false, TimeSeries.DEFAULT_IGNORE, 0).ToString();
            lblTrackingSignal.Text = "TS: " + TimeSeries.TrackingSignal(dt, false, TimeSeries.DEFAULT_IGNORE).ToString();
        }
        private Decimal[] GetInput()
        {
            String[] arrStr = TextBox1.Text.Split(",".ToArray());
            Decimal[] arrDec = new Decimal[arrStr.Length];

            for (Int32 i = 0; i < arrStr.Length; i++)
            {
                arrDec[i] = Decimal.Parse(arrStr[i]);
            }

            return arrDec;
        }
        private void Forcasting_Load(object sender, EventArgs e)
        {
            TextBox1.Text = "4,2,5,3,6,4,7,5,8,6,9,7";
        }
    }
}
