using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Test.Sequence_Test
{
    internal interface IOpenable
    {
        bool IsLocked { get; }

        bool Open();
        void Close();
    }
}
