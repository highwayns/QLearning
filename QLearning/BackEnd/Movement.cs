namespace QLearning
{
    public class Movement
    {
        #region Constructor

        public Movement(float reward, State state, eAction action)
        {
            this.Reward = reward;
            this.State = state;
            this.Action = action;
        }

        #endregion

        #region Attributes and Properties

        public double Reward { get; set; }
        public State State { get; set; }
        public eAction Action { get; set; }

        #endregion
    }
}
