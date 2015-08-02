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

        private bool HasFailed { get; set; }

        /// <summary>
        /// Process its child
        /// </summary>
        /// <returns>Success</returns>
        //TODO: review my "always success politic"
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
