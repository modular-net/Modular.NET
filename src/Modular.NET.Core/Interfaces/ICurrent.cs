using Modular.NET.Core.Security;

namespace Modular.NET.Core.Interfaces
{
    public interface ICurrent
    {
        #region Fields, Properties and Indexers

        string Name { get; set; }

        EncryptionKeyPair EncryptionKeyPair { get; set; }

        #endregion
    }
}
