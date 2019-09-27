using Protocol;
using ProtoService.ProtoBuff;
using System;

namespace ProtoService.Protocol
{
    public static class LoginProtocol
    {
        public static event Action OnLoginAck;

        public static void ReqLogin(ulong gid)
        {
            LoginReq req = new LoginReq();
            req.Header = new Header();
            req.Header.ProtoID = ProtoID.ReqLogin;
            req.PlayerID = gid;

            ProtocolParser.SendMessage(req);
        }

        public static void AckLogin(byte[] buff)
        {
            LoginAck ack = ProtocolBuffConvert.Deserialize<LoginAck>(buff);

            OnLoginAck?.Invoke();
        }
    }
}
