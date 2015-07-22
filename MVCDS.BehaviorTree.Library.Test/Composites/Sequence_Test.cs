using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCDS.BehaviorTree.Library.Test.Helper;

namespace MVCDS.BehaviorTree.Library.Test.Composites
{
    [TestClass]
    public class Sequence_Test: Composite_Test
    {
        [TestInitialize]
        public override void Setup()
        {
            base.Setup();
        }

        [TestMethod]
        public void No_Key()
        {
            base.AddDoor(SequenceNode);
            Test(NodeStatus.Failure, 2);
        }

        [TestMethod]
        public void With_Door_And_Key()
        {
            base.AddDoor(SequenceNode);

            Character.Items.Add(new Key());
            base.Test(NodeStatus.Success, 4);
        }
    }
}
