using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame
{
    public class ClockManager
    {
        public ClockManager(IEnumerable<ChessClock> clocks, TimeSpan increment)
        {
            Increment = increment;
            List<ChessClock> clocklist = new List<ChessClock>(clocks);
            Clocks = clocklist.AsReadOnly();
            index = 0;
        }
        private TimeSpan Increment { get; }
        private ReadOnlyCollection<ChessClock> Clocks { get; }
        private int index;
        public ChessClock GetCurrentClock()
        {
            return Clocks[index];
        }

        public void NextClock()
        {
            if (index >= Clocks.Count - 1)
            {
                index = 0;
            }
            else
            {
                index++;
            }
        }
        public void PreviousClock()
        {
            if (index == 0)
            {
                index = Clocks.Count - 1;
            }
            else
            {
                index--;
            }
        }
        public void SubTractTime(TimeSpan timeSpan)
        {
            if (Clocks.Count > 0)
            {
                Clocks[index].SubtractTime(timeSpan);
            }
        }
        public void AddTime(TimeSpan timeSpan)
        {
            if (Clocks.Count > 0)
            {
                Clocks[index].AddTime(timeSpan);
            }
        }
        public void IncrementTime()
        {
            AddTime(Increment);
        }
    }
}
