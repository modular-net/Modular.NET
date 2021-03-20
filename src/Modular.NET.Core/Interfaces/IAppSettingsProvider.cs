using System;

namespace Modular.NET.Core.Interfaces
{
    public interface IAppSettingsProvider
    {
        #region Methods

        bool ClearSettings();

        bool? GetBoolean(string key,
            bool isEncrypted = false);

        byte? GetByte(string key,
            bool isEncrypted = false);

        byte[] GetBytes(string key,
            bool isEncrypted = false);

        DateTime? GetDateTime(string key,
            bool isEncrypted = false);

        decimal? GetDecimal(string key,
            bool isEncrypted = false);

        double? GetDouble(string key,
            bool isEncrypted = false);

        T GetEnum<T>(string key,
            T defaultValue,
            bool isEncrypted = false) where T : Enum;

        float? GetFloat(string key,
            bool isEncrypted = false);

        int? GetInt(string key,
            bool isEncrypted = false);

        long? GetLong(string key,
            bool isEncrypted = false);

        object GetObject(string key,
            bool isEncrypted = false);

        T GetObject<T>(string key,
            bool isEncrypted = false);

        short? GetShort(string key,
            bool isEncrypted = false);

        string GetString(string key,
            bool isEncrypted = false);

        bool SetBoolean(string key,
            bool value,
            bool isEncrypted = false);

        bool SetByte(string key,
            byte value,
            bool isEncrypted = false);

        bool SetBytes(string key,
            byte[] value,
            bool isEncrypted = false);

        bool SetDateTime(string key,
            DateTime value,
            bool isEncrypted = false);

        bool SetDecimal(string key,
            decimal value,
            bool isEncrypted = false);

        bool SetDouble(string key,
            double value,
            bool isEncrypted = false);

        bool SetEnum<T>(string key,
            T value,
            bool isEncrypted = false) where T : Enum;

        bool SetFloat(string key,
            float value,
            bool isEncrypted = false);

        bool SetInt(string key,
            int value,
            bool isEncrypted = false);

        bool SetLong(string key,
            long value,
            bool isEncrypted = false);

        bool SetObject(string key,
            object value,
            bool isEncrypted = false);

        bool SetShort(string key,
            short value,
            bool isEncrypted = false);

        bool SetString(string key,
            string value,
            bool isEncrypted = false);

        #endregion
    }
}
