using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCDS.BehaviorTree.Library.Test.Sequence_Test
{
    internal class Map
    {
        List<IPositionable> items = new List<IPositionable>();

        public Map(int columns, int rows)
        {

        }

        public void Add(IPositionable item)
        {
            items.Add(item);
        }
    }
}
