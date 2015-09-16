using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMax
{
    public interface GameBoard
    {
        GameToken[] Board
        {
            get;
        }

        int Length
        {
            get;
        }

        GameToken this[int index]
        {
            get;
            set;
        }

        int Static();
        string Print();
        string ToString();
    }
}
