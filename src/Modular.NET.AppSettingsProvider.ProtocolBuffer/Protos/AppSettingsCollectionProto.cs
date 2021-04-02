using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ProtoBuf;

namespace Modular.NET.AppSettingsProvider.ProtocolBuffer.Protos
{
    [ProtoContract]
    public class AppSettingsCollectionProto
    {
        #region Fields, Properties and Indexers

        [ProtoMember(1)]
        public List<AppSettingsProto> Items { get; set; } = new List<AppSettingsProto>();

        [ProtoMember(100)]
        public bool SysAppSettingsInitialization { get; set; }

        #endregion
    }
}
