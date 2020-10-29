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
    public class CaptureBehaviour : IPieceBehaviour
    {
        public CaptureBehaviour(int baseStepX, int baseStepY, int maxSteps, Alliance pieceAlliance)
        {
            BaseStepX = baseStepX;
            BaseStepY = baseStepY;
            MaxSteps = maxSteps;
            PieceAlliance = pieceAlliance;
        }
        public int BaseStepX { get; }

        public int BaseStepY { get; }

        public int MaxSteps { get; }

        private Alliance PieceAlliance { get; }

        public ReadOnlyCollection<Move> GetCandidateMoves(ChessBoard board, ChessPiece piece)
        {
            List<Move> CandidateMoves = new List<Move>();
            for(int i = 1; i <= MaxSteps; i++)
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
                    if (tile.Piece.Alliance != PieceAlliance)
                    {
                        CandidateMoves.Add(new CaptureMove(board[piece.Row, piece.Column], tile));
                    }
                    break;
                }
            }
            return CandidateMoves.AsReadOnly();
        }
    }
}
