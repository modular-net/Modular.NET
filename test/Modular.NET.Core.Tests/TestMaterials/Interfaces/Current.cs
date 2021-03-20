using System;
using Modular.NET.Core.Interfaces;
using Modular.NET.Core.Managers;
using Modular.NET.Core.Security;

namespace Modular.NET.Core.Tests.TestMaterials.Interfaces
{
    public class Current : ICurrent
    {
        #region Fields, Properties and Indexers

        public string Name { get; set; } = Guid.NewGuid()
            .ToString();

        public EncryptionKeyPair EncryptionKeyPair { get; set; } = EncryptionManager.Aes.GenerateKeyPair();

        #endregion
    }
}
