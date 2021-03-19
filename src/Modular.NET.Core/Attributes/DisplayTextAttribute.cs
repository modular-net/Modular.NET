using System;

namespace Modular.NET.Core.Attributes
{
    public sealed class DisplayTextAttribute : Attribute
    {
        #region Fields, Properties and Indexers

        public string DisplayText { get; set; }

        #endregion

        #region Constructors

        public DisplayTextAttribute(string displayText)
        {
            DisplayText = displayText;
        }

        #endregion
    }
}
