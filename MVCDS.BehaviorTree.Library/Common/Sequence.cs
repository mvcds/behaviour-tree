using MVCDS.BehaviorTree.Library.Archetypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Common
{
    sealed public class Sequence: Composite
    {
        public Sequence()
        {
            base.Process(SequencialProcess);
        }

        private NodeStatus SequencialProcess()
        {
            NodeStatus result = NodeStatus.Running;
            for (var i = 0; i < Children.Count; i++)
            {
                result = Children[i].Process();
                if (result == NodeStatus.Failure)
                    return NodeStatus.Failure;
            }

            return result;
        }
    }
}
