using System.Collections.Generic;
using DryIoc;

namespace Modular.NET.Core.Interfaces
{
    public interface IModule
    {
        #region Fields, Properties and Indexers

        string Id { get; }

        string Name { get; }

        string Description { get; }

        string Version { get; }

        IEnumerable<string> Dependencies { get; }

        #endregion

        #region Methods

        void ConfigureServices(IRegistrator registrator);

        #endregion
    }
}
