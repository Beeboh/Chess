using Chess.MonoGame.Board;
using Chess.MonoGame.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame.Moves
{
    public abstract class CaptureMove : Move
    {
        public CaptureMove(Tile selectedTile, Tile targetMoveTile, Tile targetCaptureTile) : base(selectedTile.Piece, selectedTile, targetMoveTile)
        {
            CapturedPiece = targetCaptureTile.Piece;
            PieceHasMoved = Piece.HasMoved;
            TargetCaptureTile = targetCaptureTile;
            TargetMoveTile = targetMoveTile;
        }

        public ChessPiece CapturedPiece { get; }
        private Tile TargetMoveTile { get; }
        private Tile TargetCaptureTile { get; }

        private bool executed { get; set; }

        private bool PieceHasMoved { get; set; }

        public override void Execute()
        {
            if (!executed)
            {
                SelectedTile.DetachPiece();
                TargetCaptureTile.DetachPiece();
                TargetMoveTile.AttachPiece(Piece, true);
                executed = true;
            }
        }

        public override void Undo()
        {
            if (executed)
            {
                TargetMoveTile.DetachPiece();
                TargetCaptureTile.AttachPiece(CapturedPiece);
                SelectedTile.AttachPiece(Piece, PieceHasMoved);
                executed = false;
            }
        }

    }
}
