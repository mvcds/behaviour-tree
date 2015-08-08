using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCDS.BehaviorTree.Library.Composites;
using Moq;
using MVCDS.BehaviorTree.Library.Test.Fake;

namespace MVCDS.BehaviorTree.Library.Test
{
    [TestClass]
    public class Sequence_Test
    {
        [TestMethod]
        public void No_Child()
        {
            Sequence cud = CreateNode();
            TestHelper.AssertProcess(cud, NodeStatus.Success);
        }

        [TestMethod]
        public void All_Success()
        {
            Sequence cud = CreateNode(NodeStatus.Success, NodeStatus.Success);
            TestHelper.AssertProcess(cud, NodeStatus.Success);
        }

        [TestMethod]
        public void Node_Keeps_Running()
        {
            Sequence cud = CreateNode(NodeStatus.Running);
            TestHelper.AssertProcess(cud, NodeStatus.Running);
        }

        [TestMethod]
        public void First_Fail()
        {
            Sequence cud = CreateNode(NodeStatus.Failure, NodeStatus.Success);
            TestHelper.AssertProcess(cud, NodeStatus.Failure);
        }

        [TestMethod]
        public void Last_Fail()
        {
            Sequence cud = CreateNode(NodeStatus.Success, NodeStatus.Failure);
            TestHelper.AssertProcess(cud, NodeStatus.Failure);
        }

        [TestMethod]
        public void All_Fail()
        {
            Sequence cud = CreateNode(NodeStatus.Failure, NodeStatus.Failure);
            TestHelper.AssertProcess(cud, NodeStatus.Failure);
        }

        private Sequence CreateNode(params NodeStatus[] returns)
        {
            return FakeProcesses.CreateNodes<Sequence>(CreateSequence(), returns);
        }

        protected virtual Sequence CreateSequence()
        {
            return new Sequence();
        }
    }
}
