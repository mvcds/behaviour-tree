using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCDS.BehaviorTree.Library.Composites;

namespace MVCDS.BehaviorTree.Library.Test
{
    [TestClass]
    public class Sequence_Test_Randomly: Sequence_Test
    {
        protected override Sequence CreateSequence()
        {
            return new Sequence(true);
        }
    }
}
