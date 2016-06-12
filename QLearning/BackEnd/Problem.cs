using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLearning
{
    public class Problem
    {
        #region Constructor

        public Problem()
        {
            this.Setup();
        }

        #endregion

        #region Constants

        public readonly State STARTING_STATE = new State(0, 0, 1);
        public readonly State ENDING_STATE = new State(0, 9, 50);

        private readonly float STARTING_STATE_REWARD = 0f;
        private readonly float OBSTACLE_REWARD = -100f;
        private readonly float OBJECTIVE_REWARD = 100f;

        public readonly int MAP_LENGTH = 10;
        public readonly int MAP_HEIGHT = 5;

        public readonly int RANDOMNESS_PERENTAGE = 30;

        #endregion

        #region Attributes and Properties

        public float[] Rewards { get; set; }
        public int[,] Map { get; set; }

        #endregion

        #region Public Methods

        public void Setup()
        {
            this.InitRewardInfo();
            this.InitMap();
        }

        #endregion

        #region Private Methods

        private void InitRewardInfo()
        {
            this.Rewards = new float[51];

            this.Rewards[1] = STARTING_STATE_REWARD;
            this.Rewards[10] = OBSTACLE_REWARD;
            this.Rewards[11] = OBSTACLE_REWARD;
            this.Rewards[20] = OBSTACLE_REWARD;
            this.Rewards[21] = OBSTACLE_REWARD;
            this.Rewards[30] = OBSTACLE_REWARD;
            this.Rewards[31] = OBSTACLE_REWARD;
            this.Rewards[40] = OBSTACLE_REWARD;
            this.Rewards[41] = OBSTACLE_REWARD;

            this.Rewards[50] = OBJECTIVE_REWARD;
        }

        private void InitMap()
        {
            this.Map = new int[,] { 
            { 1, 2, 3, 4, 5 },
            { 10, 9, 8, 7, 6 }, 
            { 11, 12, 13, 14, 15 }, 
            { 20, 19, 18, 17, 16 },
            { 21, 22, 23, 24, 25 },
            { 30, 29, 28, 27, 26 },
            { 31, 32, 33, 34, 35 },
            { 40, 39, 38, 37, 36 },
            { 41, 42, 43, 44, 45 },
            { 50, 49, 48, 47, 46 }};
        }

        #endregion
    }
}
