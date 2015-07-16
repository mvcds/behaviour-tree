using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Archetypes
{
    abstract public class Composite: INode
    {
        private List<INode> _children = new List<INode>();
        public List<INode> Children
        {
            get
            {
                return _children;
            }
        }

        Func<NodeStatus> InstanceProcess = null;

        public NodeStatus Process()
        {
            foreach (INode child in Children)
            {
                Leaf leaf = child as Leaf;
                if (leaf != null)
                    leaf.Init();
            }
            return InstanceProcess();
        }

        internal void Process(Func<NodeStatus> process)
        {
            InstanceProcess = process;
        }
    }
}
