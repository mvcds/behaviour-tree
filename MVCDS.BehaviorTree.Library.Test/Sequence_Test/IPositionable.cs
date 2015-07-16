using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCDS.BehaviorTree.Library.Test.Sequence_Test
{
    internal interface IPositionable
    {
        Point2D Position { get; }
    }

    internal class Point2D
    {
        public Point2D(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X
        {
            private set;
            get;
        }

        public int Y
        {
            private set;
            get;
        }
    }
}
