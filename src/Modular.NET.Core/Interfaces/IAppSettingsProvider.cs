using System;
using System.Threading;
using System.Threading.Tasks;

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

        Task<bool> ClearSettingsAsync(CancellationToken cancellationToken = default);

        Task<bool?> GetBooleanAsync(string key,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default);

        Task<byte?> GetByteAsync(string key,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default);

        Task<byte[]> GetBytesAsync(string key,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default);

        Task<DateTime?> GetDateTimeAsync(string key,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default);

        Task<decimal?> GetDecimalAsync(string key,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default);

        Task<double?> GetDoubleAsync(string key,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default);

        Task<T> GetEnumAsync<T>(string key,
            T defaultValue,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default) where T : Enum;

        Task<float?> GetFloatAsync(string key,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default);

        Task<int?> GetIntAsync(string key,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default);

        Task<long?> GetLongAsync(string key,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default);

        Task<object> GetObjectAsync(string key,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default);

        Task<T> GetObjectAsync<T>(string key,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default);

        Task<short?> GetShortAsync(string key,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default);

        Task<string> GetStringAsync(string key,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default);

        Task<bool> SetBooleanAsync(string key,
            bool value,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default);

        Task<bool> SetByteAsync(string key,
            byte value,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default);

        Task<bool> SetBytesAsync(string key,
            byte[] value,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default);

        Task<bool> SetDateTimeAsync(string key,
            DateTime value,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default);

        Task<bool> SetDecimalAsync(string key,
            decimal value,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default);

        Task<bool> SetDoubleAsync(string key,
            double value,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default);

        Task<bool> SetEnumAsync<T>(string key,
            T value,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default) where T : Enum;

        Task<bool> SetFloatAsync(string key,
            float value,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default);

        Task<bool> SetIntAsync(string key,
            int value,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default);

        Task<bool> SetLongAsync(string key,
            long value,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default);

        Task<bool> SetObjectAsync(string key,
            object value,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default);

        Task<bool> SetShortAsync(string key,
            short value,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default);

        Task<bool> SetStringAsync(string key,
            string value,
            bool isEncrypted = false,
            CancellationToken cancellationToken = default);

        #endregion
    }
}
