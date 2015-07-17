using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCDS.BehaviorTree.Library.Test.Sequence_Test
{
    internal class Door : IPositionable, ITraversable, IOpenable
    {
        public Door(int x = 0, int y = 0, bool locked = false)
        {
            Position = new Point2D(x, y);
            IsLocked = locked;
        }
        
        #region IPositionable Members

        public Point2D Position
        {
            get;
            set;
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
            throw new NotImplementedException();
        }

        #endregion
    }
}
