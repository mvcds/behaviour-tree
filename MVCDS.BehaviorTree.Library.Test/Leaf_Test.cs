using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCDS.BehaviorTree.Library.Archetypes;
using Moq;
using MVCDS.BehaviorTree.Library.Composites;
using MVCDS.BehaviorTree.Library.Test.Fake;

namespace MVCDS.BehaviorTree.Library.Test
{
    [TestClass]
    public class Leaf_Test
    {
        [TestMethod]
        public void Executes_Its_Process()
        {
            FakeLeaf cud = new FakeLeaf(NodeStatus.Success);
            TestHelper.AssertResult(cud, NodeStatus.Success);
        }

        [TestMethod]
        public void Executes_Its_When()
        {
            FakeLeaf cud = new FakeLeaf(NodeStatus.Success);
            cud.When<FakeLeaf>(NodeStatus.Success, () => 
            {
                cud = new FakeLeaf(NodeStatus.Failure);
            });

            NodeStatus result = (cud as INode).Result;
            Assert.AreEqual(NodeStatus.Success, result);
            TestHelper.AssertResult(cud, NodeStatus.Failure);
        }

        [TestMethod]
        public void Is_Executed_From_Selector()
        {
            FakeLeaf cud = new FakeLeaf(NodeStatus.Success);
            Selector selector = new Selector();

            selector.Add(cud);

            TestHelper.AssertResult(selector, NodeStatus.Success);
        }
    }
}
