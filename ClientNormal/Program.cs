using ClientNormal.Command;
using Grpc.Core;
using System;
using TcpService.Service;
using ProtoService.ProtoBuff;
using Game.HeartBeat;
using Proxy.SendProto;

namespace ClientNormal
{
    class Program
    {
        private static bool m_trggierStop;

        static void Main(string[] args)
        {
            string ip = "127.0.0.1";
            int port = 3000;
            Client m_client = new Client(ip, port);
            m_client.Start();

            IProtocolContainer protocolContainer = new ProtocolContainer(); 
            ProtocolParser protocolParser = new ProtocolParser(m_client, protocolContainer);

            Channel channel = new Channel(ip + ":3001", ChannelCredentials.Insecure);
            //channel.ConnectAsync(null);

            HeartBeat heartBeat = new HeartBeat(new SendHeartBeat(channel));         

            do
            {
                CommandSystem.Command(Console.ReadLine());

            } while (!m_trggierStop);
        }

        public static void StopService()
        {
            m_trggierStop = true;
        }
    }
}
