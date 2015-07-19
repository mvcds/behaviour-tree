using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCDS.BehaviorTree.Library.Test.Helper
{
    public interface IPositionable
    {
        Point2D Position { get; set; }
    }

    public class Point2D
    {
        internal Point2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
    }
}
