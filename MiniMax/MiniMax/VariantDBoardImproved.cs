using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMax
{
    public class VariantDBoardImproved : VariantDBoard
    {
        public VariantDBoardImproved(bool isOpening, string input = "")
            : base(isOpening, input)
        {
        }

        public VariantDBoardImproved(VariantDBoardImproved other)
            : base(other)
        {
        }

        public override int Static()
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

        public override int StaticMidgameEndgame()
        {
            if (numBlackPieces <= 2)
            {
                return 10;
            }
            else if (numWhitePieces <= 2)
            {
                return -10;
            }
            else if (numBlackMoves == 0)
            {
                return 10;
            }
            else
            {
                return numWhitePieces - numBlackPieces - numBlackMoves;
            }
        }
    }
}
