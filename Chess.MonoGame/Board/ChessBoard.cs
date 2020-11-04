using Chess.MonoGame.Moves;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame.Board
{
    public class ChessBoard
    {
        public ChessBoard(Point origin, int tileWidth, int tileHeight, BoardState initialState)
        {
            Origin = origin;
            TileHeight = tileHeight;
            TileWidth = tileWidth;
            boardStates = new List<BoardState>();
            boardStates.Add(initialState);
            BoardStates = boardStates.AsReadOnly();
        }

        private List<BoardState> boardStates;

        public Point Origin { get; }
        public int TileHeight { get; }
        public int TileWidth { get; }

        public ReadOnlyCollection<BoardState> BoardStates { get; }
        public BoardState CurrentState => BoardStates[BoardStates.Count - 1];
        public void Move(Move move)
        {
            move.Execute();
            BoardState NewState = CurrentState.GetCopy();
            boardStates.Add(NewState);
        }
    }
}
