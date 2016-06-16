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
        //private float _currentRandom;

        #endregion

        #region Attributes and Properties

        public State CurrentState { get; set; }
        public QTable QTable { get; set; }

        public int TimesRunned { get; set; }
        public int CurrentRandom { get; set; }

        #endregion

        #region Public Methods

        public void StartUp(Problem problem)
        {
            this.CurrentState = problem.STARTING_STATE;
            this.PopulateQTable(problem);
            this.TimesRunned = 0;

            //this._currentRandom = 30f;
            this._problem = problem;
        }

        public void DoNextStep()
        {
            //this.QTable.Print(this.CurrentState);

            if (this.ReachedDestination())
            {
                this.CurrentState = this._problem.STARTING_STATE;
                this.TimesRunned++;
            }

            var possibleMovements = this.QTable.Where(m => m.State.Equals(this.CurrentState)).ToList();
            var nextMovement = this.GetNextMovement(possibleMovements);

            this.UpdateTable(nextMovement);
            this.CurrentState = this.GetDestinationState(nextMovement);
        }

        #endregion

        #region Private Methods

        private bool ReachedDestination()
        {
            return this.CurrentState.Index == this._problem.ENDING_STATE.Index;
        }

        private Movement GetNextMovement(List<Movement> possibleMovements)
        {
            if (this.MustTakeTheBestPath() && !this.AllMovementsHaveTheSameReward(possibleMovements))
                return this.GetBestRewardMovement(possibleMovements);

            return this.GetRandomMovement(possibleMovements);
        }

        private bool AllMovementsHaveTheSameReward(List<Movement> movements)
        {
            var rewards = movements.Select(m => m.Reward);
            return rewards.Distinct().Count() == 1;
        }

        private Movement GetBestRewardMovement(List<Movement> possibleMovements)
        {
            return possibleMovements.OrderBy(m => m.Reward).Last();
        }

        private Movement GetRandomMovement(List<Movement> possibleMovements)
        {
            var random = new Random();
            var randNum = random.Next(possibleMovements.Count);
            randNum = random.Next(possibleMovements.Count);
            return possibleMovements[randNum];
        }

        private float UpdateRandom()
        {
            if(this.CurrentRandom > 10)
                return this.CurrentRandom - 1;

            return this.CurrentRandom;
        }

        private bool MustTakeTheBestPath()
        {
            var random = new Random();
            return random.Next(1, 101) > this.CurrentRandom;
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

        private State GetDestinationState(Movement movement)
        {
            if (movement.Action == eAction.West)
                return new State(this.CurrentState.X - 1, this.CurrentState.Y, this._problem.Map[this.CurrentState.X - 1, this.CurrentState.Y]);
            else if (movement.Action == eAction.East)
                return new State(this.CurrentState.X + 1, this.CurrentState.Y, this._problem.Map[this.CurrentState.X + 1, this.CurrentState.Y]);
            else if (movement.Action == eAction.South)
                return new State(this.CurrentState.X, this.CurrentState.Y - 1, this._problem.Map[this.CurrentState.X, this.CurrentState.Y - 1]);

            return new State(this.CurrentState.X, this.CurrentState.Y + 1, this._problem.Map[this.CurrentState.X, this.CurrentState.Y + 1]);
        }

        private void UpdateTable(Movement movement)
        {
            var nextState = this.GetDestinationState(movement);

            var possibleMovements = this.QTable.Where(m => m.State.Equals(nextState)).ToList();
            var bestFutureMovement = this.GetBestRewardMovement(possibleMovements);

            movement.Reward = RewardFunction.Calculate(this._problem.Rewards[nextState.Index], bestFutureMovement.Reward);
        }

        #endregion
    }
}
