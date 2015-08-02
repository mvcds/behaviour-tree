using MVCDS.BehaviorTree.Library.Composites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Archetypes
{
    public interface IComposite : INode
    {
        bool IsEmpty { get; }
        
        bool IsRandom { get; }

        INode[] Nodes { get; }

        void Add(INode node);
        
        //TODO: remove a node
    }

    abstract public partial class Composite : IComposite
    {
        public Composite(bool random = false)
        {
            _nodes = new List<INode>();
            IsRandom = random;
            
            if (IsRandom)
                Shuffler = new NodeShuffler(this);
        }

        private List<INode> _nodes;
        INode[] IComposite.Nodes
        {
            get
            {
                //TODO: copy the nodes before return them
                return _nodes.ToArray();
            }
        }

        public bool IsEmpty 
        { 
            get
            {
                return !_nodes.Any();
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
                return IsRandom ? Shuffler.Shuffled : _nodes;
            }
        }

        NodeShuffler Shuffler { get; set; }

        NodeStatus INode.Process()
        {
            _nodes.ForEach(InitALeaf);
            return Process();
        }

        public void Add(INode node)
        {
            _nodes.Add(node);
        }

        private void InitALeaf(INode node)
        {
            ILeaf leaf = node as ILeaf;
            if (leaf == null) 
                return;

            leaf.Refresh();
        }

        abstract protected NodeStatus Process();
    }
}
