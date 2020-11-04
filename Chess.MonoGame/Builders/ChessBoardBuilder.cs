using Chess.MonoGame.Board;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame.Builders
{
    public abstract class ChessBoardBuilder
    {
        protected ChessBoard Board { get; set; }
        public abstract void CreateEmptyBoard(Point origin, int tileWidth, int tileHeight);
        public abstract void AddPieces();
        public ChessBoard GetBoard()
        {
            return Board;
        }
    }
}
