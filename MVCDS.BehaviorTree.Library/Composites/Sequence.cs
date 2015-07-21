﻿using MVCDS.BehaviorTree.Library.Archetypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Composites
{
    public class Sequence: Composite
    {
        protected override NodeStatus Process()
        {
            if (IsEmpty)
                return NodeStatus.Success;

            bool isRunning = false;

            for (var i = 0; i < Children.Count; i++)
            {
                NodeStatus result = Children[i].Process();
                if (result == NodeStatus.Failure)
                    return NodeStatus.Failure;
                else if (result == NodeStatus.Running)
                    isRunning = true;
            }

            return isRunning ? NodeStatus.Running : NodeStatus.Success;
        }
    }
}