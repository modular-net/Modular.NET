using System;

namespace Modular.NET.Tests.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TestPriorityAttribute : Attribute
    {
        #region Fields, Properties and Indexers

        public int Priority { get; }

        #endregion

        #region Constructors

        public TestPriorityAttribute(int priority)
        {
            Priority = priority;
        }

        #endregion
    }
}
