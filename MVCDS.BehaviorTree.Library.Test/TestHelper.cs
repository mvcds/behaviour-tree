using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.BehaviorTree.Library.Test
{
    internal static class TestHelper
    {
        private static MockRepository factory;
        static MockRepository Factory 
        {
            get
            {
                if (factory == null)
                {
                    factory = new MockRepository(MockBehavior.Strict)
                    {
                        CallBase = true,
                        DefaultValue = DefaultValue.Empty
                    };
                }
                return factory;
            }
        }

        internal static Mock<T> Mock<T>()
            where T : class
        {
            return Factory.Create<T>();
        }

        internal static Mock<T> Mock<T>(NodeStatus returns)
            where T : class, INode
        {
            Mock<T> mock = Factory.Create<T>();
            mock.Setup<NodeStatus>(p => p.Process())
                .Returns(returns);
            return mock;
        }

        internal static Mock<T> Mock<T>(Exception exception)
            where T : class, INode
        {
            Mock<T> mock = Factory.Create<T>();
            mock.Setup<NodeStatus>(p => p.Process())
                .Throws(exception);
            return mock;
        }
    }
}
