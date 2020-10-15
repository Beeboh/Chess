using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame
{
    public class Bishop : ChessPiece
    {
        public Bishop(Alliance alliance, Texture2D texture) : base(alliance, texture)
        {

        }
        public Bishop(Alliance alliance, Texture2D texture, int x, int y) : base(alliance, texture, x, y)
        {

        }
    }
}
