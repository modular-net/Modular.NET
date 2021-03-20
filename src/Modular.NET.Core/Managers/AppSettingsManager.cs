using System;
using Modular.NET.Core.Interfaces;

namespace Modular.NET.Core.Managers
{
    public static class AppSettingsManager
    {
        #region Fields, Properties and Indexers

        private static IAppSettingsProvider _Provider { get; set; } = Engine.Resolve<IAppSettingsProvider>();

        #endregion

        #region Static Methods

        public static void ResetProvider()
        {
            _Provider = Engine.Resolve<IAppSettingsProvider>();
        }

        public static bool ClearSettings()
        {
            return _Provider?.ClearSettings() ?? false;
        }

        public static bool? GetBoolean(string key)
        {
            return _Provider?.GetBoolean(key);
        }

        public static bool? GetBoolean(string key,
            bool isEncrypted)
        {
            return _Provider?.GetBoolean(key, isEncrypted);
        }

        public static bool GetBoolean(string key,
            bool defaultValue,
            bool isEncrypted)
        {
            return _Provider?.GetBoolean(key, isEncrypted) ?? defaultValue;
        }

        public static byte? GetByte(string key,
            bool isEncrypted = false)
        {
            return _Provider?.GetByte(key, isEncrypted);
        }

        public static byte GetByte(string key,
            byte defaultValue,
            bool isEncrypted = false)
        {
            return _Provider?.GetByte(key, isEncrypted) ?? defaultValue;
        }

        public static byte[] GetBytes(string key,
            bool isEncrypted = false)
        {
            return _Provider?.GetBytes(key, isEncrypted);
        }

        public static byte[] GetBytes(string key,
            byte[] defaultValue,
            bool isEncrypted = false)
        {
            return _Provider?.GetBytes(key, isEncrypted) ?? defaultValue;
        }

        public static DateTime? GetDateTime(string key,
            bool isEncrypted = false)
        {
            return _Provider?.GetDateTime(key, isEncrypted);
        }

        public static DateTime GetDateTime(string key,
            DateTime defaultValue,
            bool isEncrypted = false)
        {
            return _Provider?.GetDateTime(key, isEncrypted) ?? defaultValue;
        }

        public static decimal? GetDecimal(string key,
            bool isEncrypted = false)
        {
            return _Provider?.GetDecimal(key, isEncrypted);
        }

        public static decimal GetDecimal(string key,
            decimal defaultValue,
            bool isEncrypted = false)
        {
            return _Provider?.GetDecimal(key, isEncrypted) ?? defaultValue;
        }

        public static double? GetDouble(string key,
            bool isEncrypted = false)
        {
            return _Provider?.GetDouble(key, isEncrypted);
        }

        public static double GetDouble(string key,
            double defaultValue,
            bool isEncrypted = false)
        {
            return _Provider?.GetDouble(key, isEncrypted) ?? defaultValue;
        }

        public static T GetEnum<T>(string key,
            T defaultValue,
            bool isEncrypted = false) where T : Enum
        {
            return _Provider != null
                ? _Provider.GetEnum(key, defaultValue, isEncrypted)
                : defaultValue;
        }

        public static float? GetFloat(string key,
            bool isEncrypted = false)
        {
            return _Provider?.GetFloat(key, isEncrypted);
        }

        public static float GetFloat(string key,
            float defaultValue,
            bool isEncrypted = false)
        {
            return _Provider?.GetFloat(key, isEncrypted) ?? defaultValue;
        }

        public static int? GetInt(string key,
            bool isEncrypted = false)
        {
            return _Provider?.GetInt(key, isEncrypted);
        }

        public static int GetInt(string key,
            int defaultValue,
            bool isEncrypted = false)
        {
            return _Provider?.GetInt(key, isEncrypted) ?? defaultValue;
        }

        public static long? GetLong(string key,
            bool isEncrypted = false)
        {
            return _Provider?.GetLong(key, isEncrypted);
        }

        public static long GetLong(string key,
            long defaultValue,
            bool isEncrypted = false)
        {
            return _Provider?.GetLong(key, isEncrypted) ?? defaultValue;
        }

        public static object GetObject(string key,
            bool isEncrypted = false)
        {
            return _Provider?.GetObject(key, isEncrypted);
        }

        public static object GetObject(string key,
            object defaultValue,
            bool isEncrypted = false)
        {
            return _Provider?.GetObject(key, isEncrypted) ?? defaultValue;
        }

        public static T GetObject<T>(string key,
            bool isEncrypted = false)
        {
            try
            {
                return _Provider.GetObject<T>(key, isEncrypted);
            }
            catch (Exception)
            {
                return default;
            }
        }

        public static T GetObject<T>(string key,
            T defaultValue,
            bool isEncrypted = false)
        {
            try
            {
                return _Provider.GetObject<T>(key, isEncrypted);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        public static short? GetShort(string key,
            bool isEncrypted = false)
        {
            return _Provider?.GetShort(key, isEncrypted);
        }

        public static short GetShort(string key,
            short defaultValue,
            bool isEncrypted = false)
        {
            return _Provider?.GetShort(key, isEncrypted) ?? defaultValue;
        }

        public static string GetString(string key,
            bool isEncrypted = false)
        {
            return _Provider?.GetString(key, isEncrypted);
        }

        public static string GetString(string key,
            string defaultValue,
            bool isEncrypted = false)
        {
            return _Provider?.GetString(key, isEncrypted) ?? defaultValue;
        }

        public static bool SetBoolean(string key,
            bool value,
            bool isEncrypted = false)
        {
            return _Provider?.SetBoolean(key, value, isEncrypted) ?? false;
        }

        public static bool SetByte(string key,
            byte value,
            bool isEncrypted = false)
        {
            return _Provider?.SetByte(key, value, isEncrypted) ?? false;
        }

        public static bool SetBytes(string key,
            byte[] value,
            bool isEncrypted = false)
        {
            return _Provider?.SetBytes(key, value, isEncrypted) ?? false;
        }

        public static bool SetDateTime(string key,
            DateTime value,
            bool isEncrypted = false)
        {
            return _Provider?.SetDateTime(key, value, isEncrypted) ?? false;
        }

        public static bool SetDecimal(string key,
            decimal value,
            bool isEncrypted = false)
        {
            return _Provider?.SetDecimal(key, value, isEncrypted) ?? false;
        }

        public static bool SetDouble(string key,
            double value,
            bool isEncrypted = false)
        {
            return _Provider?.SetDouble(key, value, isEncrypted) ?? false;
        }

        public static bool SetEnum<T>(string key,
            T value,
            bool isEncrypted = false) where T : Enum
        {
            return _Provider?.SetEnum(key, value, isEncrypted) ?? false;
        }

        public static bool SetFloat(string key,
            float value,
            bool isEncrypted = false)
        {
            return _Provider?.SetFloat(key, value, isEncrypted) ?? false;
        }

        public static bool SetInt(string key,
            int value,
            bool isEncrypted = false)
        {
            return _Provider?.SetInt(key, value, isEncrypted) ?? false;
        }

        public static bool SetLong(string key,
            long value,
            bool isEncrypted = false)
        {
            return _Provider?.SetLong(key, value, isEncrypted) ?? false;
        }

        public static bool SetObject(string key,
            object value,
            bool isEncrypted = false)
        {
            return _Provider?.SetObject(key, value, isEncrypted) ?? false;
        }

        public static bool SetShort(string key,
            short value,
            bool isEncrypted = false)
        {
            return _Provider?.SetShort(key, value, isEncrypted) ?? false;
        }

        public static bool SetString(string key,
            string value,
            bool isEncrypted = false)
        {
            return _Provider?.SetString(key, value, isEncrypted) ?? false;
        }

        #endregion
    }
}
