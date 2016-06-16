using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace QLearning.FrontEnd
{
    public class ScreenManager
    {
        #region Constructor

        public ScreenManager()
        {
            this.Squares = new List<Square>();
            this.Initialize();
        }

        #endregion

        #region Attributes and Properties

        public List<Square> Squares;
        public Problem Problem;
        public QLearningAlgorithm Algorithm;

        #endregion

        #region Public Methods

        public void Update()
        {
            this.UpdateSquares();

            if (this.Algorithm != null)
            {
                this.Algorithm.DoNextStep();
                this.Squares.Find(s => s.Number == this.Algorithm.CurrentState.Index).Color = Brushes.Red;
            }
        }

        public void Draw(Graphics g)
        {
            foreach (var square in this.Squares)
                square.Draw(g);
        }

        #endregion

        #region Private Methods

        private void Initialize()
        {
            this.Problem = new Problem();
            this.CreateSquares();
        }

        private void CreateSquares()
        {
            for (int y = 4; y > -1; y--)
                for (int x = 0; x < 10; x++)
                    this.Squares.Add(new Square(new Point(20 + x * Square.SIZE, 20 + Square.SIZE * 4 - y * Square.SIZE), this.Problem.Map[x, y], Brushes.White));
        }

        private void UpdateSquares()
        {
            this.RepaintSquares();
            this.PaintStartAndEnd();
            this.PaintObstacles();
        }

        private void RepaintSquares()
        {
            foreach (var square in this.Squares)
                square.Color = Brushes.White;
        }

        private void PaintStartAndEnd()
        {
            foreach (var square in this.Squares.Where(s => s.Number == this.Problem.STARTING_STATE.Index || s.Number == this.Problem.ENDING_STATE.Index))
                square.Color = Brushes.Green;
        }

        private void PaintObstacles()
        {
            for (int i = 0; i < this.Problem.Rewards.Count(); i++)
                if(this.Problem.Rewards[i] == this.Problem.OBSTACLE_REWARD)
                    this.Squares.Where(s => s.Number == i).Last().Color = Brushes.Black;
        }

        #endregion
    }
}
