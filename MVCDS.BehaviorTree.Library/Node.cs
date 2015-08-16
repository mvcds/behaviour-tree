using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library
{
    /// <summary>
    /// The status that a node may result
    /// </summary>
    public enum NodeStatus
    {
        Running,
        Success,
        Failure
    }

    public interface INode
    {
        NodeStatus Result { get; }
        //TODO: how to handle errors
    }

    public interface IYieldable
    {
        bool IsYieldable { get; }
        void Reset();
    }
}
