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

            if (random)
                Shuffler = new CompositeShuffler(Source);
        }

        private IComposite Source { get; set; }

        private CompositeShuffler Shuffler { get; set; }

        /// <summary>
        /// Was this node created for random process or not?
        /// </summary>
        public bool IsRandom
        {
            get
            {
                return Shuffler != null;
            }
        }

        public INode[] Nodes
        {
            get
            {
                return IsRandom
                    ? Shuffler.Shuffle()
                    : Source.Children;
            }
        }
    }
}
