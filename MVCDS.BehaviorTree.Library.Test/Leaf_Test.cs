using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCDS.BehaviorTree.Library.Archetypes;
using Moq;
using MVCDS.BehaviorTree.Library.Composites;

namespace MVCDS.BehaviorTree.Library.Test
{
    [TestClass]
    public class Leaf_Test
    {
        private class TestableLeaf: Leaf
        {
            public TestableLeaf(NodeStatus result)
            {
                Result = result;
            }

            public NodeStatus Result { get; private set; }

            protected override void Init()
            {
                base.Init();
            }

            protected override NodeStatus Process()
            {
                return Result;
            }
        }

        [TestMethod]
        public void Executes_Its_Process()
        {
            TestableLeaf cud = new TestableLeaf(NodeStatus.Success);
            TestHelper.AssertProcess(cud, NodeStatus.Success);
        }

        [TestMethod]
        public void Executes_Its_When()
        {
            TestableLeaf cud = new TestableLeaf(NodeStatus.Success);
            cud.When<TestableLeaf>(NodeStatus.Success, () => 
            {
                cud = new TestableLeaf(NodeStatus.Failure);
            });

            (cud as INode).Process();
            TestHelper.AssertProcess(cud, NodeStatus.Failure);
        }

        [TestMethod]
        public void Is_Executed_From_Selector()
        {
            TestableLeaf cud = new TestableLeaf(NodeStatus.Success);
            Selector selector = new Selector();

            selector.Add(cud);

            TestHelper.AssertProcess(selector, NodeStatus.Success);
        }
    }
}
