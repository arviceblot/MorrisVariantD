using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMax
{
    public class VariantDBoard : GameBoard
    {
        protected GameToken[] board;
        public GameToken[] Board
        {
            get { return board; }
        }

        public int Length
        {
            get { return board.Length; }
        }

        protected int numWhitePieces;
        public int NumWhitePieces
        {
            get { return numWhitePieces; }
        }

        protected int numBlackPieces;

        protected int numWhiteMoves;
        public int NumWhiteMoves
        {
            get { return numWhiteMoves; }
            set { numWhiteMoves = value; }
        }

        protected int numBlackMoves;
        public int NumBlackMoves
        {
            get { return numBlackMoves; }
            set { numBlackMoves = value; }
        }

        protected bool isOpening;
        public bool IsOpening
        {
            get { return isOpening; }
        }

        public VariantDBoard(bool isOpening, string input = "")
        {
            board = new GameToken[23];
            this.isOpening = isOpening;
            if (!input.Equals(""))
            {
                ImportFromString(input);
            }

            UpdateNumPieces();
        }

        public VariantDBoard(VariantDBoard other)
        {
            board = new GameToken[other.board.Length];
            Array.Copy(other.board, board, other.board.Length);

            numWhitePieces = other.numWhitePieces;
            numBlackPieces = other.numBlackPieces;
            numWhiteMoves = other.numWhiteMoves;
            numBlackMoves = other.numBlackMoves;
            isOpening = other.isOpening;
        }

        public GameToken this[int index]
        {
            get { return board[index]; }
            set
            {
                board[index] = value;
                UpdateNumPieces();
            }
        }

        private void UpdateNumPieces()
        {
            numWhitePieces = 0;
            numBlackPieces = 0;
            foreach (GameToken token in board)
            {
                if (token.Equals(VariantDToken.WHITE))
                {
                    numWhitePieces++;
                }
                else if (token.Equals(VariantDToken.BLACK))
                {
                    numBlackPieces++;
                }
            }
        }

        public string Print()
        {
            string output = "";
            output += board[20].Value + "-----" + board[21].Value + "-----" + board[22].Value + "\n"
                + "|\\    |    /|\n"
                + "| " + board[17].Value + "---" + board[18].Value + "---" + board[19].Value + " |\n"
                + "| |\\  |  /| |\n"
                + "| | " + board[14].Value + "-" + board[15].Value + "-" + board[16].Value + " | |\n"
                + "| | |   | | |\n"
                + board[8].Value + "-" + board[9].Value + "-" + board[10].Value + "   " + board[11].Value + "-" + board[12].Value + "-" + board[13].Value + "\n"
                + "| | |   | | |\n"
                + "| | " + board[6].Value + "---" + board[7].Value + " | |\n"
                + "| |/     \\| |\n"
                + "| " + board[3].Value + "---" + board[4].Value + "---" + board[5].Value + " |\n"
                + "|/    |    \\|\n"
                + board[0].Value + "-----" + board[1].Value + "-----" + board[2].Value + "\n";
            return output;
        }

        public override string ToString()
        {
            string output = "";
            for (int i = 0; i < board.Length; i++)
            {
                output += board[i].Value;
            }
            return output;
        }

        private bool ImportFromString(string input)
        {
            if (input.Length != 23)
            {
                return false;
            }
            else
            {
                board = new GameToken[23];
                for (int i = 0; i < 23; i++)
                {
                    string c = Convert.ToString(input[i]);
                    if (c.Equals(VariantDToken.WHITE.Value))
                    {
                        board[i] = VariantDToken.WHITE;
                    }
                    else if (c.Equals(VariantDToken.BLACK.Value))
                    {
                        board[i] = VariantDToken.BLACK;
                    }
                    else
                    {
                        board[i] = VariantDToken.EMPTY;
                    }
                }
                UpdateNumPieces();
                return true;
            }
        }

        public virtual int Static()
        {
            if (isOpening)
            {
                return StaticOpening();
            }
            else
            {
                return StaticMidgameEndgame();
            }
        }

        public virtual int StaticOpening()
        {
            return numWhitePieces - numBlackPieces;
        }

        public virtual int StaticMidgameEndgame()
        {
            if (numBlackPieces <= 2)
            {
                return 10000;
            }
            else if (numWhitePieces <= 2)
            {
                return -10000;
            }
            else if (numBlackMoves == 0)
            {
                return 10000;
            }
            else
            {
                return 1000 * (numWhitePieces - numBlackPieces) - numBlackMoves;
            }
        }
    }
}
