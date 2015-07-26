using MVCDS.BehaviorTree.Library.Archetypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Decorators
{
    public sealed class RepeatUntilFail : Decorator
    {
        public RepeatUntilFail(INode node)
            : base(node)
        {
        }

        bool HasFailed { get; set; }

        protected override NodeStatus Process()
        {
            HasFailed = false;

            return Execute();
        }

        private NodeStatus Execute()
        {
            if (Child.Process() == NodeStatus.Failure)
                HasFailed = true;
            return HasFailed ? NodeStatus.Success : Execute();
        }
    }
}
