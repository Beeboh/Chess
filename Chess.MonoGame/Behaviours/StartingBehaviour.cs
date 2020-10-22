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
    public class StartingBehaviour : IPieceBehaviour
    {
        public StartingBehaviour(int baseStepX, int baseStepY, int maxSteps)
        {
            BaseStepX = baseStepX;
            BaseStepY = baseStepY;
            MaxSteps = maxSteps;
        }
        public int BaseStepX { get; }

        public int BaseStepY { get; }

        public int MaxSteps { get; }

        public ReadOnlyCollection<Move> GetCandidateMoves(ChessBoard board, ChessPiece piece)
        {
            List<Move> CandidateMoves = new List<Move>();
            if (!piece.HasMoved)
            {
                CandidateMoves.Add(new )
            }
        }
    }
}
