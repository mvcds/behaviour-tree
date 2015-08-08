using MVCDS.BehaviorTree.Library.Archetypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Decorators
{
    /// <summary>
    /// Repeats the proccess on its child until it fails
    /// </summary>
    public sealed class RepeatUntilFail : Decorator
    {
        public RepeatUntilFail(INode node)
            : base(node)
        {
            //TODO: can I use the repeater inside?
        }

        //TODO: use the result to not need the setter
        private bool HasFailed { get; set; }

        public override NodeStatus Result
        {
            get 
            {
                HasFailed = false;

                return Execute();
            }
        }

        private NodeStatus Execute()
        {
            NodeStatus result = Child.Result;
            if (result == NodeStatus.Failure)
                HasFailed = true;
            return HasFailed ? NodeStatus.Success : Execute();
        }
    }
}
