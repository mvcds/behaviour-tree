using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCDS.BehaviorTree.Library.Test.Sequence_Test
{
    internal interface IITemHolder
    {
        List<IItem> Items { get; }
    }

    internal interface IItem
    {
        string Name { get; }
    }
}
