using System;
using MVCDS.BehaviorTree.Library.Archetypes;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCDS.BehaviorTree.Library.Test.Helper
{
    public class OpenLeaf: Leaf
    {
        public OpenLeaf(Map map, Hero hero, IOpenable target)
        {
            Location = map;
            Character = hero;
            Target = target;
        }

        private Map Location { get; set; }

        private Hero Character { get; set; }

        private IOpenable Target { get; set; }
        
        private bool TargetCanBeUnlocked
        {
            get
            {
                return Target.IsLocked && IsNear;
            }
        }
        private bool IsNear
        {
            get
            {
                bool x = Math.Abs(Character.Position.X - Target.Position.X) <= 1;
                bool y = Math.Abs(Character.Position.Y - Target.Position.Y) <= 1;

                return x && y;
            }
        }

        private bool CanTheHeroOpenIt
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

        protected override NodeStatus InstanceProcess()
        {
            if (TargetCanBeUnlocked)
            {
                if (CanTheHeroOpenIt)
                    return NodeStatus.Success;
                return NodeStatus.Failure;
            }
            return NodeStatus.Success;
        }
    }
}
