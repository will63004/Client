using Google.Protobuf;
using Protocol;
using System;
using TcpService.Service;

namespace ProtoService.ProtoBuff
{
    public class ProtocolParser
    {
        private static ITcpClient m_client;

        private IProtocolContainer m_protocolContainer;

        public ProtocolParser(ITcpClient client, IProtocolContainer protocolContainer)
        {
            m_client = client;

            m_protocolContainer = protocolContainer;

            m_client.OnReceiveHandle += OnReceiveHandle;
        }

        ~ProtocolParser()
        {
            m_client.OnReceiveHandle -= OnReceiveHandle;
        }
        public static void SendMessage(IMessage message)
        {
            m_client.Send(ProtocolBuffConvert.Serialize(message));
        }

        private void OnReceiveHandle(byte[] buffer)
        {
            if (buffer.Length < 2)
                return;

            //ProtocolBuff 數據結構Tag為2byte
            Header header = Header.Parser.ParseFrom(buffer, 2, buffer.Length - 2);

            Action<byte[]> ack;
            if (m_protocolContainer.TryGetValue(header.ProtoID, out ack))
                ack?.Invoke(buffer);

            Console.WriteLine("Receive ProtoID {0}.", header.ProtoID);
        }
    }
}
