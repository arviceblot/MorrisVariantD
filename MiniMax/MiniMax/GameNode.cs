using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMax
{
    public class GameNode<T> where T : GameBoard
    {
        protected T board;
        public T Board
        {
            get { return board; }
        }

        protected int depth;
        public int Depth
        {
            get { return depth; }
            set { depth = value; }
        }

        protected List<GameNode<T>> children;
        public List<GameNode<T>> Children
        {
            get { return children; }
            set { children = value; }
        }

        protected int maxDepth;
        public int MaxDepth
        {
            get { return maxDepth; }
        }

        protected GameNode<T> parent;
        public GameNode<T> Parent
        {
            get { return parent; }
        }

        protected bool isMax;
        public bool IsMax
        {
            get { return isMax; }
        }

        public bool IsRoot()
        {
            return parent == null;
        }

        public GameNode<T> GetParentAtDepth(int i)
        {
            if (i == depth)
            {
                return this;
            }
            else
            {
                return parent.GetParentAtDepth(i--);
            }
        }

        public int NumNodes()
        {
            if (IsLeaf())
            {
                return 1;
            }
            else
            {
                int nodes = 1;
                foreach (var child in children)
                {
                    nodes += child.NumNodes();
                }
                return nodes;
            }
        }

        public GameNode(T board, GameNode<T> parent, int maxDepth, MoveGenerator<T> moveGenerator, MoveGenerator<T> oppMoveGenerator, bool isMax)
        {
            this.board = board;

            if (parent == null)
            {
                // this is the root node, there is no parent
                this.depth = 0;
            }
            else
            {
                this.depth = parent.depth + 1;
            }
            this.parent = parent;

            this.maxDepth = maxDepth;
            this.isMax = isMax;

            children = new List<GameNode<T>>();
            if (depth <= maxDepth)
            {
                GenerateChildren(moveGenerator, oppMoveGenerator);
            }
        }

        public bool IsLeaf()
        {
            return children.Count == 0;
        }

        protected void GenerateChildren(MoveGenerator<T> moveGenerator, MoveGenerator<T> oppMoveGenerator)
        {
            children.Clear();
            var moves = moveGenerator(board);
            foreach (var  move in moves)
            {
                children.Add(new GameNode<T>(move, this, maxDepth, oppMoveGenerator, moveGenerator, !isMax));
            }
        }
    }
}
