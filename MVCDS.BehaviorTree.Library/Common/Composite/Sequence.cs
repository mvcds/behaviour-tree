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
        private List<INode> _children = new List<INode>();

        #region IComposite Members

        public List<INode> Children
        {
            get 
            {
                return _children;
            }
        }

        #endregion

        #region INode Members

        public NodeStatus Process()
        {
            foreach (INode child in Children)
            {
                NodeStatus result = child.Process();
                if (result != NodeStatus.Running)
                    return result;
            }
            return NodeStatus.Running;
        }

        #endregion
    }
}
