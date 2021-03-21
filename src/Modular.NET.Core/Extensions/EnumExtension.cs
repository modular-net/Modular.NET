using System;
using System.ComponentModel;
using System.Linq;
using Modular.NET.Core.Attributes;

// ReSharper disable once CheckNamespace
public static class EnumExtension
{
    #region Static Methods

    public static string GetDescription(this Enum enumValue)
    {
        var attributes = enumValue.GetType()
            .GetMember(enumValue.ToString())
            .First()
            .GetCustomAttributes(typeof(DescriptionAttribute), false);

        return attributes.Length > 0
            ? ((DescriptionAttribute) attributes[0]).Description
            : enumValue.ToString();
    }

    public static string GetDisplayText(this Enum enumValue)
    {
        var attributes = enumValue.GetType()
            .GetMember(enumValue.ToString())
            .First()
            .GetCustomAttributes(typeof(DisplayTextAttribute), false);

        return attributes.Length > 0
            ? ((DisplayTextAttribute) attributes[0]).DisplayText
            : enumValue.ToString();
    }

    #endregion
}
