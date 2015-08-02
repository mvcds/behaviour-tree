using MVCDS.BehaviorTree.Library.Archetypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Decorators
{
    /// <summary>
    /// Repeats the proccess on its child until a condition is met
    /// </summary>
    public sealed class Repeater : Decorator
    {
        /// <summary>
        /// Creates the Repeates
        /// </summary>
        /// <param name="node">The node it may execute until a condition is met</param>
        /// <param name="shouldExecute">
        /// The function that makes the node be repeated/stopped
        /// </param>
        public Repeater(INode node, Func<bool> shouldExecute)
            : base(node)
        {
            ShouldExecute = shouldExecute;
        }

        private Func<bool> ShouldExecute { get; set; }

        /// <summary>
        /// Process its child
        /// </summary>
        /// <returns>The last status of its child or a failure</returns>
        protected override NodeStatus Process()
        {
            NodeStatus result = NodeStatus.Running;
            while (ShouldExecute())
            {
                try
                {
                    result = Child.Process();
                }
                catch
                {
                    return NodeStatus.Failure;
                }
            }
            return result;
        }

    }
}
