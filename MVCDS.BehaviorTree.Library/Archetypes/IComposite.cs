using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Archetypes
{
    public interface IComposite: INode
    {
        List<INode> Children { get; }
    }
}
