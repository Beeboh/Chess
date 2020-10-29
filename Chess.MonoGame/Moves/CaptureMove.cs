using Chess.MonoGame.Board;
using Chess.MonoGame.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame.Moves
{
    public class CaptureMove : Move
    {
        public CaptureMove(Tile selectedTile, Tile targetTile) : base(selectedTile.Piece, selectedTile, targetTile)
        {
            CapturedPiece = targetTile.Piece;
        }
        public ChessPiece CapturedPiece { get; }
        
        private bool executed { get; set; }

        public override void Execute()
        {
            if (!executed)
            {
                SelectedTile.DetachPiece();
                TargetTile.AttachPiece(Piece);
                executed = true;
            }
        }

        public override void Undo()
        {
            if (executed)
            {
                TargetTile.AttachPiece(CapturedPiece);
                SelectedTile.AttachPiece(Piece);
                executed = false;
            }
        }
    }
}
