using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library
{
    /// <summary>
    /// MVCDS' implementation of a behaviour
    /// </summary>
    public sealed class Behaviour: INode, IYieldable
    {
        private INode Root;

        /// <summary>
        /// Creates a behaviour
        /// </summary>
        /// <param name="root">The root node of the behaviour</param>
        public Behaviour(INode root, bool yieldable = false)
        {
            if (root == null)
                throw new ArgumentNullException();

            Root = root;
            IsYieldable = yieldable;
        }

        NodeStatus result;
        public NodeStatus Result
        {
            get
            {
                while (result == NodeStatus.Running)
                {
                    result = Root.Result;
                    if (IsYieldable)
                        break;
                }
                return result;
            }
        }

        public bool IsYieldable
        {
            get;
            private set;
        }

        public void Reset()
        {
            result = NodeStatus.Running;
        }
    }
}
