using Chess.MonoGame.Board;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame.Builders
{
    public class ChessBoardShop
    {
        public ChessBoard GetBoard(Point origin, int tileWidth, int tileHeight, ChessBoardBuilder builder)
        {
            builder.CreateEmptyBoard(origin, tileWidth, tileHeight);
            builder.AddPieces();
            return builder.GetBoard();
        }
    }
}
