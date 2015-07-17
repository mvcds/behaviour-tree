using MVCDS.BehaviorTree.Library.Archetypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCDS.BehaviorTree.Library.Test.Sequence_Test
{
    internal class OpenLeaf: Leaf
    {
        public OpenLeaf(Hero hero, IOpenable target)
        {
            Character = hero;
            Target = target;

            base.Process(TryOpen);
        }

        private Hero Character { get; set; }

        private IOpenable Target { get; set; }

        private bool IsNear 
        {
            get
            {
                bool x = Math.Abs(Character.Position.X - Target.Position.X) <= 1;
                bool y = Math.Abs(Character.Position.Y - Target.Position.Y) <= 1;

                return x && y;
            }
        }

        public bool CanTheHeroOpenIt 
        {
            get
            {
                IItem key = Character.Items.FirstOrDefault(p => p is Key);
                if (key != null)
                {
                    if (Target.Open())
                    {
                        Character.Items.Remove(key);
                        return true;
                    }
                }
                return false;
            }
        }

        private NodeStatus TryOpen()
        {
            if (Target.IsLocked && IsNear)
            {
                if (CanTheHeroOpenIt)
                    return NodeStatus.Success;
                return NodeStatus.Failure;
            }
            else
                return NodeStatus.Running;
        }

        public override void Init()
        {
        }
    }
}
