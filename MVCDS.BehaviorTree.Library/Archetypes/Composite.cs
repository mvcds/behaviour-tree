using MVCDS.BehaviorTree.Library.Composites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Archetypes
{
    abstract public class Composite: INode
    {
        public Composite(bool random = false)
        {
            Children = new List<INode>();
            IsRandom = random;
            
            if (IsRandom)
                Shuffler = new NodeShuffler(this);
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

        public bool IsRandom
        {
            get;
            private set;
        }

        protected List<INode> Nodes
        {
            get
            {
                return IsRandom ? Shuffler.Shuffled : Children;
            }
        }

        NodeShuffler Shuffler { get; set; }

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
