using MVCDS.BehaviorTree.Library.Composites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Archetypes
{
    abstract public partial class Composite: INode
    {
        public Composite(bool random = false)
        {
            Nodes = new List<INode>();
            IsRandom = random;
            
            if (IsRandom)
                Shuffler = new NodeShuffler(this);
        }

        private List<INode> Nodes
        {
            get;
            set;
        }

        public bool IsEmpty 
        { 
            get
            {
                return !Nodes.Any();
            }
        }

        public bool IsRandom
        {
            get;
            private set;
        }

        protected List<INode> Children
        {
            get
            {
                return IsRandom ? Shuffler.Shuffled : Nodes;
            }
        }

        NodeShuffler Shuffler { get; set; }

        NodeStatus INode.Process()
        {
            Nodes.ForEach(InitALeaf);
            return Process();
        }

        public void Add(INode node)
        {
            Nodes.Add(node);
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
