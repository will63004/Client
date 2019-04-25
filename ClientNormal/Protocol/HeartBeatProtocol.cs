using ClientNormal.Protocol.Tool;
using ClientNormal.Service;
using Protocol;
using System;

namespace ClientNormal.Protocol
{
    public static class HeartBeatProtocol
    {
        public static event Action OnHeartBeatAck;

        public static void ReqHeartBeat()
        {
            HeartBeatReq req = new HeartBeatReq();
            req.Header = new Header();
            req.Header.ProtoID = ProtoID.ReqHeartBeat;

            ProtocolParser.SendMessage(req);
        }

        public static void AckHeartBeat(byte[] buff)
        {
            HeartBeatAck ack = ProtocolBuffConvert.Deserialize<HeartBeatAck>(buff);

            OnHeartBeatAck?.Invoke();
        }
    }
}
