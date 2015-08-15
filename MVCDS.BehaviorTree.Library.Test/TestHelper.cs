using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            Mock<T> mock = TestHelper.Mock<T>();
            mock.Setup<NodeStatus>(p => p.Result)
                .Returns(returns);
            return mock;
        }

        internal static Mock<T> Mock<T>(Exception exception)
            where T : class, INode
        {
            Mock<T> mock = TestHelper.Mock<T>();
            mock.Setup<NodeStatus>(p => p.Result)
                .Throws(exception);
            return mock;
        }

        //TODO: change name to assert result
        internal static void AssertProcess<T>(T cud, NodeStatus expected)
            where T : INode
        {
            NodeStatus result = (cud as INode).Result;
            Assert.AreEqual(expected, result);
        }
    }
}
