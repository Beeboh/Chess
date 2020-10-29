using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame
{
    public class ChessClock
    {
        public ChessClock(Player player, TimeSpan starttime)
        {
            Player = player;

            if (starttime.TotalMilliseconds <= 0)
            {
                StartTime = TimeSpan.Zero;
                OutOfTime = true;
            }
            else
            {
                StartTime = starttime;
                OutOfTime = false;
            }
            Time = StartTime;
        }
        public Player Player { get; }
        private TimeSpan StartTime { get; }
        public TimeSpan Time { get; private set; }
        public bool OutOfTime { get; private set; }

        public void SubtractTime(TimeSpan time)
        {
            if (!OutOfTime)
            {
                Time = Time.Subtract(time);
                if (Time.TotalMilliseconds <= 0)
                {
                    Time = TimeSpan.Zero;
                    OutOfTime = true;
                }
            }
        }
        public void AddTime(TimeSpan time)
        {
            if (!OutOfTime)
            {
                Time = Time.Add(time);
            }
        }
    }
}
