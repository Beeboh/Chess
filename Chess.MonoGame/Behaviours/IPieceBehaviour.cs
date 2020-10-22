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
    public interface IPieceBehaviour
    {
        ReadOnlyCollection<Move> GetCandidateMoves(ChessBoard board, ChessPiece piece);
        int BaseStepX { get; }
        int BaseStepY { get; }
        int MaxSteps { get; }
    }
}