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
            try
            {
                Behaviour behaviour = new Behaviour(null);
            }
            catch(Exception e)
            {
                Assert.IsTrue(e is ArgumentNullException);
            }
        }

        [TestMethod]
        public void Node_Fails()
        {
            Mock<INode> node = TestHelper.Mock<INode>(NodeStatus.Failure);
            Behaviour behaviour = new Behaviour(node.Object);

            Assert.AreEqual(NodeStatus.Failure, behaviour.Process());
        }
    }
}
