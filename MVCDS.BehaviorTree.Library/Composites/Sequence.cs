using MVCDS.BehaviorTree.Library.Archetypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Composites
{
    public class Sequence: Composite, IRandom
    {
        public Sequence(bool random = false)
        {
            IsRandom = random;
        }

        public bool IsRandom { get; private set; }

        bool IsRunning { get; set; }

        protected override NodeStatus Process()
        {
            if (IsEmpty)
                return NodeStatus.Success;

            IsRunning = false;

            List<INode> children = IsRandom
                ? Children.OrderBy(p => Guid.NewGuid())
                    .ToList()
                : Children;

            try 
            {
                children.ForEach(Execute);
            }
            catch
            {
                return NodeStatus.Failure;
            }

            return IsRunning ? NodeStatus.Running : NodeStatus.Success;
        }

        private void Execute(INode child)
        {
            NodeStatus result = child.Process();
            if (result == NodeStatus.Failure)
                throw new Exception();
            else if (result == NodeStatus.Running)
                IsRunning = true;
        }
    }
}
