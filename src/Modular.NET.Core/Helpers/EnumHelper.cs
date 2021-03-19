using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
public static class EnumHelper
{
    #region Static Methods

    public static Dictionary<int, string> GetDictionary<T>() where T : struct
    {
        if (!typeof(T).IsEnum)
        {
            throw new ArgumentException("T is not an Enum type!");
        }

        return Enum.GetValues(typeof(T))
            .Cast<object>()
            .ToDictionary(x => (int) x, x => x.ToString());
    }

    public static Dictionary<int, string> GetDictionary<T>(params T[] ignoreValues) where T : struct
    {
        if (!typeof(T).IsEnum)
        {
            throw new ArgumentException("T is not an Enum type!");
        }

        var ignore = ignoreValues.Cast<object>();

        return Enum.GetValues(typeof(T))
            .Cast<object>()
            .Where(x => !ignore.Contains(x))
            .ToDictionary(x => (int) x, x => x.ToString());
    }

    public static Dictionary<int, string> GetDictionaryInDescription<T>() where T : struct
    {
        if (!typeof(T).IsEnum)
        {
            throw new ArgumentException("T is not an Enum type!");
        }

        return Enum.GetValues(typeof(T))
            .Cast<object>()
            .ToDictionary(x => (int) x, x => ((Enum) x).GetDescription());
    }

    public static Dictionary<int, string> GetDictionaryInDescription<T>(params T[] ignoreValues) where T : struct
    {
        if (!typeof(T).IsEnum)
        {
            throw new ArgumentException("T is not an Enum type!");
        }

        var ignore = ignoreValues.Cast<object>();

        return Enum.GetValues(typeof(T))
            .Cast<object>()
            .Where(x => !ignore.Contains(x))
            .ToDictionary(x => (int) x, x => ((Enum) x).GetDescription());
    }

    public static Dictionary<int, string> GetDictionaryInDisplayText<T>() where T : struct
    {
        if (!typeof(T).IsEnum)
        {
            throw new ArgumentException("T is not an Enum type!");
        }

        return Enum.GetValues(typeof(T))
            .Cast<object>()
            .ToDictionary(x => (int) x, x => ((Enum) x).GetDisplayText());
    }

    public static Dictionary<int, string> GetDictionaryInDisplayText<T>(params T[] ignoreValues) where T : struct
    {
        if (!typeof(T).IsEnum)
        {
            throw new ArgumentException("T is not an Enum type!");
        }

        var ignore = ignoreValues.Cast<object>();

        return Enum.GetValues(typeof(T))
            .Cast<object>()
            .Where(x => !ignore.Contains(x))
            .ToDictionary(x => (int) x, x => ((Enum) x).GetDisplayText());
    }

    #endregion
}
