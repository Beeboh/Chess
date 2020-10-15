using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame
{
    public class Pawn : ChessPiece
    {
        public Pawn(Alliance alliance, Texture2D texture) : base(alliance, texture)
        {

        }
        public Pawn(Alliance alliance, Texture2D texture, int x, int y) : base(alliance, texture, x, y)
        {

        }
    }
}
