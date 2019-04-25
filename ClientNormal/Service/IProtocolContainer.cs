using Protocol;
using System;

namespace ClientNormal.Service
{
    public interface IProtocolContainer
    {
        bool TryGetValue(ProtoID protoID, out Action<byte[]> ack);
    }
}
