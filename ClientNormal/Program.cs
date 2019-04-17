using ClientNormal.Command;
using ClientNormal.Service;
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
            Student student = new Student();
            student.Name = "Client";
            student.Age = 50;

            protocolParser.SendMessage(student);

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
