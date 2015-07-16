using MVCDS.BehaviorTree.Library.Archetypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Common.Composite
{
    sealed public class Sequence: IComposite
    {
        #region IComposite Members

        public List<INode> Children
        {
            get { throw new NotImplementedException(); }
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
