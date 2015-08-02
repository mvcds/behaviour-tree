using MVCDS.BehaviorTree.Library.Archetypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Archetypes
{
    public class NodeShuffler
    {
        public NodeShuffler(IComposite source)
        {
            Source = source;
        }

        private IComposite Source { get; set; }

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
