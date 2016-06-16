namespace QLearning.BackEnd
{
    public static class RewardFunction
    {
        #region Constants

        private static readonly float GAMMA = 0.5f;

        #endregion

        #region Static Methods

        public static double Calculate(double movementReward, double nextStateBestReward)
        {
            return movementReward + RewardFunction.GAMMA * nextStateBestReward;
        }
 
        #endregion
    }
}
