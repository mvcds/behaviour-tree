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
    public sealed class CompositeProcessor : IYieldable
    {
        /// <summary>
        /// Creates the processor
        /// </summary>
        /// <param name="source">The composite it should process</param>
        /// <param name="random">The order to process the source's children matter when the value is <value>true</value>;
        /// otherwise they are processed randomly</param>
        /// <param name="yieldable">When <value>true</value>, it processes the same source's children's node until it stops running,
        /// then it tryies to process the next;
        /// otherwise it processes all source's children before returning</param>
        public CompositeProcessor(IComposite source, bool random = false, bool yieldable = false)
        {
            if (source == null)
                throw new ArgumentNullException();

            Source = source;

            if (random)
                Shuffler = new CompositeShuffler(Source);

            IsYieldable = yieldable;
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

        /// <summary>
        /// Does the processor passes one node or all of them?
        /// </summary>
        public bool IsYieldable { get; private set; }

        public INode[] Nodes
        {
            get
            {
                return IsYieldable
                    ? NextNode
                    : AllNodes;
            }
        }

        Queue<INode> _nexts;
        private INode[] NextNode
        {
            get
            {
                if (_nexts == null)
                    Reset();

                return new INode[] { _nexts.Dequeue()  };
            }
        }

        private INode[] AllNodes
        {
            get
            {
                return IsRandom
                    ? Shuffler.Shuffle()
                    : Source.Children;
            }
        }

        public void Reset()
        {
            if (IsYieldable)
                _nexts = new Queue<INode>(AllNodes);
        }
    }
}
