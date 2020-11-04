using Chess.MonoGame.Board;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame
{
    public class TurnManager
    {
        public TurnManager(Player whiteplayer, Player blackplayer, ClockManager clockManager, ChessBoard board)
        {
            turns = new List<Turn>();
            Turns = turns.AsReadOnly();
            ClockManager = clockManager;
            WhitePlayer = whiteplayer;
            BlackPlayer = blackplayer;
            Board = board;
            EnPassantManager = new EnPassantManager(board);
        }
        private List<Turn> turns;
        public ReadOnlyCollection<Turn> Turns { get; }
        private PartialTurn FirstWhiteTurn { get; set; }
        private Player WhitePlayer { get; }
        private Player BlackPlayer { get; }
        private ChessBoard Board { get; }
        private EnPassantManager EnPassantManager { get; }

        public ClockManager ClockManager { get; }
        
        public PartialTurnTracker AddPartialTurn(PartialTurn partialTurn)
        {
            Alliance alliance = partialTurn.Player.Alliance;
            if (turns.Count > 0)
            {
                if (alliance == Alliance.White)
                {
                    turns.Add(new Turn(turns.Count + 1, partialTurn));
                }
                else if(alliance == Alliance.Black)
                {
                    turns[turns.Count - 1].BlackTurn = partialTurn;
                }
            }
            else if (turns.Count == 0)
            {
                if (alliance == Alliance.White)
                {
                    FirstWhiteTurn = partialTurn;
                }
                else if (alliance == Alliance.Black)
                {
                    turns.Add(new Turn(turns.Count + 1, FirstWhiteTurn, partialTurn));
                }
            }
            OnPartialTurnAdded();
            Player PlayerForNextPartialTurn = null;
            if (partialTurn.Player == WhitePlayer)
            {
                PlayerForNextPartialTurn = BlackPlayer;
            }
            else if (partialTurn.Player == BlackPlayer)
            {
                PlayerForNextPartialTurn = WhitePlayer;
            }

            EnPassantManager.DisableEnPassantables(PlayerForNextPartialTurn.Alliance);
            return new PartialTurnTracker(PlayerForNextPartialTurn, ClockManager.GetCurrentClock(), Board);

        }
        private void OnPartialTurnAdded()
        {
            ClockManager.IncrementTime();
            ClockManager.NextClock();
        }
    }
}
