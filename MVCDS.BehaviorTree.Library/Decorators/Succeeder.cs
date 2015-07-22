using MVCDS.BehaviorTree.Library.Archetypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Decorators
{
    public sealed class Succeeder: Decorator
    {
        public Succeeder(INode node)
            : base(node)
        {
        }

        protected override NodeStatus Process()
        {
            Child.Process();
            return NodeStatus.Success;
        }
    }
}
