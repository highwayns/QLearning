using QLearning.BackEnd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QLearning
{
    public class QLearningAlgorithm
    {
        #region Constructor

        public QLearningAlgorithm()
        {
            this.QTable = new QTable();
        }

        #endregion

        #region Private Fields

        private Problem _problem;

        #endregion

        #region Attributes and Properties

        public State CurrentState { get; set; }
        public QTable QTable { get; set; }

        #endregion

        #region Public Methods

        public void StartUp(Problem problem)
        {
            this.CurrentState = problem.STARTING_STATE;
            this.PopulateQTable(problem);

            this._problem = problem;
        }

        public void Execute()
        {
            while (!this.ReachedDestination())
            {
                var possibleMovements = this.QTable.Where(m => m.State.Equals(this.CurrentState)).ToList();
                var nextMovement = this.GetNextMovement(possibleMovements);

                this.CurrentState = this.MoveAgent(nextMovement);

                // Debug shit:
                //var greatestReward = this.QTable.Where(m => m.Reward > 0);
                this.QTable.Print(this.CurrentState);
                Thread.Sleep(100);
            }
        }

        #endregion

        #region Private Methods

        private bool ReachedDestination()
        {
            return this.CurrentState.Index == this._problem.ENDING_STATE.Index;
        }

        private Movement GetNextMovement(List<Movement> possibleMovements)
        {
            var bestUnknownReward = this.GetBestUnknownRewardMovement(possibleMovements);
            var bestKnownReward = this.GetBestKnownRewardMovement(possibleMovements);

            if (this.MustTakeTheBestPath())
            {
                if (bestUnknownReward.Reward != 0)
                    return bestUnknownReward;
                if (bestKnownReward.Reward != 0)
                    return bestKnownReward;
            }

            return this.GetRandomMovement(possibleMovements);
        }

        private Movement GetBestUnknownRewardMovement(List<Movement> possibleMovements)
        {
            var unknownRewards = new Dictionary<Movement, float>();

            foreach (var mov in possibleMovements)
                unknownRewards.Add(mov, this._problem.Rewards[mov.State.Index]);

            var max = unknownRewards.OrderBy(m => m.Value).Last();

            return new Movement(max.Value, max.Key.State, max.Key.Action);
        }

        private Movement GetBestKnownRewardMovement(List<Movement> possibleMovements)
        {
            return possibleMovements.OrderBy(m => m.Reward).Last();
        }

        private Movement GetRandomMovement(List<Movement> possibleMovements)
        {
            var random = new Random();
            return possibleMovements[random.Next(possibleMovements.Count)];
        }

        private bool MustTakeTheBestPath()
        {
            var random = new Random();
            return random.Next(1, 101) > this._problem.RANDOMNESS_PERENTAGE;
        }

        private void PopulateQTable(Problem problem)
        {
            for (int x = 0; x < problem.MAP_LENGTH; x++)
            {
                for (int y = 0; y < problem.MAP_HEIGHT; y++)
                {
                    if (x > 0)
                        this.QTable.Add(new Movement(0, new State(x, y, problem.Map[x, y]), eAction.West));

                    if (x < 9)
                        this.QTable.Add(new Movement(0, new State(x, y, problem.Map[x, y]), eAction.East));

                    if (y > 0)
                        this.QTable.Add(new Movement(0, new State(x, y, problem.Map[x, y]), eAction.South));

                    if (y < 4)
                        this.QTable.Add(new Movement(0, new State(x, y, problem.Map[x, y]), eAction.North));
                }
            }
        }

        private State MoveAgent(Movement movement)
        {
            this.UpdateTable(this.QTable.Where(m => m.State.Equals(this.CurrentState) && m.Action == movement.Action).First().Reward, movement);

            if (movement.Action == eAction.West)
                return new State(this.CurrentState.X - 1, this.CurrentState.Y, this._problem.Map[this.CurrentState.X - 1, this.CurrentState.Y]);
            else if (movement.Action == eAction.East)
                return new State(this.CurrentState.X + 1, this.CurrentState.Y, this._problem.Map[this.CurrentState.X + 1, this.CurrentState.Y]);
            else if (movement.Action == eAction.South)
                return new State(this.CurrentState.X, this.CurrentState.Y - 1, this._problem.Map[this.CurrentState.X, this.CurrentState.Y - 1]);

            return new State(this.CurrentState.X, this.CurrentState.Y + 1, this._problem.Map[this.CurrentState.X, this.CurrentState.Y + 1]);
        }

        private void UpdateTable(float currentReward, Movement movement)
        {
            movement.Reward = RewardFunction.Calculate(currentReward, movement.Reward);
        }

        #endregion
    }
}
