using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCDS.BehaviorTree.Library.Archetypes;
using MVCDS.BehaviorTree.Library.Composites;
using MVCDS.BehaviorTree.Library.Test.Fake;
using MVCDS.BehaviorTree.Library.Decorators;

namespace MVCDS.BehaviorTree.Library.Test
{
    [TestClass]
    public class Composite_Processor_Test
    {
        [TestMethod]
        public void With_Null_Processor()
        {
            CreateProcessor(null, false, false);
        }

        [TestMethod]
        public void With_Processor()
        {
            Mock<IComposite> composite = new Mock<IComposite>(MockBehavior.Strict);
            CreateProcessor(composite.Object, false, false);
        }

        [TestMethod]
        public void With_Yieldable_Sequence()
        {
            Sequence sequence = new Sequence(false, true);
            TestLastResult(sequence);
        }

        [TestMethod]
        public void With_Yieldable_Selector()
        {
            Selector selector = new Selector(false, true);
            TestLastResult(selector);
        }

        private static void TestLastResult(IComposite composite)
        {
            FakeProcesses.CreateNodes(composite, NodeStatus.Running, NodeStatus.Running, NodeStatus.Success);

            TestHelper.AssertProcess(composite, NodeStatus.Running);
            TestHelper.AssertProcess(composite, NodeStatus.Running);
            TestHelper.AssertProcess(composite, NodeStatus.Success);
            TestHelper.AssertProcess(composite, NodeStatus.Success);
        }

        private CompositeProcessor CreateProcessor(IComposite composite, bool random, bool yieldable)
        {
            try
            {
                return new CompositeProcessor(composite, random, yieldable);
            }
            catch(Exception e)
            {
                Assert.IsTrue(e is ArgumentNullException);
                return null;
            }
        }
    }
}
