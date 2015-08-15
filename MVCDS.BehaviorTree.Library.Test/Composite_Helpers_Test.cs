using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCDS.BehaviorTree.Library.Archetypes;

namespace MVCDS.BehaviorTree.Library.Test
{
    [TestClass]
    public class Composite_Helpers_Test
    {
        [TestMethod]
        public void With_Null_Processor()
        {
            CreateProcessor(null);
        }

        [TestMethod]
        public void With_Null_Shuffler()
        {
            CreateShuffler(null);
        }

        [TestMethod]
        public void With_Processor()
        {
            Mock<IComposite> composite = new Mock<IComposite>(MockBehavior.Strict);
            CreateProcessor(composite.Object);
        }

        [TestMethod]
        public void With_Shuffler()
        {
            Mock<IComposite> composite = new Mock<IComposite>(MockBehavior.Strict);
            CreateShuffler(composite.Object);
        }

        private void CreateShuffler(IComposite composite)
        {
            try
            {
                CompositeShuffler shuffler = new CompositeShuffler(composite);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is ArgumentNullException);
            }
        }

        private void CreateProcessor(IComposite composite)
        {
            try
            {
                CompositeProcessor shuffler = new CompositeProcessor(composite);
            }
            catch(Exception e)
            {
                Assert.IsTrue(e is ArgumentNullException);
            }
        }
    }
}
