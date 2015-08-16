using MVCDS.BehaviorTree.Library.Composites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Archetypes
{
    /// <summary>
    /// MVCDS' implementation of a node which may contain N children
    /// </summary>
    abstract public class Composite : IComposite, IYieldable
    {
        /// <summary>
        /// Creates a Composite node
        /// </summary>
        /// <param name="random">
        /// <value>false</value> if the order of its nodes are processed matter
        /// <value>true</value> if the order of its nodes can be processed randomly
        /// </param>
        public Composite(bool random = false, bool yieldable = false)
        {
            _nodes = new List<INode>();
            Processor = new CompositeProcessor(this, random, yieldable);
        }

        private List<INode> _nodes;
                
        INode[] IComposite.Children
        {
            get
            {
                //TODO: copy the nodes before return them?
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
            get
            {
                return Processor.IsRandom;
            }
        }

        public bool IsYieldable 
        {
            get
            {
                return Processor.IsYieldable;
            }
        }

        abstract public NodeStatus Result
        {
            get;
        }

        protected CompositeProcessor Processor { get; private set; }

        /// <summary>
        /// Inserts a new node as its children
        /// </summary>
        /// <param name="node">The node to be added</param>
        public void Add(INode node)
        {
            _nodes.Add(node);
        }

        public void Add(IEnumerable<INode> nodes)
        {
            _nodes.AddRange(nodes);
        }

        /// <summary>
        /// Removes the node, if available
        /// </summary>
        /// <param name="node">The node to be removed</param>
        /// <returns>true if item is successfully removed; otherwise, false</returns>
        public bool Remove(INode node)
        {
            return _nodes.Remove(node);
        }

        public void Reset()
        {
            Processor.Reset();
        }
    }
}
