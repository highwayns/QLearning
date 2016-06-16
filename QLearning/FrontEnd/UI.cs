using System;
using System.Windows.Forms;

namespace QLearning.FrontEnd
{
    public partial class UI : Form
    {
        #region Constructor

        public UI()
        {
            InitializeComponent();
            this._screenManager = new ScreenManager();
        }

        #endregion

        #region Private Fields

        private ScreenManager _screenManager;
        private QTableForm _qTableForm;
        private int _lastIteration = -1;

        #endregion

        #region Signed Events

        private void DrawingTimer_Tick(object sender, EventArgs e)
        {
            if (this._screenManager.Algorithm != null)
            {
                this._screenManager.Algorithm.CurrentRandom = int.Parse(this.RandomPercentage.Value.ToString());

                if (this._screenManager.Algorithm.TimesRunned != _lastIteration)
                {
                    this._lastIteration = this._screenManager.Algorithm.TimesRunned;
                    this.ListBoxConsole.Items.Add(string.Format("Execução número : {0}", this._lastIteration));
                }
            }

            this.Invalidate();

            if(this._qTableForm != null)
                this._qTableForm.Invalidate();

            this.DrawingTimer.Interval = (this.SpeedTrackBar.Maximum + 1) - this.SpeedTrackBar.Value;
        }

        private void UI_Load(object sender, EventArgs e)
        {
            this.DrawingTimer.Interval = (this.SpeedTrackBar.Maximum + 1) - this.SpeedTrackBar.Value;
            this.DrawingTimer.Start();
        }

        private void UI_Paint(object sender, PaintEventArgs e)
        {
            this._screenManager.Update();
            this._screenManager.Draw(e.Graphics);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            this._screenManager.Algorithm = new QLearningAlgorithm();
            this._screenManager.Algorithm.StartUp(this._screenManager.Problem);

            this.StartButton.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _qTableForm = new QTableForm(_screenManager);
            _qTableForm.Show();
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            this.DrawingTimer.Stop();
            this.button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DrawingTimer.Start();
            this.button1.Enabled = false;
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            this.DrawingTimer.Stop();

            this.ListBoxConsole.Items.Clear();
            this.ListBoxConsole.Items.Add("Melhor caminho encontrado: ");

            foreach (var mov in this._screenManager.Algorithm.GetBestPathFound())
                if (mov == eAction.East)
                    this.ListBoxConsole.Items.Add("> Leste");
                else if (mov == eAction.West)
                    this.ListBoxConsole.Items.Add("> Oeste");
                else if (mov == eAction.North)
                    this.ListBoxConsole.Items.Add("> Norte");
                else if (mov == eAction.South)
                    this.ListBoxConsole.Items.Add("> Sul");

            this.StartButton.Enabled = true;
            this._screenManager.Algorithm.Clear();

            this._screenManager.Algorithm.StartUp(this._screenManager.Problem);
        }

        private void RandomPercentage_ValueChanged(object sender, EventArgs e)
        {
            if (this.RandomPercentage.Value < 0)
                this.RandomPercentage.Value = 0;

            if (this.RandomPercentage.Value > 100)
                this.RandomPercentage.Value = 100;
        }

        #endregion
    }
}
