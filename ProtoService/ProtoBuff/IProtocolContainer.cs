using Protocol;
using System;

namespace ProtoService.ProtoBuff
{
    public interface IProtocolContainer
    {
        bool TryGetValue(ProtoID protoID, out Action<byte[]> ack);
    }
}
