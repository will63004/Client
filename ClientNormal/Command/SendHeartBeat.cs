using ClientNormal.Protocol;
namespace ClientNormal.Command
{
    public class SendHeartBeat: ICommand
    {
        public void Execute()
        {
            HeartBeatProtocol.ReqHeartBeat();
        }
    }
}
