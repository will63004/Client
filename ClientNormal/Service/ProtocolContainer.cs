﻿using Protocol;
using System;
using System.Collections.Generic;

namespace ClientNormal.Service
{
    public class ProtocolContainer: IProtocolContainer
    {
        private Dictionary<ProtoID, Action<byte[]>> m_container = new Dictionary<ProtoID, Action<byte[]>>();

        public bool TryGetValue(ProtoID protoID, out Action<byte[]> ack)
        {
            return m_container.TryGetValue(protoID, out ack);
        }
    }
}
