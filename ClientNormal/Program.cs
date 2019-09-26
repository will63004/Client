using ClientNormal.Command;
using ClientNormal.Game;
using ClientNormal.Service;
using Grpc.Core;
using System;
using Protocol;

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

            GameSystem gameSystem = new GameSystem();

            Channel channel = new Channel(ip +":3001", ChannelCredentials.Insecure);
            //channel.ConnectAsync(null);

            var client = new EchoChat.EchoChatClient(channel);
            Header header = new Header();
            header.PlayerID = 1;
            var reply = client.SendChat(new ChatReq { Header = header,  Content = "Test" });            

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
