using System.ComponentModel;
using Modular.NET.Core.Attributes;

namespace Modular.NET.AppSettingsProvider.ProtocolBuffer.Tests.TestMaterials.Enums
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
