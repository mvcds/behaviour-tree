using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCDS.BehaviorTree.Library.Test.Helper
{
    public class Map
    {
        public Map(int columns, int rows)
        {
            Items = new IPositionable[columns, rows];
        }

        private IPositionable[,] Items { get; set; }

        internal void Insert(IPositionable item)
        {
            int x = item.Position.X;
            int y = item.Position.Y;

            Insert(item, x, y);
        }

        private Point2D Insert(IPositionable item, int x, int y)
        {
            IPositionable obj = Items[x, y];
            if (obj != null)
            {
                IOpenable openable = obj as IOpenable;
                if (openable == null || openable.IsLocked)
                    throw new CouldNotMoveException(obj);
            }

            Items[x, y] = item;
            return new Point2D(x, y);
        }

        internal void Move(IPositionable source, int x, int y)
        {
            Items[source.Position.X, source.Position.Y] = null;
            source.Position = Insert(source, x, y);
        }

        internal IPositionable Find(Point2D point)
        {
            return Items[point.X, point.Y];
        }

        public void Remove(IPositionable item)
        {
            IPositionable obj = Find(item.Position);
            obj = null;
        }
    }
}
