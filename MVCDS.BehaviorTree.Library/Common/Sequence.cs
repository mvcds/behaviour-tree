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
