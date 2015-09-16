using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMax
{
    public class GameToken : System.Object
    {
        protected string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        protected string value;
        public string Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public GameToken(string name, string value)
        {
            this.name = name;
            this.value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            GameToken t = obj as GameToken;
            if ((System.Object)t == null)
            {
                return false;
            }

            return name.Equals(t.name) && value.Equals(t.value);
        }

        public bool Equals(GameToken t)
        {
            if ((object)t == null)
            {
                return false;
            }

            return name.Equals(t.name) && value.Equals(t.value);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
