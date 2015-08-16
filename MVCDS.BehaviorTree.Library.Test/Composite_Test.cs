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
            Sequence sequence = new Sequence();

            sequence.Add(node.Object);

            Assert.IsTrue(sequence.Remove(node.Object));
            Assert.IsFalse(sequence.Remove(node.Object));
        }

        [TestMethod]
        public void Check_Random()
        {
            Sequence random = new Sequence(true);
            Assert.IsTrue(random.IsRandom);

            Sequence linear = new Sequence(false);
            Assert.IsFalse(linear.IsRandom);
        }

        [TestMethod]
        public void Reset_The_Yieldable()
        {
            Sequence sequence = new Sequence(false, true);
            if (sequence.IsYieldable)
                sequence.Reset();
            TestHelper.AssertResult<Sequence>(sequence, NodeStatus.Success);
        }
    }
}
