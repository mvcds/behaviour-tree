using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library
{
    /// <summary>
    /// The status that a node may result
    /// </summary>
    public enum NodeStatus
    {
        Running,
        Success,
        Failure
    }

    public interface INode
    {
        NodeStatus Process();
    }

    /// <summary>
    /// MVCDS' implementation of a behaviour
    /// </summary>
    public class Behaviour: INode
    {
        private INode Root;

        /// <summary>
        /// Creates a behaviour
        /// </summary>
        /// <param name="root">The root node of the behaviour</param>
        public Behaviour(INode root)
        {
            if (root == null)
                throw new ArgumentNullException();

            Root = root;
        }

        /// <summary>
        /// Processes each node
        /// </summary>
        /// <returns>The last status of the behaviour</returns>
        public NodeStatus Process()
        {
            NodeStatus result;
            while ((result = Root.Process()) == NodeStatus.Running);
            return result;
        }
    }
}
