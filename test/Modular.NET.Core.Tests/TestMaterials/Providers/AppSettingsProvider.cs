using System;
using System.Collections.Generic;
using Modular.NET.Core.Interfaces;
using Modular.NET.Core.Managers;
using Modular.NET.Core.Security;

namespace Modular.NET.Core.Tests.TestMaterials.Providers
{
    public class AppSettingsProvider : IAppSettingsProvider
    {
        #region Static Fields and Constants

        private static Dictionary<string, object> _Storage = new Dictionary<string, object>();

        #endregion

        #region Fields, Properties and Indexers

        public static EncryptionKeyPair EncryptionKeyPair { get; set; }

        #endregion

        #region Implementations

        public bool ClearSettings()
        {
            _Storage = new Dictionary<string, object>();
            return true;
        }

        public bool? GetBoolean(string key,
            bool isEncrypted = false)
        {
            return Get<bool?>(key, isEncrypted);
        }

        public byte? GetByte(string key,
            bool isEncrypted = false)
        {
            var base64 = Get<string>(key, isEncrypted);
            if (string.IsNullOrEmpty(base64))
            {
                return null;
            }

            return Convert.FromBase64String(base64)[0];
        }

        public byte[] GetBytes(string key,
            bool isEncrypted = false)
        {
            var base64 = Get<string>(key, isEncrypted);
            return !string.IsNullOrEmpty(base64)
                ? Convert.FromBase64String(base64)
                : null;
        }

        public DateTime? GetDateTime(string key,
            bool isEncrypted = false)
        {
            return Get<DateTime?>(key, isEncrypted);
        }

        public decimal? GetDecimal(string key,
            bool isEncrypted = false)
        {
            return Get<decimal?>(key, isEncrypted);
        }

        public double? GetDouble(string key,
            bool isEncrypted = false)
        {
            return Get<double?>(key, isEncrypted);
        }

        public T GetEnum<T>(string key,
            T defaultValue,
            bool isEncrypted = false) where T : Enum
        {
            if (!_Storage.ContainsKey(key))
            {
                return defaultValue;
            }

            if (!isEncrypted)
            {
                return (T) _Storage[key];
            }

            return EncryptionManager.Aes.Decrypt<T>((string) _Storage[key], EncryptionKeyPair);
        }

        public float? GetFloat(string key,
            bool isEncrypted = false)
        {
            return Get<float?>(key, isEncrypted);
        }

        public int? GetInt(string key,
            bool isEncrypted = false)
        {
            return Get<int?>(key, isEncrypted);
        }

        public long? GetLong(string key,
            bool isEncrypted = false)
        {
            return Get<long?>(key, isEncrypted);
        }

        public object GetObject(string key,
            bool isEncrypted = false)
        {
            return Get<object>(key, isEncrypted);
        }

        public T GetObject<T>(string key,
            bool isEncrypted = false)
        {
            return Get<T>(key, isEncrypted);
        }

        public short? GetShort(string key,
            bool isEncrypted = false)
        {
            return Get<short?>(key, isEncrypted);
        }

        public string GetString(string key,
            bool isEncrypted = false)
        {
            return Get<string>(key, isEncrypted);
        }

        public bool SetBoolean(string key,
            bool value,
            bool isEncrypted = false)
        {
            return Set(key, value, isEncrypted);
        }

        public bool SetByte(string key,
            byte value,
            bool isEncrypted = false)
        {
            var base64 = Convert.ToBase64String(new[] { value });
            return Set(key, base64, isEncrypted);
        }

        public bool SetBytes(string key,
            byte[] value,
            bool isEncrypted = false)
        {
            var base64 = Convert.ToBase64String(value);
            return Set(key, base64, isEncrypted);
        }

        public bool SetDateTime(string key,
            DateTime value,
            bool isEncrypted = false)
        {
            return Set(key, value, isEncrypted);
        }

        public bool SetDecimal(string key,
            decimal value,
            bool isEncrypted = false)
        {
            return Set(key, value, isEncrypted);
        }

        public bool SetDouble(string key,
            double value,
            bool isEncrypted = false)
        {
            return Set(key, value, isEncrypted);
        }

        public bool SetEnum<T>(string key,
            T value,
            bool isEncrypted = false) where T : Enum
        {
            return Set(key, value, isEncrypted);
        }

        public bool SetFloat(string key,
            float value,
            bool isEncrypted = false)
        {
            return Set(key, value, isEncrypted);
        }

        public bool SetInt(string key,
            int value,
            bool isEncrypted = false)
        {
            return Set(key, value, isEncrypted);
        }

        public bool SetLong(string key,
            long value,
            bool isEncrypted = false)
        {
            return Set(key, value, isEncrypted);
        }

        public bool SetObject(string key,
            object value,
            bool isEncrypted = false)
        {
            return Set(key, value, isEncrypted);
        }

        public bool SetShort(string key,
            short value,
            bool isEncrypted = false)
        {
            return Set(key, value, isEncrypted);
        }

        public bool SetString(string key,
            string value,
            bool isEncrypted = false)
        {
            return Set(key, value, isEncrypted);
        }

        #endregion

        #region Methods

        private T Get<T>(string key,
            bool isEncrypted = false)
        {
            if (!_Storage.ContainsKey(key))
            {
                return default;
            }

            if (!isEncrypted)
            {
                return (T) _Storage[key];
            }

            return EncryptionManager.Aes.Decrypt<T>((string) _Storage[key], EncryptionKeyPair);
        }

        private bool Set(string key,
            object value,
            bool isEncrypted = false)
        {
            if (!_Storage.ContainsKey(key))
            {
                _Storage.Add(key, isEncrypted
                    ? EncryptionManager.Aes.Encrypt(value.ToString(), EncryptionKeyPair)
                    : value);
            }
            else
            {
                _Storage[key] = isEncrypted
                    ? EncryptionManager.Aes.Encrypt(value.ToString(), EncryptionKeyPair)
                    : value;
            }

            return true;
        }

        #endregion
    }
}
