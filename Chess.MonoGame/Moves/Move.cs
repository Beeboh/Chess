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
        public Move(ChessPiece piece, int targetrow, int targetcolumn)
        {
            Piece = piece;
            TargetRow = targetrow;
            TargetColumn = targetcolumn;
        }
        public abstract void Execute();
        public abstract void Undo();
        public ChessPiece Piece { get; }
        public int TargetRow { get; }
        public int TargetColumn { get; }
    }
}
