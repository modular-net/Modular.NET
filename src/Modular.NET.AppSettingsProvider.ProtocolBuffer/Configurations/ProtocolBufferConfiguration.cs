using System;
using Modular.NET.Core.Security;

namespace Modular.NET.AppSettingsProvider.ProtocolBuffer.Configurations
{
    public static class ProtocolBufferConfiguration
    {
        #region Fields, Properties and Indexers

        public static string Location { get; set; } = ".\\settings.bin";

        public static EncryptionKeyPair EncryptionKeyPair { get; set; }

        public static TimeSpan CacheDuration { get; set; } = TimeSpan.FromHours(1);

        #endregion
    }
}
