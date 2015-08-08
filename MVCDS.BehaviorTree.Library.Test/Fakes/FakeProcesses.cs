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
            
        public NodeStatus Process()
        {
            return Results.Dequeue();
        }
    }
}
