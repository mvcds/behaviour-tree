using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCDS.BehaviorTree.Library.Composites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Test
{
    [TestClass]
    public class Selector_Test_As_Random: Selector_Test
    {
        protected override Selector CreateSelector()
        {
            return new Selector(true);
        }
    }
}
