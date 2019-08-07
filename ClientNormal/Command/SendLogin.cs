using ClientNormal.Protocol;
using System;

namespace ClientNormal.Command
{
    public class SendLogin : ICommand
    {
        public void Execute()
        {
            Console.Write("GID:");
            string gidstr = Console.ReadLine();
            ulong gid;
            if (UInt64.TryParse(gidstr, out gid))
            {
                LoginProtocol.ReqLogin(gid);
            }
            else
                Console.Write("Input invalid GID");
        }
    }
}