using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Archetypes
{
    abstract public class Composite: INode
    {
        public Composite()
        {
            Children = new List<INode>();
        }

        public List<INode> Children
        {
            get;
            private set;
        }

        public bool IsEmpty 
        { 
            get
            {
                return !Children.Any();
            }
        }

        NodeStatus INode.Process()
        {
            Children.ForEach(InitALeaf);
            return Process();
        }

        private void InitALeaf(INode node)
        {
            Leaf leaf = node as Leaf;
            if (leaf == null) 
                return;

            leaf.Init();
        }

        abstract protected NodeStatus Process();

    }
}
