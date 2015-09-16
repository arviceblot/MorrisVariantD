using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMax
{
    public class VariantDToken : GameToken
    {
        public static readonly VariantDToken EMPTY = new VariantDToken("Empty", "x");
        public static readonly VariantDToken WHITE = new VariantDToken("White", "W");
        public static readonly VariantDToken BLACK = new VariantDToken("Black", "B");

        public VariantDToken(string name, string value)
            : base(name, value)
        {
        }
    }
}
