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
            CreateBehaviour(null);
        }

        [TestMethod]
        public void Node_Fails()
        {
            Mock<INode> node = TestHelper.Mock<INode>(NodeStatus.Failure);
            Behaviour behaviour = CreateBehaviour(node.Object);

            Assert.AreEqual(NodeStatus.Failure, behaviour.Process());
        }

        private Behaviour CreateBehaviour(INode node)
        {
            try
            {
                return new Behaviour(node);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is ArgumentNullException);
                return null;
            }
        }
    }
}
