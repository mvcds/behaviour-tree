using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCDS.BehaviorTree.Library.Composites;
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
            Selector selector = CreateSelector();
            foreach (NodeStatus @return in returns)
            {
                Mock<INode> node = TestHelper.Mock<INode>(@return);
                selector.Add(node.Object);
            }

            return selector;
        }

        protected virtual Selector CreateSelector()
        {
            return new Selector();
        }
    }
}
