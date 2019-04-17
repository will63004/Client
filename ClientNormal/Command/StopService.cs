using ClientNormal;

namespace ClientNormal.Command
{
    public class StopService : ICommand
    {
        public void Execute()
        {
            Program.StopService();
        }
    }
}
