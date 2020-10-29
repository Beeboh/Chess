using Chess.MonoGame.Board;
using Chess.MonoGame.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame.Moves
{
    public abstract class Move
    {
        public Move(ChessPiece piece, Tile selectedTile, Tile targetTile)
        {
            Piece = piece;
            SelectedTile = selectedTile;
            TargetTile = targetTile;
        }
        public abstract void Execute();
        public abstract void Undo();
        public ChessPiece Piece { get; }
        public Tile SelectedTile { get; }
        public Tile TargetTile { get; }
    }
}
