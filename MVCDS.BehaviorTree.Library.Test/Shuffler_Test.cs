using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCDS.BehaviorTree.Library.Archetypes;

namespace MVCDS.BehaviorTree.Library.Test
{
    [TestClass]
    public class Shuffler_Test
    {
        [TestMethod]
        public void With_Null()
        {
            CreateShuffler(null);
        }

        [TestMethod]
        public void With_Mock()
        {
            Mock<IComposite> composite = new Mock<IComposite>(MockBehavior.Strict);
            CreateShuffler(composite.Object);
        }

        private void CreateShuffler(IComposite composite)
        {
            try
            {
                Shuffler shuffler = new Shuffler(composite);
            }
            catch(Exception e)
            {
                Assert.IsTrue(e is ArgumentNullException);
            }
        }
    }
}
