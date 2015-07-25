using MVCDS.BehaviorTree.Library.Archetypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Decorators
{
    //TODO: try to use the repeater somewhere around here
    public sealed class RepeatUntilFail : Decorator
    {
        public RepeatUntilFail(INode node)
            : base(node)
        {
        }

        protected override NodeStatus Process()
        {
            NodeStatus result = NodeStatus.Running;
            while (result != NodeStatus.Failure)
                result = Child.Process();
            return NodeStatus.Success;
        }

    }
}
