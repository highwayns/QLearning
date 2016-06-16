using System;

namespace QLearning.BackEnd
{
    public static class RandomGenerator
    {
        #region Private Fields

        private static Random _random;

        #endregion

        #region Public Methods

        public static int Generate(int from, int to)
        {
            if (_random == null)
                _random = new Random();

            return _random.Next(from, to);
        }

        #endregion
    }
}
