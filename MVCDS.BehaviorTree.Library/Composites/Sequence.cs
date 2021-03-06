﻿using MVCDS.BehaviorTree.Library.Archetypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Composites
{
    /// <summary>
    /// All of its children must succeed for this to succedd as well
    /// </summary>
    public sealed class Sequence: Composite
    {
        /// <summary>
        /// Creates a Sequence node
        /// (AND gate)
        /// </summary>
        /// <value>false</value> if the order of its nodes are processed matter
        /// <value>true</value> if
        public Sequence(bool random = false, bool yieldable = false)
            : base(random, yieldable) 
        {
        }

        private bool IsRunning { get; set; }

        public override NodeStatus Result
        {
            get
            {
                if (result != NodeStatus.Running)
                    return result;

                if (IsEmpty)
                    return NodeStatus.Success;

                IsRunning = false;

                return Execute();
            }
        }

        NodeStatus result;
        private NodeStatus Execute()
        {
            try
            {
                INode[] children = Processor.Nodes;
                foreach (INode child in children)
                    Execute(child);
                result = IsRunning ? NodeStatus.Running : NodeStatus.Success;
            }
            catch
            {
                result = NodeStatus.Failure;
            }

            return result;
        }

        private void Execute(INode child)
        {
            NodeStatus result = child.Result;
            if (result == NodeStatus.Failure)
                throw new Exception();
            else if (result == NodeStatus.Running)
                IsRunning = true;
        }
    }
}
