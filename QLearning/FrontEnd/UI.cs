using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        #endregion

        #region Signed Events

        private void DrawingTimer_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
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

        #endregion
    }
}
