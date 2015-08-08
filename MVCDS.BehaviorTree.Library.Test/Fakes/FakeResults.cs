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

        public NodeStatus Result
        {
            get
            {
                return Results.Dequeue();
            }
        }

        internal static T CreateNodes<T>(T composite, params NodeStatus[] returns)
            where T : IComposite
        {
            foreach (NodeStatus @return in returns)
            {
                Mock<INode> node = TestHelper.Mock<INode>(@return);
                composite.Add(node.Object);
            }

            return composite;
        }
    }
}
