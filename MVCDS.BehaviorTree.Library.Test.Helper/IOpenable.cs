using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCDS.BehaviorTree.Library.Test.Helper
{
    public interface IOpenable: IPositionable
    {
        bool IsLocked { get; }

        bool Open();
        void Close();
    }
}
