using System;
using System.Collections.Generic;

namespace ClientNormal.Command
{
    static class CommandSystem
    {
        private static Dictionary<string, ICommand> m_commandContainer;

        static CommandSystem()
        {
            m_commandContainer = new Dictionary<string, ICommand>();

            m_commandContainer.Add("Stop Service", new StopService());
            m_commandContainer.Add("Show Command Code", new ShowCommandCode());
            m_commandContainer.Add("Send HeartBeat", new SendHeartBeat());
        }

        public static void Command(string commandCode)
        {
            ICommand command;
            if (m_commandContainer.TryGetValue(commandCode, out command))
                command.Execute();
            else
                Console.WriteLine("Error Command Code!");
        }

        public static void ShowCommandCode()
        {
            Console.WriteLine("=========================================");
            var e = m_commandContainer.GetEnumerator();
            while (e.MoveNext())
            {
                string commandCode = e.Current.Key;
                Console.WriteLine(commandCode);
            }
            Console.WriteLine("=========================================");
        }
    }
}
