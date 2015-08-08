using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Archetypes
{
    /// <summary>
    /// MVCDS's implementatiomn of a node which cannot contain any children
    /// </summary>
    public abstract class Leaf : ILeaf
    {
        /// <summary>
        /// Creates a leaf node
        /// </summary>
        public Leaf()
        {
            actions = new Dictionary<NodeStatus, Action>()
            {
                { NodeStatus.Running, null},
                { NodeStatus.Failure, null},
                { NodeStatus.Success, null},
            };
        }

        private NodeStatus _last = NodeStatus.Running;

        private NodeStatus Result
        {
            get
            {
                return _last;
            }
            set
            {
                if (_last != value)
                {
                    Action action = actions[value];
                    if (action != null)
                        action();
                    _last = value;
                }
            }
        }

        private Dictionary<NodeStatus, Action> actions;
        
        /// <summary>
        /// Processes each node
        /// </summary>
        /// <returns>The last status of the node</returns>
        NodeStatus INode.Process()
        {
            Result = Process();
            return Result;
        }

        /// <summary>
        /// Allows to add special behaviour when something changes
        /// </summary>
        /// <typeparam name="T">A leaf</typeparam>
        /// <param name="status">The status which triggers the event</param>
        /// <param name="do">The event itself</param>
        /// <returns>The leaf that was changed, so it can be chained up</returns>
        public T When<T>(NodeStatus status, Action @do = null)
            where T : Leaf
        {
            actions[status] = @do;
            return this as T;
        }

        /// <summary>
        /// Processes each node
        /// </summary>
        /// <returns>The last status of the node</returns>
        abstract protected NodeStatus Process();

        /// <summary>
        /// Allows the leaf to be updated
        /// </summary>
        abstract public void Refresh();
    }
}
