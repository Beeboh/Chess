using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.MonoGame.Board;
using Chess.MonoGame.Moves;
using Chess.MonoGame.Pieces;

namespace Chess.MonoGame.Behaviours
{
    public class EnpassantBehaviour : CaptureBehaviour
    {
        public EnpassantBehaviour(int movementBaseStepX, int movementBaseStepY, int captureBaseStepX, int captureBaseStepY) : base(captureBaseStepX, captureBaseStepY, 1)
        {
            MovementBaseStepX = movementBaseStepX;
            MovementBaseStepY = movementBaseStepY;
        }
        private int MovementBaseStepX { get; }

        private int MovementBaseStepY { get; }

        

        public override ReadOnlyCollection<Move> GetCandidateMoves(BoardState board, ChessPiece piece)
        {
            ReadOnlyCollection<Tile> CandidateTiles = GetCandidateTiles(board, piece);
            
            List<Move> CandidateMoves = new List<Move>();
            foreach(Tile tile in CandidateTiles)
            {
                if (tile.Piece is IEnPassantable)
                {
                    IEnPassantable enPassantablePiece = tile.Piece as IEnPassantable;
                    if (enPassantablePiece.CurrentlyEnPassantable)
                    {
                        CandidateMoves.Add(new EnPassantMove(board[piece.Row,piece.Column], board[piece.Row + MovementBaseStepY, piece.Column + MovementBaseStepX], tile));
                    }
                }
            }
            return CandidateMoves.AsReadOnly();
        }
    }
}
