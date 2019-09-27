using System.Timers;
using Game;

namespace Game.HeartBeat
{
    public class HeartBeat
    {
        private ISendHeartBeat m_sendHeartBeat;

        private Timer m_timer;

        public HeartBeat(ISendHeartBeat sendHeartBeat)
        {
            m_sendHeartBeat = sendHeartBeat;

            // Create a timer with a two second interval.
            m_timer = new Timer(GlobalDefine.HeartBeatInterval);
            // Hook up the Elapsed event for the timer. 
            m_timer.Elapsed += OnTimedEvent;
            m_timer.AutoReset = true;
            m_timer.Enabled = true;
            m_sendHeartBeat.Send();
        }

        ~HeartBeat()
        {
            m_timer.Elapsed -= OnTimedEvent;
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            m_sendHeartBeat.Send();
        }
    }
}
