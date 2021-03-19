using System;
using System.ComponentModel;
using Modular.NET.Core.Attributes;

// ReSharper disable once CheckNamespace
public static class EnumExtension
{
    #region Static Methods

    public static string GetDescription(this Enum enumValue)
    {
        var type = enumValue.GetType();
        var memberInfo = type.GetMember(enumValue.ToString());
        if (memberInfo.Length <= 0)
        {
            return enumValue.ToString();
        }

        var attributes = memberInfo[0]
            .GetCustomAttributes(typeof(DescriptionAttribute), false);

        if (attributes.Length > 0)
        {
            return ((DescriptionAttribute) attributes[0]).Description;
        }

        return enumValue.ToString();
    }

    public static string GetDisplayText(this Enum enumValue)
    {
        var type = enumValue.GetType();
        var memberInfo = type.GetMember(enumValue.ToString());
        if (memberInfo.Length <= 0)
        {
            return enumValue.ToString();
        }

        var attributes = memberInfo[0]
            .GetCustomAttributes(typeof(DisplayTextAttribute), false);

        return attributes.Length > 0
            ? ((DisplayTextAttribute) attributes[0]).DisplayText
            : enumValue.ToString();
    }

    #endregion
}
