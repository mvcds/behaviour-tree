using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library
{
    public enum NodeStatus
    {
        Running,
        Success,
        Failure
    }

    public interface INode
    {
        NodeStatus Process();
    }

    //TODO: let only behaviour do the processing, so the user may not call process directly as in "sequence.Process()"
    public class Behaviour: INode
    {
        private INode Root;

        public Behaviour(INode root)
        {
            if (root == null)
                throw new ArgumentNullException();

            Root = root;
        }

        public NodeStatus Process()
        {
            NodeStatus result;
            while ((result = Root.Process()) == NodeStatus.Running);
            return result;
        }
    }
}
