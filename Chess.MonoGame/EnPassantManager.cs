using Chess.MonoGame.Behaviours;
using Chess.MonoGame.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame
{
    public class EnPassantManager
    {
        public EnPassantManager(ChessBoard board)
        {
            Board = board;
        }
        private ChessBoard Board { get; }
        public void DisableEnPassantables(Alliance alliance)
        {
            foreach(Tile tile in Board.CurrentState.Tiles)
            {
                if (!tile.IsVacant)
                {
                    if(tile.Piece is IEnPassantable) 
                    {
                        if(tile.Piece.Alliance == alliance)
                        {
                            IEnPassantable enPassantablePiece = tile.Piece as IEnPassantable;
                            enPassantablePiece.CurrentlyEnPassantable = false;
                        }
                    }
                }
            }
        }
    }
}
