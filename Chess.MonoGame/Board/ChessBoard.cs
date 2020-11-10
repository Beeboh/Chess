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
            CurrentState = initialState;
            boardStates = new List<BoardState>();
            BoardStates = boardStates.AsReadOnly();
        }

        private List<BoardState> boardStates;

        public Point Origin { get; }
        public int TileHeight { get; }
        public int TileWidth { get; }

        public ReadOnlyCollection<BoardState> BoardStates { get; }
        public BoardState CurrentState { get; }
        public void SaveBoardState()
        {
            BoardState CopyOfCurrentState = CurrentState.GetCopy();
            boardStates.Add(CopyOfCurrentState);
        }
    }
}
