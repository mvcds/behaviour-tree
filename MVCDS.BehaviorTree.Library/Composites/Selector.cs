using MVCDS.BehaviorTree.Library.Archetypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Composites
{
    public sealed class Selector : Composite
    {
        public Selector(bool random = false)
            : base(random)
        {
        }
        
        bool IsRunning { get; set; }

        protected override NodeStatus Process()
        {
            if (IsEmpty)
                return NodeStatus.Success;

            IsRunning = false;

            return Execute();
        }

        private NodeStatus Execute()
        {
            foreach (INode child in Children)
            {
                NodeStatus result = child.Process();
                if (result == NodeStatus.Success)
                    return NodeStatus.Success;
                else if (result == NodeStatus.Running)
                    IsRunning = true;
            }

            return IsRunning ? NodeStatus.Running : NodeStatus.Failure;
        }
    }
}
