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
        protected BoardState Board { get; set; }
        public abstract void CreateEmptyBoard(Point origin);
        public abstract void AddPieces();
        public BoardState GetBoard()
        {
            return Board;
        }
    }
}
