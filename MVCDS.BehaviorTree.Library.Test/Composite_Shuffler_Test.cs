using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCDS.BehaviorTree.Library.Archetypes;
using Moq;

namespace MVCDS.BehaviorTree.Library.Test
{
    [TestClass]
    public class Composite_Shuffler_Test
    {
        [TestMethod]
        public void With_Null_Shuffler()
        {
            CreateShuffler(null);
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
    }
}
