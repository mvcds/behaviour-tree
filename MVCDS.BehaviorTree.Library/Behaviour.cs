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

    //TODO: nodes shouldn't be refreshed?
    public interface INode
    {
        NodeStatus Result { get; }
    }

    //TODO: can I yield the return?
    /// <summary>
    /// MVCDS' implementation of a behaviour
    /// </summary>
    public sealed class Behaviour: INode
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

        public NodeStatus Result
        {
            get
            {
                NodeStatus result;
                do
                {
                    result = Root.Result;
                }
                while (result == NodeStatus.Running);
                return result;
            }
        }
    }
}
