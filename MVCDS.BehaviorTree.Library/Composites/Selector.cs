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

        protected override NodeStatus Process()
        {
            if (IsEmpty)
                return NodeStatus.Success;

            foreach (INode child in Children)
            {
                NodeStatus result = child.Process();
                if (result != NodeStatus.Running)
                    return result;
            }

            return NodeStatus.Running;
        }
    }
}
