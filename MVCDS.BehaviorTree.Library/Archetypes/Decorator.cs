using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Archetypes
{
    public abstract class Decorator: INode
    {
        public INode Child { get; private set; }

        abstract public NodeStatus Process();
    }
}
