using Chess.MonoGame.Board;
using Chess.MonoGame.Moves;
using Chess.MonoGame.Pieces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame.Behaviours
{
    public abstract class CaptureBehaviour : IPieceBehaviour
    {
        public CaptureBehaviour(int baseStepX, int baseStepY, int maxSteps)
        {
            BaseStepX = baseStepX;
            BaseStepY = baseStepY;
            MaxSteps = maxSteps;
        }
        public int BaseStepX { get; }

        public int BaseStepY { get; }

        public int MaxSteps { get; }

        public abstract ReadOnlyCollection<Move> GetCandidateMoves(BoardState board, ChessPiece piece);

        protected ReadOnlyCollection<Tile> GetCandidateTiles(BoardState board, ChessPiece piece)
        {
            List<Tile> CandidateTiles = new List<Tile>();
            for (int i = 1; i <= MaxSteps; i++)
            {
                int Column = piece.Column + i * BaseStepX;
                int Row = piece.Row + i * BaseStepY;
                if (!board.ValidTile(Row, Column))
                {
                    break;
                }
                Tile tile = board[Row, Column];
                if (!tile.IsVacant)
                {
                    if (tile.Piece.Alliance != piece.Alliance)
                    {
                        CandidateTiles.Add(tile);
                    }
                    break;
                }
            }
            return CandidateTiles.AsReadOnly();
        }
    }
}
