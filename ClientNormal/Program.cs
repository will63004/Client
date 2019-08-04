using ClientNormal.Command;
using ClientNormal.Game;
using ClientNormal.Service;
using System;

namespace ClientNormal
{
    class Program
    {
        private static bool m_trggierStop;

        static void Main(string[] args)
        {
            string ip = "127.0.0.1";
            int port = 61000;
            Client m_client = new Client(ip, port);
            m_client.Start();

            IProtocolContainer protocolContainer = new ProtocolContainer();
            ProtocolParser protocolParser = new ProtocolParser(m_client, protocolContainer);

            GameSystem gameSystem = new GameSystem();

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
