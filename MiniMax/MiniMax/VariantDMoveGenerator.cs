using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMax
{
    public class VariantDMoveGenerator<T> where T : VariantDBoard
    {
        /* *
         * Input: a location i in the array representing the board
         * Output: a list of locations in the array corresponding to i's neighbors
         */
        private static List<int> neighbors(int i)
        {
            List<int> positions = new List<int>();
            switch (i)
            {
                case 0:
                    positions.AddRange(new int[] { 1, 3, 8 });
                    break;
                case 1:
                    positions.AddRange(new int[] { 0, 2, 4 });
                    break;
                case 2:
                    positions.AddRange(new int[] { 1, 5, 13 });
                    break;
                case 3:
                    positions.AddRange(new int[] { 0, 4, 6, 9 });
                    break;
                case 4:
                    positions.AddRange(new int[] { 1, 3, 5 });
                    break;
                case 5:
                    positions.AddRange(new int[] { 2, 4, 7, 12 });
                    break;
                case 6:
                    positions.AddRange(new int[] { 3, 7, 10 });
                    break;
                case 7:
                    positions.AddRange(new int[] { 5, 6, 11 });
                    break;
                case 8:
                    positions.AddRange(new int[] { 0, 9, 20 });
                    break;
                case 9:
                    positions.AddRange(new int[] { 3, 8, 10, 17 });
                    break;
                case 10:
                    positions.AddRange(new int[] { 6, 9, 14 });
                    break;
                case 11:
                    positions.AddRange(new int[] { 7, 12, 16 });
                    break;
                case 12:
                    positions.AddRange(new int[] { 5, 11, 13, 19 });
                    break;
                case 13:
                    positions.AddRange(new int[] { 2, 12, 22 });
                    break;
                case 14:
                    positions.AddRange(new int[] { 10, 15, 17 });
                    break;
                case 15:
                    positions.AddRange(new int[] { 14, 16, 18 });
                    break;
                case 16:
                    positions.AddRange(new int[] { 11, 15, 19 });
                    break;
                case 17:
                    positions.AddRange(new int[] { 9, 14, 18, 20 });
                    break;
                case 18:
                    positions.AddRange(new int[] { 15, 17, 19, 21 });
                    break;
                case 19:
                    positions.AddRange(new int[] { 12, 16, 18, 22 });
                    break;
                case 20:
                    positions.AddRange(new int[] { 8, 17, 21 });
                    break;
                case 21:
                    positions.AddRange(new int[] { 18, 20, 22 });
                    break;
                case 22:
                    positions.AddRange(new int[] { 13, 19, 21 });
                    break;
                default:
                    break;
            }
            return positions;
        }

        /**
         * Input: a location i in the array representing the board and the board b
         * Output: true if the move to i closes a mill
         */
        private static bool closeMill(int i, T b)
        {
            VariantDToken c = (VariantDToken)b[i];
            if (c.Equals(VariantDToken.EMPTY))
            {
                return false;
            }

            switch (i)
            {
                case 0:
                    return (b[1].Equals(c) && b[2].Equals(c))
                        || (b[3].Equals(c) && b[6].Equals(c))
                        || (b[8].Equals(c) && b[20].Equals(c));
                case 1:
                    return (b[0].Equals(c) && b[2].Equals(c));
                case 2:
                    return (b[0].Equals(c) && b[1].Equals(c))
                        || (b[5].Equals(c) && b[7].Equals(c))
                        || (b[13].Equals(c) && b[22].Equals(c));
                case 3:
                    return (b[0].Equals(c) && b[6].Equals(c))
                        || (b[4].Equals(c) && b[5].Equals(c))
                        || (b[9].Equals(c) && b[17].Equals(c));
                case 4:
                    return (b[3].Equals(c) && b[5].Equals(c));
                case 5:
                    return (b[2].Equals(c) && b[7].Equals(c))
                        || (b[3].Equals(c) && b[4].Equals(c))
                        || (b[12].Equals(c) && b[19].Equals(c));
                case 6:
                    return (b[0].Equals(c) && b[3].Equals(c))
                        || (b[10].Equals(c) && b[14].Equals(c));
                case 7:
                    return (b[2].Equals(c) && b[5].Equals(c))
                        || (b[11].Equals(c) && b[16].Equals(c));
                case 8:
                    return (b[0].Equals(c) && b[20].Equals(c))
                        || (b[9].Equals(c) && b[10].Equals(c));
                case 9:
                    return (b[3].Equals(c) && b[17].Equals(c))
                        || (b[8].Equals(c) && b[10].Equals(c));
                case 10:
                    return (b[6].Equals(c) && b[14].Equals(c))
                        || (b[8].Equals(c) && b[9].Equals(c));
                case 11:
                    return (b[7].Equals(c) && b[16].Equals(c))
                        || (b[12].Equals(c) && b[13].Equals(c));
                case 12:
                    return (b[5].Equals(c) && b[19].Equals(c))
                        || (b[11].Equals(c) && b[13].Equals(c));
                case 13:
                    return (b[2].Equals(c) && b[22].Equals(c))
                        || (b[11].Equals(c) && b[12].Equals(c));
                case 14:
                    return (b[6].Equals(c) && b[10].Equals(c))
                        || (b[15].Equals(c) && b[16].Equals(c))
                        || (b[17].Equals(c) && b[20].Equals(c));
                case 15:
                    return (b[14].Equals(c) && b[16].Equals(c))
                        || (b[18].Equals(c) && b[21].Equals(c));
                case 16:
                    return (b[7].Equals(c) && b[11].Equals(c))
                        || (b[14].Equals(c) && b[15].Equals(c))
                        || (b[19].Equals(c) && b[22].Equals(c));
                case 17:
                    return (b[3].Equals(c) && b[9].Equals(c))
                        || (b[14].Equals(c) && b[20].Equals(c))
                        || (b[18].Equals(c) && b[19].Equals(c));
                case 18:
                    return (b[15].Equals(c) && b[21].Equals(c))
                        || (b[17].Equals(c) && b[19].Equals(c));
                case 19:
                    return (b[5].Equals(c) && b[12].Equals(c))
                        || (b[16].Equals(c) && b[22].Equals(c))
                        || (b[17].Equals(c) && b[18].Equals(c));
                case 20:
                    return (b[0].Equals(c) && b[8].Equals(c))
                        || (b[14].Equals(c) && b[17].Equals(c))
                        || (b[21].Equals(c) && b[22].Equals(c));
                case 21:
                    return (b[15].Equals(c) && b[18].Equals(c))
                        || (b[20].Equals(c) && b[22].Equals(c));
                case 22:
                    return (b[2].Equals(c) && b[13].Equals(c))
                        || (b[16].Equals(c) && b[19].Equals(c))
                        || (b[20].Equals(c) && b[21].Equals(c));
                default:
                    return false;
            }
        }

        public static List<T> Moves(T aBoard)
        {
            if (aBoard.IsOpening)
            {
                return MovesOpening(aBoard);
            }
            else
            {
                return MovesMidgameEndgame(aBoard);
            }
        }

        public static List<T> MovesOpening(T aBoard)
        {
            return Add(aBoard);
        }

        public static List<T> MovesMidgameEndgame(T aBoard)
        {
            if (aBoard.NumWhitePieces == 3)
            {
                return Hopping(aBoard);
            }
            else
            {
                return Move(aBoard);
            }
        }

        /**
         * Generates moves created by adding a white piece (to be used in the opening)
         */
        public static List<T> Add(T aBoard)
        {
            var l = new List<T>();
            for (int i = 0; i < aBoard.Length; i++)
            {
                if (aBoard[i].Equals(VariantDToken.EMPTY))
                {
                    var b = (T)Activator.CreateInstance(typeof(T), aBoard);
                    //var b = new T(aBoard);
                    b[i] = VariantDToken.WHITE;
                    if (closeMill(i, b))
                    {
                        l = Remove(b, l);
                    }
                    else
                    {
                        l.Add(b);
                    }
                }
            }
            return l;
        }

        /**
         * Generates moves created by white pieces hopping (to be used in the endgame)
         */
        public static List<T> Hopping(T aBoard)
        {
            var l = new List<T>();
            for (int alpha = 0; alpha < aBoard.Length; alpha++)
            {
                if (aBoard[alpha].Equals(VariantDToken.WHITE))
                {
                    for (int beta = 0; beta < aBoard.Length; beta++)
                    {
                        if (aBoard[beta].Equals(VariantDToken.EMPTY))
                        {
                            var b = (T)Activator.CreateInstance(typeof(T), aBoard);
                            //var b = new VariantDBoard(aBoard);
                            b[alpha] = VariantDToken.EMPTY;
                            b[beta] = VariantDToken.WHITE;
                            if (closeMill(beta, b))
                            {
                                l = Remove(b, l);
                            }
                            else
                            {
                                l.Add(b);
                            }
                        }
                    }
                }
            }
            return l;
        }

        /**
         * Generates moves created by moving a white piece to an adjacent location (to be used in the midgame)
         */
        public static List<T> Move(T aBoard)
        {
            var l = new List<T>();
            for (int location = 0; location < aBoard.Length; location++)
            {
                if (aBoard[location].Equals(VariantDToken.WHITE))
                {
                    var n = neighbors(location);
                    foreach (var j in n)
                    {
                        var b = (T)Activator.CreateInstance(typeof(T), aBoard);
                        //VariantDBoard b = new VariantDBoard(aBoard);
                        b[location] = VariantDToken.EMPTY;
                        b[j] = VariantDToken.WHITE;
                        if (closeMill(j, b))
                        {
                            l = Remove(b, l);
                        }
                        else
                        {
                            l.Add(b);
                        }
                    }
                }
            }
            return l;
        }

        /**
         * Generates moves created by removing a black piece from the board.
         */
        public static List<T> Remove(T aBoard, List<T> l)
        {
            bool added = false;
            for (int location = 0; location < aBoard.Length; location++)
            {
                if (aBoard[location].Equals(VariantDToken.BLACK))
                {
                    if (!closeMill(location, aBoard))
                    {
                        var b = (T)Activator.CreateInstance(typeof(T), aBoard);
                        //VariantDBoard b = new VariantDBoard(aBoard);
                        b[location] = VariantDToken.EMPTY;
                        l.Add(b);
                        added = true;
                    }
                }
            }

            if (!added)
            {
                // no positions were added (all black pieces are in mills)
                // add b to l?
                l.Add(aBoard);
            }
            return l;
        }

        public static List<T> BlackMove(T aBoard)
        {
            // swap the colors
            var tempb = swapTokens(aBoard);
            // generate all the positions reachable by a white move
            var l = Moves(tempb);
            // swap the colors back
            var swappedBack = new List<T>();
            foreach (var i in l)
            {
                swappedBack.Add(swapTokens(i));
            }
            return swappedBack;
        }

        private static T swapTokens(T aBoard)
        {
            var tempb = (T)Activator.CreateInstance(typeof(T), aBoard);
            //var tempb = new VariantDBoard(aBoard);
            for (int i = 0; i < tempb.Length; i++)
            {
                if (tempb[i].Equals(VariantDToken.BLACK))
                {
                    tempb[i] = VariantDToken.WHITE;
                }
                else if (tempb[i].Equals(VariantDToken.WHITE))
                {
                    tempb[i] = VariantDToken.BLACK;
                }
            }
            return tempb;
        }
    }
}
