using MVCDS.BehaviorTree.Library.Archetypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Archetypes
{
    /// <summary>
    /// A helper class to work with composite's children
    /// </summary>
    public sealed class CompositeProcessor
    {
        /// <summary>
        /// Creates the processor
        /// </summary>
        /// <param name="source">The composite it should process</param>
        public CompositeProcessor(IComposite source, bool random = false)
        {
            if (source == null)
                throw new ArgumentNullException();

            Source = source;
            IsRandom = random;
        }

        private IComposite Source { get; set; }

        /// <summary>
        /// Was this node created for random process or not?
        /// </summary>
        public bool IsRandom
        {
            get;
            private set;
        }

        //TODO: how to keep track of shuffled node?
        //ie: know that they only change on the right time?
        public INode[] SortNodes(List<INode> nodes)
        {
            return IsRandom
                ? Shuffle(nodes)
                : nodes.ToArray();
        }

        private INode[] Shuffle(List<INode> nodes)
        {
            return nodes.OrderBy(p => Guid.NewGuid())
                .ToArray();
        }
    }
}
