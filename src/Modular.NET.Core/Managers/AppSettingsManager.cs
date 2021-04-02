using System;
using System.Threading;
using System.Threading.Tasks;
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

        public static async Task<bool> ClearSettingsAsync(CancellationToken cancellationToken = default)
        {
            return _Provider != null && await _Provider.ClearSettingsAsync(cancellationToken);
        }

        public static async Task<bool?> GetBooleanAsync(string key,
            CancellationToken cancellationToken = default)
        {
            return _Provider != null
                ? await _Provider.GetBooleanAsync(key, cancellationToken: cancellationToken)
                : null;
        }

        public static async Task<bool?> GetBooleanAsync(string key,
            bool isEncrypted,
            CancellationToken cancellationToken = default)
        {
            return _Provider != null
                ? await _Provider.GetBooleanAsync(key, isEncrypted, cancellationToken)
                : null;
        }

        public static async Task<bool> GetBooleanAsync(string key,
            bool defaultValue,
            bool isEncrypted,
            CancellationToken cancellationToken = default)
        {
            return _Provider != null
                ? await _Provider.GetBooleanAsync(key, isEncrypted, cancellationToken) ?? defaultValue
                : defaultValue;
        }

        public static async Task<byte?> GetByteAsync(string key,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default)
        {
            return _Provider != null
                ? await _Provider.GetByteAsync(key, isEncrypted, cancellationToken)
                : null;
        }

        public static async Task<byte> GetByteAsync(string key,
            byte defaultValue,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default)
        {
            return _Provider != null
                ? await _Provider.GetByteAsync(key, isEncrypted, cancellationToken) ?? defaultValue
                : defaultValue;
        }

        public static async Task<byte[]> GetBytesAsync(string key,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default)
        {
            return _Provider != null
                ? await _Provider.GetBytesAsync(key, isEncrypted, cancellationToken)
                : null;
        }

        public static async Task<byte[]> GetBytesAsync(string key,
            byte[] defaultValue,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default)
        {
            return _Provider != null
                ? await _Provider.GetBytesAsync(key, isEncrypted, cancellationToken) ?? defaultValue
                : defaultValue;
        }

        public static async Task<DateTime?> GetDateTimeAsync(string key,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default)
        {
            return _Provider != null
                ? await _Provider.GetDateTimeAsync(key, isEncrypted, cancellationToken)
                : null;
        }

        public static async Task<DateTime> GetDateTimeAsync(string key,
            DateTime defaultValue,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default)
        {
            return _Provider != null
                ? await _Provider.GetDateTimeAsync(key, isEncrypted, cancellationToken) ?? defaultValue
                : defaultValue;
        }

        public static async Task<decimal?> GetDecimalAsync(string key,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default)
        {
            return _Provider != null
                ? await _Provider.GetDecimalAsync(key, isEncrypted, cancellationToken)
                : null;
        }

        public static async Task<decimal> GetDecimalAsync(string key,
            decimal defaultValue,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default)
        {
            return _Provider != null
                ? await _Provider.GetDecimalAsync(key, isEncrypted, cancellationToken) ?? defaultValue
                : defaultValue;
        }

        public static async Task<double?> GetDoubleAsync(string key,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default)
        {
            return _Provider != null
                ? await _Provider.GetDoubleAsync(key, isEncrypted, cancellationToken)
                : null;
        }

        public static async Task<double> GetDoubleAsync(string key,
            double defaultValue,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default)
        {
            return _Provider != null
                ? await _Provider.GetDoubleAsync(key, isEncrypted, cancellationToken) ?? defaultValue
                : defaultValue;
        }

        public static async Task<T> GetEnumAsync<T>(string key,
            T defaultValue,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default) where T : Enum
        {
            return _Provider != null
                ? await _Provider.GetEnumAsync(key, defaultValue, isEncrypted, cancellationToken)
                : defaultValue;
        }

        public static async Task<float?> GetFloatAsync(string key,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default)
        {
            return _Provider != null
                ? await _Provider.GetFloatAsync(key, isEncrypted, cancellationToken)
                : null;
        }

        public static async Task<float> GetFloatAsync(string key,
            float defaultValue,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default)
        {
            return _Provider != null
                ? await _Provider.GetFloatAsync(key, isEncrypted, cancellationToken) ?? defaultValue
                : defaultValue;
        }

        public static async Task<int?> GetIntAsync(string key,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default)
        {
            return _Provider != null
                ? await _Provider.GetIntAsync(key, isEncrypted, cancellationToken)
                : null;
        }

        public static async Task<int> GetIntAsync(string key,
            int defaultValue,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default)
        {
            return _Provider != null
                ? await _Provider.GetIntAsync(key, isEncrypted, cancellationToken) ?? defaultValue
                : defaultValue;
        }

        public static async Task<long?> GetLongAsync(string key,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default)
        {
            return _Provider != null
                ? await _Provider.GetLongAsync(key, isEncrypted, cancellationToken)
                : null;
        }

        public static async Task<long> GetLongAsync(string key,
            long defaultValue,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default)
        {
            return _Provider != null
                ? await _Provider.GetLongAsync(key, isEncrypted, cancellationToken) ?? defaultValue
                : defaultValue;
        }

        public static async Task<object> GetObjectAsync(string key,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default)
        {
            return _Provider != null
                ? await _Provider.GetObjectAsync(key, isEncrypted, cancellationToken)
                : null;
        }

        public static async Task<object> GetObjectAsync(string key,
            object defaultValue,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default)
        {
            return _Provider != null
                ? await _Provider.GetObjectAsync(key, isEncrypted, cancellationToken) ?? defaultValue
                : defaultValue;
        }

        public static async Task<T> GetObjectAsync<T>(string key,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default)
        {
            try
            {
                return await _Provider.GetObjectAsync<T>(key, isEncrypted, cancellationToken);
            }
            catch (Exception)
            {
                return default;
            }
        }

        public static async Task<T> GetObjectAsync<T>(string key,
            T defaultValue,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default)
        {
            try
            {
                return await _Provider.GetObjectAsync<T>(key, isEncrypted, cancellationToken);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        public static async Task<short?> GetShortAsync(string key,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default)
        {
            return _Provider != null
                ? await _Provider.GetShortAsync(key, isEncrypted, cancellationToken)
                : null;
        }

        public static async Task<short> GetShortAsync(string key,
            short defaultValue,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default)
        {
            return _Provider != null
                ? await _Provider.GetShortAsync(key, isEncrypted, cancellationToken) ?? defaultValue
                : defaultValue;
        }

        public static async Task<string> GetStringAsync(string key,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default)
        {
            return _Provider != null
                ? await _Provider.GetStringAsync(key, isEncrypted, cancellationToken)
                : null;
        }

        public static async Task<string> GetStringAsync(string key,
            string defaultValue,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default)
        {
            return _Provider != null
                ? await _Provider.GetStringAsync(key, isEncrypted, cancellationToken) ?? defaultValue
                : defaultValue;
        }

        public static async Task<bool> SetBooleanAsync(string key,
            bool value,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default)
        {
            return _Provider != null && await _Provider.SetBooleanAsync(key, value, isEncrypted, cancellationToken);
        }

        public static async Task<bool> SetByteAsync(string key,
            byte value,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default)
        {
            return _Provider != null && await _Provider.SetByteAsync(key, value, isEncrypted, cancellationToken);
        }

        public static async Task<bool> SetBytesAsync(string key,
            byte[] value,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default)
        {
            return _Provider != null && await _Provider.SetBytesAsync(key, value, isEncrypted, cancellationToken);
        }

        public static async Task<bool> SetDateTimeAsync(string key,
            DateTime value,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default)
        {
            return _Provider != null && await _Provider.SetDateTimeAsync(key, value, isEncrypted, cancellationToken);
        }

        public static async Task<bool> SetDecimalAsync(string key,
            decimal value,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default)
        {
            return _Provider != null && await _Provider.SetDecimalAsync(key, value, isEncrypted, cancellationToken);
        }

        public static async Task<bool> SetDoubleAsync(string key,
            double value,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default)
        {
            return _Provider != null && await _Provider.SetDoubleAsync(key, value, isEncrypted, cancellationToken);
        }

        public static async Task<bool> SetEnumAsync<T>(string key,
            T value,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default) where T : Enum
        {
            return _Provider != null && await _Provider.SetEnumAsync(key, value, isEncrypted, cancellationToken);
        }

        public static async Task<bool> SetFloatAsync(string key,
            float value,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default)
        {
            return _Provider != null && await _Provider.SetFloatAsync(key, value, isEncrypted, cancellationToken);
        }

        public static async Task<bool> SetIntAsync(string key,
            int value,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default)
        {
            return _Provider != null && await _Provider.SetIntAsync(key, value, isEncrypted, cancellationToken);
        }

        public static async Task<bool> SetLongAsync(string key,
            long value,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default)
        {
            return _Provider != null && await _Provider.SetLongAsync(key, value, isEncrypted, cancellationToken);
        }

        public static async Task<bool> SetObjectAsync(string key,
            object value,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default)
        {
            return _Provider != null && await _Provider.SetObjectAsync(key, value, isEncrypted, cancellationToken);
        }

        public static async Task<bool> SetShortAsync(string key,
            short value,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default)
        {
            return _Provider != null && await _Provider.SetShortAsync(key, value, isEncrypted, cancellationToken);
        }

        public static async Task<bool> SetStringAsync(string key,
            string value,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default)
        {
            return _Provider != null && await _Provider.SetStringAsync(key, value, isEncrypted, cancellationToken);
        }

        #endregion
    }
}
