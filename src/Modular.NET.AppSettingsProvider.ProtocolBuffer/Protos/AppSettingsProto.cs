using ProtoBuf;

namespace Modular.NET.AppSettingsProvider.ProtocolBuffer.Protos
{
    [ProtoContract]
    public class AppSettingsProto
    {
        #region Fields, Properties and Indexers

        [ProtoMember(1)]
        public string Key { get; set; }

        [ProtoMember(2)]
        public string Value { get; set; }

        #endregion
    }
}
