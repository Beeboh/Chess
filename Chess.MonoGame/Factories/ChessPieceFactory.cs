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
        public abstract ChessPiece GetPiece(Alliance alliance, Texture2D texture);

    }
}
