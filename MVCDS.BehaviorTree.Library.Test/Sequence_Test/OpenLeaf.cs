using MVCDS.BehaviorTree.Library.Archetypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCDS.BehaviorTree.Library.Test.Sequence_Test
{
    internal class OpenLeaf: ILeaf
    {
        public OpenLeaf(Hero hero, IOpenable target)
        {
        }

        #region ILeaf Members

        public void Init()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region INode Members

        public NodeStatus Process()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
