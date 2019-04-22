using ClientNormal.Command;
using ClientNormal.Service;
using Protocol;
using System;
using System.Threading;

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

            ProtocolParser protocolParser = new ProtocolParser(m_client);

            Thread.Sleep(5000);
            Person person = new Person();
            person.Header = new Header();
            person.Header.ProtoID = ProtoID.HeartBeat;
            person.Id = 1;
            person.Name = "Client";

            protocolParser.SendMessage(person);

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
