using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library
{
    public enum NodeStatus
    {
        Running,
        Success,
        Failure
    }

    public interface INode
    {
        NodeStatus Process();
    }
}
