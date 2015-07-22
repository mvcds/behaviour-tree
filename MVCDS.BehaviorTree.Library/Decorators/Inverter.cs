using MVCDS.BehaviorTree.Library.Archetypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Decorators
{
    public sealed class Inverter: Decorator
    {
        public Inverter(INode node)
            : base(node)
        {
        }

        protected override NodeStatus Process()
        {
            NodeStatus result = Child.Process();

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
