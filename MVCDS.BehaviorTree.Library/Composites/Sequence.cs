using MVCDS.BehaviorTree.Library.Archetypes;
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
        public Sequence(bool random = false)
            : base(random) 
        {
        }

        private bool IsRunning { get; set; }

        /// <summary>
        /// If one of its children fail, the node fail too
        /// </summary>
        /// <returns>The last status of the node</returns>
        protected override NodeStatus Process()
        {
            if (IsEmpty)
                return NodeStatus.Success;

            IsRunning = false;

            return Execute();
        }

        private NodeStatus Execute()
        {
            try
            {
                Children.ForEach(Execute);
            }
            catch
            {
                return NodeStatus.Failure;
            }

            return IsRunning ? NodeStatus.Running : NodeStatus.Success;
        }

        private void Execute(INode child)
        {
            NodeStatus result = child.Process();
            if (result == NodeStatus.Failure)
                throw new Exception();
            else if (result == NodeStatus.Running)
                IsRunning = true;
        }
    }
}
