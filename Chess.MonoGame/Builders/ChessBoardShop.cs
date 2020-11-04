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
        public BoardState GetBoard(Point origin, ChessBoardBuilder builder)
        {
            builder.CreateEmptyBoard(origin);
            builder.AddPieces();
            return builder.GetBoard();
        }
    }
}
