using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MVCDS.BehaviorTree.Library.Test
{
    [TestClass]
    public class Behaviour_Test
    {
        [TestMethod]
        public void No_Root()
        {
            CreateBehaviour(null, false);
        }

        [TestMethod]
        public void Node_Fails()
        {
            Mock<INode> node = TestHelper.Mock<INode>(NodeStatus.Failure);
            Behaviour behaviour = CreateBehaviour(node.Object, false);

            Assert.AreEqual(NodeStatus.Failure, behaviour.Result);
        }

        [TestMethod]
        public void Reset_Yieldable()
        {
            Mock<INode> node = TestHelper.Mock<INode>(NodeStatus.Failure);
            Behaviour behaviour = CreateBehaviour(node.Object, true);

            Assert.AreEqual(NodeStatus.Failure, behaviour.Result);
            behaviour.Reset();
            Assert.AreEqual(NodeStatus.Failure, behaviour.Result);
        }

        private Behaviour CreateBehaviour(INode node, bool yieldable)
        {
            try
            {
                return new Behaviour(node, yieldable);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is ArgumentNullException);
                return null;
            }
        }
    }
}
