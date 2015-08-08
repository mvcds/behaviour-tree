using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCDS.BehaviorTree.Library.Composites;
using MVCDS.BehaviorTree.Library.Test.Fake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Test
{
    [TestClass]
    public class Selector_Test
    {
        [TestMethod]
        public void No_Child()
        {
            Selector cud = CreateNode();
            TestHelper.AssertProcess(cud, NodeStatus.Success);
        }

        [TestMethod]
        public void All_Success()
        {
            Selector cud = CreateNode(NodeStatus.Success, NodeStatus.Success);
            TestHelper.AssertProcess(cud, NodeStatus.Success);
        }

        [TestMethod]
        public void Node_Keeps_Running()
        {
            Selector cud = CreateNode(NodeStatus.Running);
            TestHelper.AssertProcess(cud, NodeStatus.Running);
        }

        [TestMethod]
        public void First_Fail()
        {
            Selector cud = CreateNode(NodeStatus.Failure, NodeStatus.Success);
            TestHelper.AssertProcess(cud, NodeStatus.Success);
        }

        [TestMethod]
        public void Last_Fail()
        {
            Selector cud = CreateNode(NodeStatus.Success, NodeStatus.Failure);
            TestHelper.AssertProcess(cud, NodeStatus.Success);
        }

        [TestMethod]
        public void All_Fail()
        {
            Selector cud = CreateNode(NodeStatus.Failure, NodeStatus.Failure);
            TestHelper.AssertProcess(cud, NodeStatus.Failure);
        }

        private Selector CreateNode(params NodeStatus[] returns)
        {
            return FakeProcesses.CreateNodes<Selector>(CreateSelector(), returns);
        }

        protected virtual Selector CreateSelector()
        {
            return new Selector();
        }
    }
}
