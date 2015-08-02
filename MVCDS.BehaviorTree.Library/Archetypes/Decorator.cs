using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Archetypes
{
    public interface IDecorator : INode
    {
        INode Child { get; }
    }

    /// <summary>
    /// MVCDS' implementation of a node which may contain only one child
    /// </summary>
    public abstract class Decorator : IDecorator
    {
        /// <summary>
        /// Creates a decorator node
        /// </summary>
        /// <param name="node">The node it may process</param>
        public Decorator(INode node)
        {
            if (node == null)
                throw new ArgumentNullException();

            Child = node;
        }

        /// <summary>
        /// The node it contains
        /// </summary>
        //TODO: copy the nodes before return them
        public INode Child { get; private set; }

        /// <summary>
        /// Processes its node
        /// </summary>
        /// <returns>The last status of the node</returns>
        NodeStatus INode.Process()
        {
            return Process();
        }

        /// <summary>
        /// Processes its node
        /// </summary>
        /// <returns>The last status of the node</returns>
        abstract protected NodeStatus Process();
    }
}
