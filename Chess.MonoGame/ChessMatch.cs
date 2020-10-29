using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Chess.MonoGame.Board;
using Chess.MonoGame.Moves;
using Chess.MonoGame.Pieces;

namespace Chess.MonoGame
{
    public class ChessMatch
    {
        public ChessMatch(ChessBoard board, Player whiteplayer, Player blackplayer)
        {
            Board = board;
            WhitePlayer = whiteplayer;
            BlackPlayer = blackplayer;
            ClockManager = new ClockManager(CreateClocks(new TimeSpan(0,5,0)), new TimeSpan(0,0,5));
            TurnManager = new TurnManager(whiteplayer, blackplayer, ClockManager, board);
            Started = false;
            Ended = false;
        }
        private ClockManager ClockManager { get; }
        private ChessBoard Board { get; }
        private Player WhitePlayer { get; }
        private Player BlackPlayer { get; }
        public PartialTurnTracker PartialTurnTracker { get; private set; }
        public TurnManager TurnManager { get; }

        public bool Started { get; private set; }
        public bool Ended { get; private set; }
        public Player Winner { get; }

        public void MouseClick(Point mouseposition)
        {
            Point MousePositionOnBoard = mouseposition - Board.Origin;
            int SelectedColumn = MousePositionOnBoard.X / Board.TileWidth;
            int SelectedRow = MousePositionOnBoard.Y / Board.TileHeight;
            if (Board.ValidTile(SelectedRow, SelectedColumn))
            {
                Tile SelectedTile = Board[SelectedRow, SelectedColumn];
                PartialTurnTracker.SelectTile(SelectedTile);
                if(PartialTurnTracker.PartialTurn != null)
                {
                    PartialTurnTracker = TurnManager.AddPartialTurn(PartialTurnTracker.PartialTurn);
                }
            }
        }
        public void UpdateClock(TimeSpan delta)
        {
            ClockManager.SubTractTime(delta);
            ChessClock clock = ClockManager.GetCurrentClock();
            System.Diagnostics.Debug.WriteLine(string.Format("{0}:{1}:{2}", clock.Time.Hours, clock.Time.Minutes, clock.Time.Seconds));
        }
        public void Start()
        {
            Started = true;
            PartialTurnTracker = new PartialTurnTracker(WhitePlayer, ClockManager.GetCurrentClock(), Board);
        }
        public ChessBoard GetBoard()
        {
            return Board;
        }

        private ReadOnlyCollection<ChessClock> CreateClocks(TimeSpan startTime)
        {
            ChessClock WhiteClock = new ChessClock(WhitePlayer, startTime);
            ChessClock BlackClock = new ChessClock(BlackPlayer, startTime);
            return new List<ChessClock>() { WhiteClock, BlackClock }.AsReadOnly();
        }
    }

}
