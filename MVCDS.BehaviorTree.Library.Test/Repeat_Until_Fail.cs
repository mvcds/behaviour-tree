using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCDS.BehaviorTree.Library.Decorators;
using Moq;
using System.Collections.Generic;

namespace MVCDS.BehaviorTree.Library.Test
{
    [TestClass]
    public class Repeat_Until_Fail
    {
        private class TestableLeaf : INode
        {
            public TestableLeaf()
            {
                Results = new Queue<NodeStatus>();
                Results.Enqueue(NodeStatus.Success);
                Results.Enqueue(NodeStatus.Running);
                Results.Enqueue(NodeStatus.Failure);
            }

            Queue<NodeStatus> Results { get; set; }
            
            public NodeStatus Process()
            {
                return Results.Dequeue();
            }
        }

        [TestMethod]
        public void Node_Succeeds()
        {
            RepeatUntilFail cud = new RepeatUntilFail(new TestableLeaf());
            TestHelper.AssertProcess<RepeatUntilFail>(cud, NodeStatus.Success);
        }
    }
}
