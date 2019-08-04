using ClientNormal.Protocol;
using System.Timers;

namespace ClientNormal.Game
{
    public class HeartBeat
    {
        private Timer m_timer;

        public HeartBeat()
        {
            // Create a timer with a two second interval.
            m_timer = new Timer(GlobalDefine.HeartBeatInterval);
            // Hook up the Elapsed event for the timer. 
            m_timer.Elapsed += OnTimedEvent;
            m_timer.AutoReset = true;
            m_timer.Enabled = true;
            HeartBeatProtocol.ReqHeartBeat();
        }

        ~HeartBeat()
        {
            m_timer.Elapsed -= OnTimedEvent;
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            HeartBeatProtocol.ReqHeartBeat();
        }
    }
}
