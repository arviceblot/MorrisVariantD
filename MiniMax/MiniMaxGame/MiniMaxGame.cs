using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniMax;

namespace MiniMaxGame
{
    class MiniMaxGame
    {
        /**
         * Get the next move for W int the midgame/endgame.
         * This will involve moving for B, the W.
         */
        static void Main(string[] args)
        {
            string inputFile;
            string outputFile;
            int treeDepth;
            string inputBoardAsAtring = "xxxxxxxxxxWWxWWxBBBxxxx";

            if (args.Length < 3)
            {
                inputFile = "board3.txt";
                outputFile = "board4.txt";
                treeDepth = 4;
            }
            else
            {
                inputFile = args[0];
                outputFile = args[1];
                treeDepth = Convert.ToInt32(args[2]);
            }

            // read the board as a string from the input file
            inputBoardAsAtring = System.IO.File.ReadAllLines(@"" + inputFile)[0];

            var board = new VariantDBoard(false, inputBoardAsAtring);
            Console.WriteLine(board.Print());

            var movesGen = new MoveGenerator<VariantDBoard>(VariantDMoveGenerator<VariantDBoard>.Moves);
            var blackGen = new MoveGenerator<VariantDBoard>(VariantDMoveGenerator<VariantDBoard>.BlackMove);
            var root = new GameNode<VariantDBoard>(board, null, treeDepth, movesGen, blackGen, true);
            var minmax = new MiniMax.MiniMax<VariantDBoard>();
            var score = minmax.MiniMaxBase(root);
            var move = score.Item1.GetParentAtDepth(1);

            Console.WriteLine("Nodes generated: " + root.NumNodes() + ".");

            Console.WriteLine(move.Board.Print());

            string[] lines =
                { "Board Position: " + move.Board.ToString(),
                "Positions evaluated by static estimation: " + minmax.StaticEvals + ".",
                "MINIMAX estimate: " + score.Item2 + "."
            };
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
            System.IO.File.WriteAllLines(@"" + outputFile, lines);
        }
    }
}
