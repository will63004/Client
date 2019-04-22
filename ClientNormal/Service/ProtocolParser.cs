using ClientNormal.Protocol.Tool;
using Google.Protobuf;
using Protocol;
using System;

namespace ClientNormal.Service
{
    public class ProtocolParser
    {
        private Client m_client;

        public ProtocolParser(Client client)
        {
            m_client = client;

            m_client.OnReceiveHandle += OnReceiveHandle;
        }

        ~ProtocolParser()
        {
            m_client.OnReceiveHandle -= OnReceiveHandle;
        }
        public void SendMessage(IMessage message)
        {
            m_client.Send(ProtocolBuffConvert.Serialize(message));
        }

        private void OnReceiveHandle(byte[] buffer)
        {
            Person person = ProtocolBuffConvert.Deserialize<Person>(buffer);
            Console.WriteLine("ID {0}, Name {1}.", person.Id, person.Name);
        }
    }
}
