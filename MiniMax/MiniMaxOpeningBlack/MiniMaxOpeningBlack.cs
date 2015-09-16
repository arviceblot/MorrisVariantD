using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniMax;

namespace MiniMaxOpeningBlack
{
    class MiniMaxOpeningBlack
    {
        static void Main(string[] args)
        {
            string inputFile;
            string outputFile;
            int treeDepth;
            string inputBoardAsAtring = "xxxxxxxxxWxxxxxxBxxxxxx";

            if (args.Length < 3)
            {
                inputFile = "board1.txt";
                outputFile = "boardb2.txt";
                treeDepth = 3;
            }
            else
            {
                inputFile = args[0];
                outputFile = args[1];
                treeDepth = Convert.ToInt32(args[2]);
            }

            // read the board as a string from the input file
            inputBoardAsAtring = System.IO.File.ReadAllLines(@"" + inputFile)[0];

            var board = new VariantDBoard(true, inputBoardAsAtring);
            Console.WriteLine(board.Print());

            var movesGen = new MoveGenerator<VariantDBoard>(VariantDMoveGenerator<VariantDBoard>.Moves);
            var blackGen = new MoveGenerator<VariantDBoard>(VariantDMoveGenerator<VariantDBoard>.BlackMove);
            var root = new GameNode<VariantDBoard>(board, null, treeDepth, blackGen, movesGen, false);
            var minmax = new MiniMax.MiniMax<VariantDBoard>();
            var score = minmax.MiniMaxBase(root);
            var move = score.Item1.GetParentAtDepth(1);

            Console.WriteLine(move.Board.Print());
            Console.WriteLine("Nodes generated: " + root.NumNodes() + ".");

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
