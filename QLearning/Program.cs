using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            var algorithm = new QLearningAlgorithm();
            var problem = new Problem();

            algorithm.StartUp(problem);
            algorithm.Execute();

            //

            //var estadoAtual = new State(4, 0, 1);
            //var estadoFinal = new State(10, 5, 50);
            //
            //var recompensas = new float[51];
            //
            //recompensas[1] = 1;
            //recompensas[10] = -100;
            //recompensas[11] = -100;
            //recompensas[20] = -100;
            //recompensas[21] = -100;
            //recompensas[30] = -100;
            //recompensas[31] = -100;
            //recompensas[40] = -100;
            //recompensas[41] = -100;
            //
            //recompensas[50] = 100;
            //
            //var mapa = new int[,] { 
            //{ 5, 6, 15, 16, 25, 26, 35, 36, 45, 46 },
            //{ 4, 7, 14, 17, 24, 27, 34, 37, 44, 47 },
            //{ 3, 8, 13, 18, 23, 28, 33, 38, 43, 48 }, 
            //{ 2, 9, 12, 19, 22, 29, 32, 39, 42, 49 }, 
            //{ 1, 10, 11, 20, 21, 30, 31, 40, 41, 50 } 
            //};
            //
            //var tabelaQ = new List<Movement>();
            //
            //for (int i = 0; i < 10; i++)
            //{
            //    for (int j = 0; j < 5; j++)
            //    {
            //        if (i > 0)
            //            tabelaQ.Add(new Movement(0, new State(j, i, mapa[j, i]), eAction.Left));
            //
            //        if (i < 9)
            //            tabelaQ.Add(new Movement(0, new State(j, i, mapa[j, i]), eAction.Right));
            //
            //        if (j > 0)
            //            tabelaQ.Add(new Movement(0, new State(j, i, mapa[j, i]), eAction.Up));
            //
            //        if (j < 4)
            //            tabelaQ.Add(new Movement(0, new State(j, i, mapa[j, i]), eAction.Down));
            //    }
            //}

            //while (estadoAtual.Index != estadoFinal.Index)
            //{
            //    var movimentosPossiveis = tabelaQ.Where(m => m.State.Index == estadoAtual.Index).ToList();
            //
            //    var random = new Random();
            //    var deveIrPeloMelhorCaminho = random.Next(1, 11) >= 4;
            //
            //    if (deveIrPeloMelhorCaminho)
            //    {
            //        var melhorMovimento = movimentosPossiveis.OrderBy(m => m.Reward).Last();
            //        estadoAtual = Move(tabelaQ, estadoAtual, melhorMovimento, mapa, recompensas);
            //    }
            //    else
            //    {
            //        var random2 = new Random();
            //        var movimentoX = random2.Next(1, movimentosPossiveis.Count);
            //
            //        estadoAtual = Move(tabelaQ, estadoAtual, movimentosPossiveis[movimentoX], mapa, recompensas);
            //    }
            //}
        }

        //private static State Move(IEnumerable<Movement> tabelaQ, State estadoAtual, Movement melhorMovimento, int[,] mapa, float[] recompensas)
        //{
        //    var posicao = tabelaQ.Where(m => m.State.Index == estadoAtual.Index && m.Action == melhorMovimento.Action).First();
        //
        //    posicao.Reward = recompensas[melhorMovimento.State.Index] + 0.5f * melhorMovimento.Reward;
        //
        //    if (melhorMovimento.Action == eAction.Down) // VERIFICAR I E J E DIREÇÕES DE MOVIMENTO
        //        return new State(estadoAtual.I + 1, estadoAtual.J, mapa[estadoAtual.I + 1, estadoAtual.J]);
        //    else if (melhorMovimento.Action == eAction.Up)
        //        return new State(estadoAtual.I - 1, estadoAtual.J, mapa[estadoAtual.I - 1, estadoAtual.J]);
        //    else if (melhorMovimento.Action == eAction.Left)
        //        return new State(estadoAtual.I, estadoAtual.J - 1, mapa[estadoAtual.I, estadoAtual.J - 1]);
        //    
        //    return new State(estadoAtual.I, estadoAtual.J + 1, mapa[estadoAtual.I, estadoAtual.J + 1]);
        //}
    }
}
