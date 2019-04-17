using ClientNormal.Protocol.Tool;
using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Student student = ProtocolBuffConvert.Deserialize<Student>(buffer);
            Console.WriteLine("Name {0}, Age {1}.", student.Name, student.Age);
        }
    }
}
