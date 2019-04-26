﻿using ClientNormal.Protocol.Tool;
using Google.Protobuf;
using Protocol;
using System;

namespace ClientNormal.Service
{
    public class ProtocolParser
    {
        private static Client m_client;

        private IProtocolContainer m_protocolContainer;

        public ProtocolParser(Client client, IProtocolContainer protocolContainer)
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
            Header header = Header.Parser.ParseFrom(buffer, 2, 4);
            //HeartBeatAck hba = HeartBeatAck.Parser.ParseFrom(buffer);

            Action<byte[]> ack;
            if (m_protocolContainer.TryGetValue(header.ProtoID, out ack))
                ack?.Invoke(buffer);

            Console.WriteLine("Receive ProtoID {0}.", header.ProtoID);
        }
    }
}
