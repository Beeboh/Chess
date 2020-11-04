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
    public class StartingMovementBehaviour : MovementBehaviour
    {
        public StartingMovementBehaviour(int baseStepX, int baseStepY, int maxSteps) : base (baseStepX, baseStepY, maxSteps)
        {

        }

        public override ReadOnlyCollection<Move> GetCandidateMoves(BoardState board, ChessPiece piece)
        {
            List<Move> CandidateMoves = new List<Move>();
            if (!piece.HasMoved)
            {
                ReadOnlyCollection<Tile> CandidateTiles = GetCandidateTiles(board, piece);
                foreach(Tile Tile in CandidateTiles)
                {
                    if(piece is IEnPassantable)
                    {
                        CandidateMoves.Add(new EnPassantableStartingMove(board[piece.Row, piece.Column], Tile));
                    }
                    else
                    {
                        CandidateMoves.Add(new MovementMove(board[piece.Row, piece.Column], Tile));
                    }
                    
                }
            }
            return CandidateMoves.AsReadOnly();
        }
    }
}
