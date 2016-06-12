using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLearning.BackEnd
{
    public class QTable : List<Movement>
    {
        #region Fields

        private string[,] _matrix;

        #endregion

        #region Public Methods

        // Provisório
        public void Print(State current)
        {
            Console.Clear();
            
            Console.WriteLine("Estado: | Acao: | Recompensa: |");
            
            foreach (var item in this)
                Console.WriteLine(string.Format("{0} {1} {2}", item.State.Index, item.Action.ToString(), item.Reward));

            this._matrix = new string[10, 5];

            foreach (var item in this)
                if (this._matrix[item.State.X, item.State.Y] == null)
                    this._matrix[item.State.X, item.State.Y] = item.State.Index.ToString();

            this._matrix[current.X, current.Y] = "X";

            for (int j = 4; j > -1; j--)
            {
                {
                    for (int i = 0; i < 10; i++)
                        Console.Write(this._matrix[i, j] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            //Console.ReadKey();
        }

        #endregion
    }
}
