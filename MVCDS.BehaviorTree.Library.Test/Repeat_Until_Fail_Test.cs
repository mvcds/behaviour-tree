using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCDS.BehaviorTree.Library.Decorators;
using Moq;
using System.Collections.Generic;
using MVCDS.BehaviorTree.Library.Test.Fake;

namespace MVCDS.BehaviorTree.Library.Test
{
    [TestClass]
    public class Repeat_Until_Fail_Test
    {
        [TestMethod]
        public void Node_Succeeds()
        {
            RepeatUntilFail cud = Create_Repeater(false);
            TestHelper.AssertResult<RepeatUntilFail>(cud, NodeStatus.Success);
            TestHelper.AssertResult<RepeatUntilFail>(cud, NodeStatus.Success);
        }

        [TestMethod]
        public void Reset_The_Yieldable()
        {
            RepeatUntilFail cud = Create_Repeater(true);
            TestHelper.AssertResult<RepeatUntilFail>(cud, NodeStatus.Running);
            TestHelper.AssertResult<RepeatUntilFail>(cud, NodeStatus.Running);
            TestHelper.AssertResult<RepeatUntilFail>(cud, NodeStatus.Success);
            TestHelper.AssertResult<RepeatUntilFail>(cud, NodeStatus.Success);
            cud.Reset();
        }

        private RepeatUntilFail Create_Repeater(bool yieldable)
        {
            FakeProcesses set = new FakeProcesses(NodeStatus.Success, NodeStatus.Running, NodeStatus.Failure);
            RepeatUntilFail cud = new RepeatUntilFail(set, yieldable);
            return cud;
        }
    }
}
