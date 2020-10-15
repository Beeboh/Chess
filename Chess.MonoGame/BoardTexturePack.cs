using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Chess.MonoGame
{
    public class BoardTexturePack
    {
        public BoardTexturePack(Texture2D light_square, Texture2D dark_square)
        {
            LightSquare = light_square;
            DarkSquare = dark_square;
        }
        public Texture2D LightSquare { get; }
        public Texture2D DarkSquare { get; }
    }
}
