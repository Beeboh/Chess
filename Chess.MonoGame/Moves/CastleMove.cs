using Chess.MonoGame.Board;
using Chess.MonoGame.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame.Moves
{
    public class CastleMove : Move
    {
        public CastleMove(MovementMove pieceMove, MovementMove rookMove) : base(pieceMove.Piece, pieceMove.SelectedTile, pieceMove.TargetTile)
        {
            PieceMove = pieceMove;
            RookMove = rookMove;
        }
        private Move PieceMove { get; }
        private Move RookMove { get; }
        public override void Execute()
        {
            PieceMove.Execute();
            RookMove.Execute();
        }

        public override void Undo()
        {
            PieceMove.Undo();
            RookMove.Undo();
        }
    }
}
