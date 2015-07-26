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
            Repeater cud = CreateNode(NodeStatus.Success);
            TestHelper.AssertProcess<Repeater>(cud, NodeStatus.Success);
        }

        [TestMethod]
        public void Node_Keeps_Running()
        {
            Repeater cud = CreateNode(NodeStatus.Running);
            TestHelper.AssertProcess(cud, NodeStatus.Running);
        }

        [TestMethod]
        public void Node_Fails()
        {
            Repeater cud = CreateNode(NodeStatus.Failure);
            TestHelper.AssertProcess(cud, NodeStatus.Failure);
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

        private Repeater CreateNode(NodeStatus returns)
        {
            int i = 3;
            Mock<INode> node = TestHelper.Mock<INode>(returns);
            
            return new Repeater(node.Object, () =>
            {
                return i-- >= 0;
            });
        }
    }
}
