using Chess.MonoGame.Board;
using Chess.MonoGame.Moves;
using Chess.MonoGame.Pieces;
using Chess.MonoGame.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame.Behaviours
{
    public class BasicMovementBehaviour : MovementBehaviour
    {
        public BasicMovementBehaviour(int baseStepX, int baseStepY, int maxSteps) : base(baseStepX, baseStepY, maxSteps)
        {
            
        }

        public override ReadOnlyCollection<Move> GetCandidateMoves(BoardState board, ChessPiece piece)
        {
            ReadOnlyCollection<Tile> CandidateTiles = GetCandidateTiles(board, piece);

            List<Move> CandidateMoves = new List<Move>();
            foreach(Tile tile in CandidateTiles)
            {
                CandidateMoves.Add(new MovementMove(board[piece.Row, piece.Column], tile));
            }
            return CandidateMoves.AsReadOnly();
        }

    }
}
