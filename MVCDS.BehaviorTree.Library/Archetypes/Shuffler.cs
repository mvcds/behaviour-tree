using MVCDS.BehaviorTree.Library.Archetypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Archetypes
{
    /// <summary>
    /// A helper class for shuffle composite nodes
    /// </summary>
    public sealed class Shuffler
    {
        /// <summary>
        /// Creates the shuffler
        /// </summary>
        /// <param name="source">The composite it should shuffle</param>
        public Shuffler(IComposite source)
        {
            Source = source;
        }

        private IComposite Source { get; set; }

        /// <summary>
        /// Shuffles the order of the nodes without messing up with the original order
        /// </summary>
        /// <returns>The nodes ramdomly organized</returns>
        public List<INode> Shuffle()
        {
            return Source.Nodes
                .OrderBy(p => Guid.NewGuid())
                .ToList();
        }
    }
}
