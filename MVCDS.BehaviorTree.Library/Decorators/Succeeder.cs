using MVCDS.BehaviorTree.Library.Archetypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Decorators
{
    /// <summary>
    /// Always returns success
    /// </summary>
    public sealed class Succeeder: Decorator
    {
        /// <summary>
        /// Creates a Succeeder
        /// </summary>
        /// <param name="node">The node it may execute without given errors</param>
        public Succeeder(INode node)
            : base(node)
        {
        }

        /// <summary>
        /// Process its child
        /// </summary>
        /// <returns>Success</returns>
        protected override NodeStatus Process()
        {
            try
            {
                Child.Process();
            }
            catch
            {
            }
            return NodeStatus.Success;
        }
    }
}
