using Chess.MonoGame.Board;
using Chess.MonoGame.Moves;
using Chess.MonoGame.Pieces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame
{
    public class InCheckChecker
    {
        public InCheckChecker()
        {

        }
        public bool InCheck(BoardState boardState, Alliance alliance)
        {
            foreach(Tile tile in boardState.Tiles)
            {
                if (!tile.IsVacant)
                {
                    bool EnemyPiece = !(tile.Piece.Alliance == alliance);
                    if (EnemyPiece)
                    {
                        ReadOnlyCollection<Move> CandidateMoves = tile.Piece.GetCandidateMoves(boardState);
                        foreach(Move CandidateMove in CandidateMoves)
                        {
                            if(CandidateMove is CaptureMove)
                            {
                                CaptureMove captureMove = CandidateMove as CaptureMove;
                                if (captureMove.CapturedPiece is King)
                                {
                                    King TargetKing = captureMove.CapturedPiece as King;
                                    if (TargetKing.Alliance == alliance)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}
