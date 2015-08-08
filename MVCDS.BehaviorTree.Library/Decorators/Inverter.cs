using MVCDS.BehaviorTree.Library.Archetypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Decorators
{
    /// <summary>
    /// Inverts the result of its child
    /// </summary>
    public sealed class Inverter: Decorator
    {
        /// <summary>
        /// Creates the Inverter
        /// </summary>
        /// <param name="node">The node it may invert</param>
        public Inverter(INode node)
            : base(node)
        {
        }

        public override NodeStatus Result
        {
            get 
            {
                NodeStatus result = Child.Result;
                switch(result)
                {
                    case NodeStatus.Success:
                        return NodeStatus.Failure;
                    case NodeStatus.Failure:
                        return NodeStatus.Success;
                }

                return NodeStatus.Running;
            }
        }
    }
}
