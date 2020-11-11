using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.MonoGame.Board;
using Chess.MonoGame.Moves;
using Chess.MonoGame.Pieces;
using Chess.MonoGame.Utils;

namespace Chess.MonoGame.Behaviours
{
    public abstract class MovementBehaviour : IPieceBehaviour
    {
        public MovementBehaviour(int baseStepX, int baseStepY, int maxSteps)
        {
            BaseStepX = baseStepX;
            BaseStepY = baseStepY;
            MaxSteps = maxSteps;
            XYCouple ReducedBaseStep = RatioReducer.Reduce(BaseStepX, BaseStepY);
            ReducedBaseStepX = ReducedBaseStep.X;
            ReducedBaseStepY = ReducedBaseStep.Y;
            if (ReducedBaseStepX != 0)
            {
                ReductionRatio = baseStepX / ReducedBaseStepX;
            }
            else if (ReducedBaseStepY != 0)
            {
                ReductionRatio = baseStepY / ReducedBaseStepY;
            }
            else
            {
                ReductionRatio = 1;
            }
            
        }
        public int BaseStepX { get; }

        public int BaseStepY { get; }

        public int MaxSteps { get; }

        protected int ReducedBaseStepX { get; }

        protected int ReducedBaseStepY { get; }

        protected int ReductionRatio { get; }

        public abstract ReadOnlyCollection<Move> GetCandidateMoves(BoardState board, ChessPiece piece);
        protected ReadOnlyCollection<Tile> GetCandidateTiles(BoardState board, ChessPiece piece)
        {
            List<Tile> MoveableTiles = new List<Tile>();
            for (int i = 1; i <= MaxSteps; i++)
            {
                int TargetColumn = piece.Column + i * BaseStepX;
                int TargetRow = piece.Row + i * BaseStepY;
                bool IntermediateTileBlocked = false;
                for (int j = 1; j < ReductionRatio; j++)
                {
                    int IntermediateColumn = piece.Column + (i - 1 + j) * ReducedBaseStepX;
                    int IntermediateRow = piece.Row + (i - 1 + j) * ReducedBaseStepY;
                    if (!board.ValidTile(IntermediateRow, IntermediateColumn))
                    {
                        IntermediateTileBlocked = true;
                        break;
                    }
                    Tile IntermediateTile = board[IntermediateRow, IntermediateColumn];
                    if (!IntermediateTile.IsVacant)
                    {
                        IntermediateTileBlocked = true;
                        break;
                    }
                }
                if (IntermediateTileBlocked)
                {
                    break;
                }
                if (!board.ValidTile(TargetRow, TargetColumn))
                {
                    break;
                }
                Tile Tile = board[TargetRow, TargetColumn];
                if (!Tile.IsVacant)
                {
                    break;
                }
                MoveableTiles.Add(Tile);
            }
            return MoveableTiles.AsReadOnly();
        }

        
    }
}
