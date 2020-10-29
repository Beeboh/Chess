using Chess.MonoGame.Behaviours;
using Chess.MonoGame.Board;
using Chess.MonoGame.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame.Moves
{
    public class EnPassantableStartingMove : StartingMove
    {
        public EnPassantableStartingMove(Tile selectedTile, Tile targetTile) : base(selectedTile, targetTile)
        {
            executed = false;
        }
        private bool executed { get; set; }
        public override void Execute()
        {
            if (!executed)
            {
                SelectedTile.DetachPiece();
                TargetTile.AttachPiece(Piece);
                if (Piece is IEnPassantable)
                {
                    IEnPassantable enPassantablePiece = Piece as IEnPassantable;
                    enPassantablePiece.CurrentlyEnPassantable = true;
                }
                executed = true;
            }
            
        }
        public override void Undo()
        {
            if (executed)
            {
                SelectedTile.DetachPiece();
                TargetTile.AttachPiece(Piece);
                if (Piece is IEnPassantable)
                {
                    IEnPassantable enPassantablePiece = Piece as IEnPassantable;
                    enPassantablePiece.CurrentlyEnPassantable = false;
                }
                executed = false;
            }
        }
    }
}
