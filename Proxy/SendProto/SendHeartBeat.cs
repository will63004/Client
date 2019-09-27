using Game.HeartBeat;
using Grpc.Core;
using Protocol;

namespace Proxy.SendProto
{
    public class SendHeartBeat : ISendHeartBeat
    {
        private Channel channel;

        private EchoHeartBeat.EchoHeartBeatClient echo;

        public SendHeartBeat(Channel channel)
        {
            this.channel = channel;

            echo = new EchoHeartBeat.EchoHeartBeatClient(channel);   
        }

        public void Send()
        {
            Header header = new Header();
            header.PlayerID = 1;
            var reply = echo.HeartBeat(new  HeartBeatReq { Header = header});
        }
    }
}
