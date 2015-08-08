﻿using MVCDS.BehaviorTree.Library.Archetypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Composites
{
    /// <summary>
    /// If one of its children succeed it will succeed too
    /// </summary>
    public sealed class Selector : Composite
    {
        /// <summary>
        /// Creates a Selector node
        /// (OR gate)
        /// </summary>
        /// <value>false</value> if the order of its nodes are processed matter
        /// <value>true</value> if the order of its nodes can be processed randomly
        public Selector(bool random = false)
            : base(random)
        {
        }
        
        private bool IsRunning { get; set; }

        public override NodeStatus Result
        {
            get
            {
                if (IsEmpty)
                    return NodeStatus.Success;

                IsRunning = false;

                return Execute();
            }
        }

        private NodeStatus Execute()
        {
            NodeStatus result;
            foreach (INode child in Children)
            {
                result = child.Result;
                if (result == NodeStatus.Success)
                    return result;
                else if (result == NodeStatus.Running)
                    IsRunning = true;
            }

            result = IsRunning ? NodeStatus.Running : NodeStatus.Failure;
            return result;
        }
    }
}
