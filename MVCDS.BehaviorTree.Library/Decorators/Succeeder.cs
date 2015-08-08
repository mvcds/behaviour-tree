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

        public NodeStatus ChildResult { get; private set; }

        public override NodeStatus Result
        {
            get 
            {
                try
                {
                    ChildResult = Child.Result;
                }
                catch
                {
                }
                return NodeStatus.Success;
            }
        }
    }
}
