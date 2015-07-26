using MVCDS.BehaviorTree.Library.Archetypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Decorators
{
    public sealed class Repeater : Decorator
    {
        public Repeater(INode node, Func<bool> shouldExecute)
            : base(node)
        {
            ShouldExecute = shouldExecute;
        }

        private Func<bool> ShouldExecute { get; set; }

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
