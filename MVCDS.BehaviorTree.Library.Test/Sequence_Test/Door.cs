using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCDS.BehaviorTree.Library.Test.Sequence_Test
{
    internal class Door : IPositionable, ITraversable, IOpenable
    {
        public Door(int x = 0, int y = 0)
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

        #region ITraversable Members

        public bool CanTransverse
        {
            get { throw new NotImplementedException(); }
        }

        #endregion

        #region IOpenable Members

        public bool IsLocked
        {
            get { throw new NotImplementedException(); }
        }

        public bool Open()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
