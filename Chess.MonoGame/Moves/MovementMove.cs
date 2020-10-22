using Chess.MonoGame.Board;
using Chess.MonoGame.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame.Moves
{
    public class MovementMove : Move
    {
        public MovementMove(ChessBoard board, ChessPiece piece, int targetrow, int targetcolumn) : base(piece, targetrow, targetcolumn)
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
                Board[OldRow, OldColumn].DetachPiece();
                Board[TargetRow, TargetColumn].AttachPiece(Piece);
                executed = true;
            }
        }

        public override void Undo()
        {
            if (executed)
            {
                Board[TargetRow, TargetColumn].DetachPiece();
                Board[OldRow, OldColumn].AttachPiece(Piece);
                executed = false;
            }
        }
    }
}
