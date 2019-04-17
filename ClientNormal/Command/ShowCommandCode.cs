namespace ClientNormal.Command
{
    public class ShowCommandCode : ICommand
    {
        public void Execute()
        {
            CommandSystem.ShowCommandCode();
        }
    }
}
