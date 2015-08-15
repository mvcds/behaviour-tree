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
            FakeProcesses set = new FakeProcesses(NodeStatus.Success, NodeStatus.Running, NodeStatus.Failure);
            RepeatUntilFail cud = new RepeatUntilFail(set);
            TestHelper.AssertProcess<RepeatUntilFail>(cud, NodeStatus.Success);
        }
    }
}
