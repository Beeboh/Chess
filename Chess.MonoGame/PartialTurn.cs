using Chess.MonoGame.Board;
using Chess.MonoGame.Moves;
using Chess.MonoGame.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame
{
    public class PartialTurn
    {
        public PartialTurn(Player player, Move move, TimeSpan timestart, TimeSpan timeend)
        {
            Player = player;
            Move = move;
            TimeStart = timestart;
            TimeEnd = timeend;
            Duration = (timeend - timestart).Duration();
        }

        public Player Player { get; }
        public Move Move { get; }
        public TimeSpan TimeStart { get; }
        public TimeSpan TimeEnd { get; }
        public TimeSpan Duration { get; }

    }
}
