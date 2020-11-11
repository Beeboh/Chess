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
    public class CastleBehaviour : MovementBehaviour
    {
        public CastleBehaviour(int xMovement, int yMovement, int XrookSearch, int YrookSearch, int rookSearchRange, int XrookMove, int YrookMove) : base(xMovement, yMovement, 1)
        {
            XRookSearch = XrookSearch;
            YRookSearch = YrookSearch;
            RookSearchRange = rookSearchRange;
            XRookMove = XrookMove;
            YRookMove = YrookMove;
        }
        private int XRookSearch { get; }
        private int YRookSearch { get; }
        private int RookSearchRange { get; }
        private int XRookMove { get; }
        private int YRookMove { get; }

        public override ReadOnlyCollection<Move> GetCandidateMoves(BoardState board, ChessPiece piece)
        {
            List<Move> CandidateMoves = new List<Move>();
            if (!piece.HasMoved)
            {
                int RookRow = piece.Row + YRookSearch*RookSearchRange;
                int RookColumn = piece.Column + XRookSearch*RookSearchRange;
                if (board.ValidTile(RookRow, RookColumn))
                {
                    Tile RookTile = board[RookRow, RookColumn];
                    if (!RookTile.IsVacant)
                    {
                        if (RookTile.Piece is Rook)
                        {
                            if (!RookTile.Piece.HasMoved)
                            {
                                bool ValidPieceConditions = true;
                                for(int i = 1; i < RookSearchRange; i++)
                                {
                                    int SearchedRow = piece.Row + i * YRookSearch;
                                    int SearchedColumn = piece.Column + i * XRookSearch;
                                    if (board.ValidTile(SearchedRow, SearchedColumn))
                                    {
                                        Tile intermediateTile = board[SearchedRow, SearchedColumn];
                                        if (!intermediateTile.IsVacant)
                                        {
                                            ValidPieceConditions = false;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        ValidPieceConditions = false;
                                        break;
                                    }
                                }
                                if (ValidPieceConditions)
                                {
                                    if (board.ValidTile(RookRow + YRookMove, RookColumn + XRookMove))
                                    {
                                        Tile NewRookTile = board[RookRow + YRookMove, RookColumn + XRookMove];
                                        MovementMove RookMove = new MovementMove(RookTile, NewRookTile);
                                        ReadOnlyCollection<Tile> CandidateTiles = GetCandidateTiles(board, piece);
                                        foreach (Tile CandidateTile in CandidateTiles)
                                        {
                                            MovementMove PieceMove = new MovementMove(board[piece.Row, piece.Column], CandidateTile);
                                            Move CastleMove = new CastleMove(PieceMove, RookMove);
                                            CandidateMoves.Add(CastleMove);
                                        }
                                    }
                                    
                                }
                                //targetting movement squares/in check
                                foreach(Tile tile in board.Tiles)
                                {
                                    if (!tile.IsVacant)
                                    {
                                        if(tile.Piece.Alliance != piece.Alliance)
                                        {
                                            //NOT DONE
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return CandidateMoves.AsReadOnly();
        }
    }
}
