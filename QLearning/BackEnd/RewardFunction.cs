using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLearning.BackEnd
{
    public static class RewardFunction
    {
        #region Constants

        private static readonly float GAMMA = 0.5f;

        #endregion

        #region Static Methods

        public static float Calculate(float currentReward, float bestMovementReward)
        {
            // Q(s2, a23) = r + 0.5 * max(Q(s3,a32),Q(s3,a36))
            return currentReward + RewardFunction.GAMMA * bestMovementReward;
        }
 
        #endregion
    }
}
