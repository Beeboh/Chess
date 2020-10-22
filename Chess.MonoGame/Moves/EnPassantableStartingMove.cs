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
        public EnPassantableStartingMove(ChessBoard board, ChessPiece piece, int targetrow, int targetcolumn) : base(piece, targetrow, targetcolumn)
        {
            Board = board;
            OldRow = Piece.Row;
            OldColumn = Piece.Column;
            executed = false;
        }
        private ChessBoard Board { get; }
        private int OldRow { get; }
        private int OldColumn { get; }
        private bool executed { get; set; }
        public override void Execute()
        {
            if (!executed)
            {
                Board[Piece.Row, Piece.Column].DetachPiece();
                Board[TargetRow, TargetColumn].AttachPiece(Piece);
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
                Board[TargetRow, TargetColumn].DetachPiece();
                Board[OldRow, OldColumn].AttachPiece(Piece);
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
