using MVCDS.BehaviorTree.Library.Archetypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Test.Sequence_Test
{
    internal class MoveLeaf: Leaf
    {
        public MoveLeaf(IPositionable source, Point2D target)
        {
            Source = source;
            Target = target;

            base.Process(TryMove);
        }

        private IPositionable Source { get; set; }

        private Point2D Target { get; set; }

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
                return false;
            }
        }
        
        public override void Init()
        {
            //throw new NotImplementedException();
        }

        private NodeStatus TryMove()
        {
            if (IsAtTarget)
                return NodeStatus.Success;
            else if (IsTargetBlocked)
                return NodeStatus.Failure;

            Move();

            return NodeStatus.Running;
        }
        
        private void Move()
        {
            int x = Source.Position.X + Move(Source.Position.X, Target.X);
            int y = Source.Position.Y + Move(Source.Position.Y, Target.Y);

            Source.Position = new Point2D(x, y);
        }

        private int Move(int source, int target)
        {
            return target.CompareTo(source);
        }
    }
}
