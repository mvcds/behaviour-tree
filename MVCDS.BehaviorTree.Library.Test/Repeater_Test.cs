using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCDS.BehaviorTree.Library.Decorators;
using Moq;

namespace MVCDS.BehaviorTree.Library.Test
{
    [TestClass]
    public class Repeater_Test
    {
        [TestMethod]
        public void Node_Succeeds()
        {
            Repeater cud = CreateRepeater(NodeStatus.Success, false);
            TestHelper.AssertProcess(cud, NodeStatus.Success);
        }

        [TestMethod]
        public void Node_Keeps_Running()
        {
            Repeater cud = CreateRepeater(NodeStatus.Running, false);
            TestHelper.AssertProcess(cud, NodeStatus.Running);
        }

        [TestMethod]
        public void Node_Fails()
        {
            Repeater cud = CreateRepeater(NodeStatus.Failure, false);
            TestHelper.AssertProcess(cud, NodeStatus.Failure);
        }

        [TestMethod]
        public void Reset_The_Yieldable()
        {
            Repeater cud = CreateRepeater(NodeStatus.Success, true);
            TestHelper.AssertProcess(cud, NodeStatus.Success);
            TestHelper.AssertProcess(cud, NodeStatus.Success);
            TestHelper.AssertProcess(cud, NodeStatus.Success);
            TestHelper.AssertProcess(cud, NodeStatus.Success);
            TestHelper.AssertProcess(cud, NodeStatus.Success);
            cud.Reset();
        }

        [TestMethod]
        public void Node_Throws_Exception()
        {
            int i = 3;
            Mock<INode> node = TestHelper.Mock<INode>(new Exception());
            Repeater cud = new Repeater(node.Object, () =>
            {
                return i-- >= 0;
            });
            TestHelper.AssertProcess(cud, NodeStatus.Failure);
        }

        private Repeater CreateRepeater(NodeStatus returns, bool yieldable)
        {
            int i = 3;
            Mock<INode> node = TestHelper.Mock<INode>(returns);
            
            return new Repeater(node.Object, () =>
            {
                return i-- >= 0;
            }, yieldable);
        }
    }
}
