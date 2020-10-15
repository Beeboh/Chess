using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame
{
    public interface PieceBehaviour
    {
        List<Move> GetCandidateMoves(ChessBoard board, ChessPiece piece);
        int BaseStepX { get; }
        int BaseStepY { get; }
        int MaxSteps { get; }
    }
}