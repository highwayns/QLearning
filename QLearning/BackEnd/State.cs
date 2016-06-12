using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLearning
{
    public class State
    {
        #region Constructor

        public State(int x, int y, int index)
        {
            this.X = x;
            this.Y = y;
            this.Index = index;
        }

        #endregion

        #region Attributes and Properties

        public int X { get; set; }
        public int Y { get; set; }
        public int Index { get; set; }

        #endregion

        #region Overridden Methods

        public override bool Equals(object obj) // NOT FOOKIN WORKING...DN WHY
        {
            var otherState = obj as State;
        
            return otherState.X == this.X &&
                otherState.Y == this.Y &&
                otherState.Index == this.Index;
        }

        #endregion
    }
}
