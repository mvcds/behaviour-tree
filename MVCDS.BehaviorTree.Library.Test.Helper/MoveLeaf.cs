using MVCDS.BehaviorTree.Library.Archetypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCDS.BehaviorTree.Library.Test.Helper
{
    public class MoveLeaf: Leaf
    {
        public MoveLeaf(Map map, IPositionable source, int x, int y)
        {
            Location = map;
            Source = source;
            Target = new Point2D(x, y);
        }

        private Map Location { get; set; }

        private IPositionable Source { get; set; }

        private Point2D Target { get; set; }

        public Point2D Last { get; set; }

        private bool IsAtTarget
        {
            get
            {
                return (Source.Position.X == Target.X && Source.Position.Y == Target.Y);
            }
        }

        private bool IsTargetBlocked
        {
            get
            {
                return Location.Find(Target) != null;
            }
        }

        protected override NodeStatus Process()
        {
            if (IsAtTarget)
                return NodeStatus.Success;
            else if (IsTargetBlocked)
                return NodeStatus.Failure;

            try
            {
                Move();
            }
            catch(CouldNotMoveException)
            {
                return NodeStatus.Failure;
            }

            return NodeStatus.Running;
        }

        private void Move()
        {
            int x = Source.Position.X + Move(Source.Position.X, Target.X);
            int y = Source.Position.Y + Move(Source.Position.Y, Target.Y);

            Location.Move(Source, x, y);
        }

        private int Move(int source, int target)
        {
            return target.CompareTo(source);
        }

        public override void Init()
        {
            Last = Source.Position;
        }

    }

    internal class CouldNotMoveException : Exception
    {
        public CouldNotMoveException(IPositionable positionable)
        {
            Positionable = positionable;
        }

        public IPositionable Positionable { get; private set; }
    }
}
