using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Archetypes
{
    /// <summary>
    /// A helper class to work with the composite's children
    /// </summary>
    public sealed class CompositeShuffler
    {
        public CompositeShuffler(IComposite source)
        {
            if (source == null)
                throw new ArgumentNullException();

            Source = source;
        }

        private IComposite Source { get; set; }

        public INode[] Shuffle()
        {
            return Source.Children
                .OrderBy(p => Guid.NewGuid())
                .ToArray();
        }
    }
}
