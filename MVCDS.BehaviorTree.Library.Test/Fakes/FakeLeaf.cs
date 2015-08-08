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
            MyResult = result;
        }

        public override void Refresh()
        {
        }

        private NodeStatus MyResult
        {
            get;
            set;
        }

        protected override NodeStatus Process()
        {
            Refresh();
            return (Result = MyResult);
        }
    }
}
