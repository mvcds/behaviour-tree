using MVCDS.BehaviorTree.Library.Archetypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Composites
{
    public sealed class Sequence: Composite
    {
        public Sequence(bool random = false)
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
            try
            {
                Nodes.ForEach(Execute);
            }
            catch
            {
                return NodeStatus.Failure;
            }

            return IsRunning ? NodeStatus.Running : NodeStatus.Success;
        }

        private void Execute(INode node)
        {
            NodeStatus result = node.Process();
            if (result == NodeStatus.Failure)
                throw new Exception();
            else if (result == NodeStatus.Running)
                IsRunning = true;
        }
    }
}
