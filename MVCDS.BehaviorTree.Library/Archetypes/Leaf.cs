using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Archetypes
{
    public abstract class Leaf: INode
    {
        public Leaf()
        {
            actions = new Dictionary<NodeStatus, Action>()
            {
                { NodeStatus.Running, null},
                { NodeStatus.Failure, null},
                { NodeStatus.Success, null},
            };
        }

        private NodeStatus _last = NodeStatus.Running;
        private NodeStatus Result
        {
            get
            {
                return _last;
            }
            set
            {
                if (_last != value)
                {
                    Action action = actions[value];
                    if (action != null)
                        action();
                    _last = value;
                }
            }
        }

        private Dictionary<NodeStatus, Action> actions;


        public NodeStatus Process()
        {
            Result = InstanceProcess();
            return Result;
        }

        public T When<T>(NodeStatus status, Action @do = null)
            where T : Leaf
        {
            actions[status] = @do;
            return this as T;
        }

        abstract protected NodeStatus InstanceProcess();

        virtual public void Init()
        {
        }
    }
}
