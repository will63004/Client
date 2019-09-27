using System;

namespace TcpService.Service
{
    public interface ITcpClient
    {
        void Send(byte[] msg);
        event Action<byte[]> OnReceiveHandle;
    }
}
