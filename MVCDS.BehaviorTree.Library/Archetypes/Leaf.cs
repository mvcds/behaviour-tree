using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Archetypes
{
    public abstract class Leaf: INode
    {
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
                    _last = value;
                    switch (value)
                    {
                        case NodeStatus.Running:
                            TryChangeResult(OnRun);
                            break;
                        case NodeStatus.Failure:
                            TryChangeResult(OnFail);
                            break;
                        case NodeStatus.Success:
                            TryChangeResult(OnSucced);
                            break;
                    }
                }
            }
        }

        public Action OnRun = null,
            OnFail = null,
            OnSucced = null;

        abstract public void Init();

        Func<NodeStatus> InstanceProcess = null;
        public NodeStatus Process()
        {
            Result = InstanceProcess();
            return Result;
        }

        private void TryChangeResult(Action result)
        {
            if (result != null)
                result();
        }

        protected void Process(Func<NodeStatus> process)
        {
            InstanceProcess = process;
        }
    }
}
