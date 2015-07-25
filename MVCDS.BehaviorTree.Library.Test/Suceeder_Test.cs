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
            Succeeder CUD = CreateNode(NodeStatus.Success);
            Asserts(CUD);
        }

        [TestMethod]
        public void Node_Keeps_Running()
        {
            Succeeder CUD = CreateNode(NodeStatus.Running);
            Asserts(CUD);
        }

        [TestMethod]
        public void Node_Fails()
        {
            Succeeder CUD = CreateNode(NodeStatus.Failure);
            Asserts(CUD);
        }

        [TestMethod]
        public void Node_Throws_Exception()
        {
            Mock<INode> node = TestHelper.Mock<INode>(new Exception());
            Succeeder CUD = new Succeeder(node.Object);
            Asserts(CUD);
        }

        private void Asserts(Succeeder cud)
        {
            NodeStatus result = (cud as INode).Process();
            Assert.AreEqual(NodeStatus.Success, result);
        }

        private Succeeder CreateNode(NodeStatus returns)
        {
            Mock<INode> node = TestHelper.Mock<INode>(returns);
            return new Succeeder(node.Object);
        }
    }
}
