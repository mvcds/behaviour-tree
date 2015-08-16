using Moq;
using MVCDS.BehaviorTree.Library.Archetypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Test.Fake
{
    internal class FakeProcesses: INode
    {
        public FakeProcesses(params NodeStatus[] statuses)
        {
            Results = new Queue<NodeStatus>();
            foreach (NodeStatus status in statuses)
                Results.Enqueue(status);
        }

        Queue<NodeStatus> Results { get; set; }
        NodeStatus Last { get; set; }

        public NodeStatus Result
        {
            get
            {
                if (Results.Any())
                    Last = Results.Dequeue();
                return Last;
            }
        }

        internal static T CreateNodes<T>(T composite, params NodeStatus[] returns)
            where T : IComposite
        {
            List<INode> nodes = new List<INode>();
            foreach (NodeStatus @return in returns)
            {
                Mock<INode> node = TestHelper.Mock<INode>(@return);
                nodes.Add(node.Object);
            }
            composite.Add(nodes);

            return composite;
        }
    }
}
