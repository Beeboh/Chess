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
    public class MovementBehaviour : IPieceBehaviour
    {
        public MovementBehaviour(int baseStepX, int baseStepY, int maxSteps)
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
            List<Move> Moves = new List<Move>();
            for(int i = 1; i <= MaxSteps; i++)
            {
                int Column = piece.Column + i * BaseStepX;
                int Row = piece.Row + i * BaseStepY;
                if(!board.ValidTile(Row,Column))
                {
                    break;
                }
                Tile Tile = board[Row, Column];
                if (!Tile.IsVacant)
                {
                    break;
                }
                Moves.Add(new MovementMove(board, piece, Row, Column));
            }
            return Moves.AsReadOnly();
        }
    }
}
