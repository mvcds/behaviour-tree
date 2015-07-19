using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Test.Helper
{
    public class Hero : IPositionable
    {
        public Hero(Map map, int x, int y)
        {
            Position = new Point2D(x, y);
            map.Insert(this);
            Items = new List<IItem>();
        }

        public Behaviour Behaviour { get; set; }

        public Point2D Position { get; set; }

        public List<IItem> Items { get; set; }
    }
}
