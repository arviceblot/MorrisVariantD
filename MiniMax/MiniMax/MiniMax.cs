using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMax
{
    public class MiniMax<T> where T : GameBoard
    {
        private int staticEvals;

        public int StaticEvals
        {
            get { return staticEvals; }
        }

        private bool usePruning;

        public bool UsePruning
        {
            get { return usePruning; }
        }

        public MiniMax(bool usePruning = false)
        {
            staticEvals = 0;
            this.usePruning = usePruning;
        }

        public Tuple<GameNode<T>, int> MaxMin(GameNode<T> x, int alpha, int beta)
        {
            if (x.IsLeaf())
            {
                staticEvals++;
                return new Tuple<GameNode<T>, int>(x, x.Board.Static());
            }
            else
            {
                int v = int.MinValue;
                var val = x.Children[0];
                foreach (var y in x.Children)
                {
                    var temp = MinMax(y, alpha, beta);
                    var node = temp.Item1;
                    var score = temp.Item2;
                    v = Math.Max(v, score);

                    if (usePruning)
                    {
                        if (v >= beta)
                        {
                            val = node;
                            return new Tuple<GameNode<T>, int>(val, v);
                        }
                        else
                        {
                            alpha = Math.Max(v, alpha);
                        }
                    }
                    else if (v == score)
                    {
                        val = node;
                    }
                }
                return new Tuple<GameNode<T>, int>(val, v);
            }
        }

        public Tuple<GameNode<T>, int> MinMax(GameNode<T> x, int alpha, int beta)
        {
            if (x.IsLeaf())
            {
                staticEvals++;
                return new Tuple<GameNode<T>, int>(x, x.Board.Static());
            }
            else
            {
                int v = int.MaxValue;
                var val = x.Children[0];
                foreach (var y in x.Children)
                {
                    var temp = MaxMin(y, alpha, beta);
                    var node = temp.Item1;
                    var score = temp.Item2;
                    v = Math.Min(v, score);

                    if (usePruning)
                    {
                        if (v <= alpha)
                        {
                            return new Tuple<GameNode<T>, int>(val, v);
                        }
                        else
                        {
                            beta = Math.Min(v, beta);
                        }
                    }
                    else if (v == score)
                    {
                        val = node;
                    }
                }
                return new Tuple<GameNode<T>, int>(val, v);
            }
        }

        public Tuple<GameNode<T>, int> MiniMaxBase(GameNode<T> x)
        {
            if (x.IsMax)
            {
                return MaxMin(x, int.MinValue, int.MaxValue);
            }
            else
            {
                return MinMax(x, int.MinValue, int.MaxValue);
            }
        }
    }
}
