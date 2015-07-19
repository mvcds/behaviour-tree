using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCDS.BehaviorTree.Library.Test.Helper
{
    public class Door : IOpenable
    {
        public Door(Map map, int x, int y)
        {
            Position = new Point2D(x, y);
            map.Insert(this);
            IsLocked = true;
        }

        public Point2D Position { get; set; }

        public bool IsLocked
        {
            get;
            private set;
        }

        public bool Open()
        {
            if (IsLocked)
            {
                IsLocked = false;
                return true;
            }
            return false;
        }

        public void Close()
        {
            IsLocked = true;
        }
    }
}
