using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCDS.BehaviorTree.Library.Decorators;
using Moq;

namespace MVCDS.BehaviorTree.Library.Test
{
    [TestClass]
    public class Inverter_Test
    {
        [TestMethod]
        public void Node_Succeeds()
        {
            Inverter cud = CreateNode(NodeStatus.Success);
            TestHelper.AssertProcess<Inverter>(cud, NodeStatus.Failure);
        }

        [TestMethod]
        public void Node_Keeps_Running()
        {
            Inverter cud = CreateNode(NodeStatus.Running);
            TestHelper.AssertProcess<Inverter>(cud, NodeStatus.Running);
        }

        [TestMethod]
        public void Node_Fails()
        {
            Inverter cud = CreateNode(NodeStatus.Failure);
            TestHelper.AssertProcess<Inverter>(cud, NodeStatus.Success);
        }

        private Inverter CreateNode(NodeStatus returns)
        {
            Mock<INode> node = TestHelper.Mock<INode>(returns);
            return new Inverter(node.Object);
        }
    }
}
