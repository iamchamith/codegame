using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlocklyPro.ServiceRepository;
using BlocklyPro.Utility;

namespace BlocklyPro.Forcasting
{
    public partial class FrmForcasting : Form
    {
        private readonly IGameServiceRepository _gameServiceRepository;
        private List<KeyValuePair<DateTime, int>> _gameMarks;
        private int _gameId { get; }
        public FrmForcasting(IGameServiceRepository gameServiceRepository, int gameid)
        {
            _gameServiceRepository = gameServiceRepository;
            _gameId = gameid;
            InitializeComponent();
        }
        async Task LoadInfo()
        {
            _gameMarks = await _gameServiceRepository.GetMarksByGameId(new Request<int>(_gameId).SetToken());
        }

        private void CmdNaive_Click(object sender, EventArgs e)
        {
            ForecastTable dt = TimeSeries.naive(GetInput().ToArray(), 5, 0);
            grdResults.DataSource = dt;

            updateMeasurements(dt);
        }

        private void CmdSMA_Click(object sender, EventArgs e)
        {
            ForecastTable dt = TimeSeries.simpleMovingAverage(GetInput().ToArray(), 5, 3, 0);
            grdResults.DataSource = dt;

            updateMeasurements(dt);
        }

        private void CmdWMA_Click(object sender, EventArgs e)
        {
            ForecastTable dt = TimeSeries.weightedMovingAverage(GetInput().ToArray(), 5, (Decimal)0.05, (Decimal)0.15, (Decimal)0.8);
            grdResults.DataSource = dt;

            updateMeasurements(dt);
        }

        private void CmdES_Click(object sender, EventArgs e)
        {
            ForecastTable dt = TimeSeries.exponentialSmoothing(GetInput().ToArray(), 5, (Decimal)0.8);
            grdResults.DataSource = dt;

            updateMeasurements(dt);
        }

        private void CmdARS_Click(object sender, EventArgs e)
        {
            ForecastTable dt = TimeSeries.adaptiveRateSmoothing(GetInput().ToArray(), 5, (Decimal)0.2, (Decimal)0.8);
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
        private List<decimal> GetInput()
        {
            if (_gameMarks==null || _gameMarks.Count==0)
            {
                return new List<decimal>();
            }
            return this._gameMarks.Select(p => p.Value).Select(i => (decimal)i).ToList();
        }
        private async void Forcasting_Load(object sender, EventArgs e)
        {
            TextBox1.Text = "4,2,5,3,6,4,7,5,8,6,9,7";
            await LoadInfo();
        }
    }
}
