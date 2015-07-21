using MVCDS.BehaviorTree.Library.Archetypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Archetypes
{
    abstract public partial class Composite : INode
    {
        private class NodeShuffler
        {
            public NodeShuffler(Composite source)
            {
                Source = source;
            }

            private Composite Source { get; set; }

            public List<INode> Shuffled 
            {
                get
                {
                    return Source.Nodes
                        .OrderBy(p => Guid.NewGuid())
                        .ToList();
                }
            }
        }
    }
}
