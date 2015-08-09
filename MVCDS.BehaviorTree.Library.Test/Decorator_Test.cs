using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCDS.BehaviorTree.Library.Archetypes;
using Moq;
using MVCDS.BehaviorTree.Library.Decorators;

namespace MVCDS.BehaviorTree.Library.Test
{
    [TestClass]
    public class Decorator_Test
    {
        [TestMethod]
        public void With_Null()
        {
            CreateInverter(null);
        }

        [TestMethod]
        public void With_Mock()
        {
            Mock<INode> node = TestHelper.Mock<INode>();
            CreateInverter(node.Object);
        }

        private void CreateInverter(INode node)
        {
            try
            {
                Inverter inverter = new Inverter(node);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is ArgumentNullException);
            }
        }
    }
}
