using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMax
{
    public delegate List<T> MoveGenerator<T>(T aBoard);
}
