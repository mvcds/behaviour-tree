using MVCDS.BehaviorTree.Library.Archetypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Decorators
{
    /// <summary>
    /// Repeats the proccess on its child until a condition is met
    /// </summary>
    public sealed class Repeater : Decorator, IYieldable
    {
        /// <summary>
        /// Creates the Repeates
        /// </summary>
        /// <param name="node">The node it may execute until a condition is met</param>
        /// <param name="shouldExecute">
        /// The function that makes the node be repeated/stopped
        /// </param>
        public Repeater(INode node, Func<bool> shouldExecute, bool yieldable = false)
            : base(node)
        {
            ShouldExecute = shouldExecute;
            IsYieldable = yieldable;
        }

        private Func<bool> ShouldExecute { get; set; }

        NodeStatus result;
        public override NodeStatus Result
        {
            get 
            {
                while (ShouldExecute())
                {
                    try
                    {
                        result = Child.Result;
                        if (IsYieldable)
                            break;
                    }
                    catch
                    {
                        return NodeStatus.Failure;
                    }
                }
                return result;
            }
        }

        public bool IsYieldable
        {
            get;
            private set;
        }

        public void Reset()
        {
            result = NodeStatus.Running;
        }
    }
}
