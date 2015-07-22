using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Archetypes
{
    public abstract class Decorator: INode
    {
        public Decorator(INode node)
        {
            Child = node;
        }

        public INode Child { get; private set; }

        NodeStatus INode.Process()
        {
            return Process();
        }

        abstract protected NodeStatus Process();
    }
}
