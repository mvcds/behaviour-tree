using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCDS.BehaviorTree.Library.Composites;

namespace MVCDS.BehaviorTree.Library.Test
{
    [TestClass]
    public class Composite_Test
    {
        [TestMethod]
        public void Remove_Node()
        {
            Mock<INode> node = TestHelper.Mock<INode>();
            Sequence inverter = new Sequence();

            inverter.Add(node.Object);

            Assert.IsTrue(inverter.Remove(node.Object));
            Assert.IsFalse(inverter.Remove(node.Object));
        }
    }
}
