using Chess.MonoGame.Pieces;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame.Factories
{
    public abstract class ChessPieceFactory
    {
        public ChessPieceFactory(Alliance alliance, Texture2D texture)
        {
            Alliance = alliance;
            Texture = texture;
        }
        protected Alliance Alliance { get; }
        protected Texture2D Texture { get; }
        public abstract ChessPiece GetPiece(int row, int column);
        public ChessPiece GetPiece()
        {
            return GetPiece(0, 0);
        }

    }
}
