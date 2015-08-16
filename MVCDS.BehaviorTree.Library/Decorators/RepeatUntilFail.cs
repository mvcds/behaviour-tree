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
    public sealed class RepeatUntilFail : Decorator, IYieldable
    {
        public RepeatUntilFail(INode node, bool yieldable = false)
            : base(node)
        {
            //TODO: can I use the repeater inside?
            IsYieldable = yieldable;
        }

        //TODO: use the result to not need the setter
        private bool HasFailed { get; set; }

        public override NodeStatus Result
        {
            get 
            {
                //it only can return success when it's not yieldable
                if (result != NodeStatus.Running && !IsYieldable)
                    return NodeStatus.Success;

                HasFailed = false;

                return Execute();
            }
        }

        public bool IsYieldable
        {
            get;
            private set;
        }

        NodeStatus result;
        private NodeStatus Execute()
        {
            result = Child.Result;

            if (result == NodeStatus.Failure)
                HasFailed = true;

            if (HasFailed)
                return NodeStatus.Success;

            if (IsYieldable)
                return NodeStatus.Running;

            return Execute();
        }

        public void Reset()
        {
            result = NodeStatus.Running;
        }
    }
}
