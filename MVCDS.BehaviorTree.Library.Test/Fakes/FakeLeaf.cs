using MVCDS.BehaviorTree.Library.Archetypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Test.Fake
{

    internal class FakeLeaf : Leaf
    {
        public FakeLeaf(NodeStatus result)
        {
            Result = result;
        }

        NodeStatus Result { get; set; }

        public override void Refresh()
        {
        }

        protected override NodeStatus Process()
        {
            return Result;
        }
    }
}
