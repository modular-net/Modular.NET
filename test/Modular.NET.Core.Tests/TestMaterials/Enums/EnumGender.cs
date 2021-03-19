using System.ComponentModel;
using Modular.NET.Core.Attributes;

namespace Modular.NET.Core.Tests.TestMaterials.Enums
{
    public enum EnumGender
    {
        [Description("")]
        NotSpecific,

        Male,

        [DisplayText("female")]
        Female
    }
}
