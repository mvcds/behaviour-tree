using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCDS.BehaviorTree.Library.Test.Sequence_Test
{
    internal class Hero: IPositionable
    {
        public Hero(int x = 0, int y = 0)
        {
            Position = new Point2D(x, y);
        }

        #region IPositionable Members

        public Point2D Position
        {
            get;
            private set;
        }

        #endregion
    }
}
