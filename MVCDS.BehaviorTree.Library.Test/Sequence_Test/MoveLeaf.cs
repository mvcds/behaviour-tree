using MVCDS.BehaviorTree.Library.Archetypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Test.Sequence_Test
{
    internal class MoveLeaf: ILeaf
    {
        private IPositionable _source;
        private Point2D _target;

        public MoveLeaf(IPositionable source, Point2D target)
        {
            this._source = source;
            this._target = target;
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
