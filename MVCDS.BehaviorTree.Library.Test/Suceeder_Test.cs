using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCDS.BehaviorTree.Library.Decorators;
using Moq;

namespace MVCDS.BehaviorTree.Library.Test
{
    [TestClass]
    public class Suceeder_Test
    {
        [TestMethod]
        public void Node_Succeeds()
        {
            Succeeder cud = CreateNode(NodeStatus.Success);
            TestHelper.AssertResult(cud, NodeStatus.Success);
        }

        [TestMethod]
        public void Node_Keeps_Running()
        {
            Succeeder cud = CreateNode(NodeStatus.Running);
            TestHelper.AssertResult(cud, NodeStatus.Success);
        }

        [TestMethod]
        public void Node_Fails()
        {
            Succeeder cud = CreateNode(NodeStatus.Failure);
            TestHelper.AssertResult(cud, NodeStatus.Success);
        }

        [TestMethod]
        public void Node_Throws_Exception()
        {
            Mock<INode> node = TestHelper.Mock<INode>(new Exception());
            Succeeder cud = new Succeeder(node.Object);
            TestHelper.AssertResult(cud, NodeStatus.Success);
        }

        private Succeeder CreateNode(NodeStatus returns)
        {
            Mock<INode> node = TestHelper.Mock<INode>(returns);
            return new Succeeder(node.Object);
        }
    }
}
