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

        bool Remmove(INode node);
    }

    /// <summary>
    /// MVCDS' implementation of a node which may contain N children
    /// </summary>
    abstract public partial class Composite : IComposite
    {
        /// <summary>
        /// Creates a Composite node
        /// </summary>
        /// <param name="random">
        /// <value>false</value> if the order of its nodes are processed matter
        /// <value>true</value> if the order of its nodes can be processed randomly
        /// </param>
        public Composite(bool random = false)
        {
            _nodes = new List<INode>();
            IsRandom = random;
            
            if (IsRandom)
                Shuffler = new Shuffler(this);
        }

        private List<INode> _nodes;

        /// <summary>
        /// Its nodes as they are
        /// </summary>
        INode[] IComposite.Nodes
        {
            get
            {
                //TODO: copy the nodes before return them
                return _nodes.ToArray();
            }
        }

        /// <summary>
        /// Does the node contain at least one node?
        /// </summary>
        public bool IsEmpty 
        { 
            get
            {
                return !_nodes.Any();
            }
        }

        /// <summary>
        /// Was this node created for random process or not?
        /// </summary>
        public bool IsRandom
        {
            get;
            private set;
        }

        /// <summary>
        /// Its node as they should be proccessed
        /// </summary>
        protected List<INode> Children
        {
            get
            {
                return IsRandom 
                    ? Shuffler.Shuffle() 
                    : (this as IComposite).Nodes
                        .ToList();
            }
        }

        Shuffler Shuffler { get; set; }

        /// <summary>
        /// Processes each node
        /// </summary>
        /// <returns>The last status of the node</returns>
        NodeStatus INode.Process()
        {
            _nodes.ForEach(InitALeaf);
            return Process();
        }

        /// <summary>
        /// Inserts a new node as its children
        /// </summary>
        /// <param name="node">The node to be added</param>
        public void Add(INode node)
        {
            _nodes.Add(node);
        }

        /// <summary>
        /// Removes the node, if available
        /// </summary>
        /// <param name="node">The node to be removed</param>
        /// <returns>true if item is successfully removed; otherwise, false</returns>
        public bool Remmove(INode node)
        {
            return _nodes.Remove(node);
        }

        private void InitALeaf(INode node)
        {
            ILeaf leaf = node as ILeaf;
            if (leaf == null) 
                return;

            leaf.Refresh();
        }

        /// <summary>
        /// Processes each node
        /// </summary>
        /// <returns>The last status of the node</returns>
        abstract protected NodeStatus Process();
    }
}
