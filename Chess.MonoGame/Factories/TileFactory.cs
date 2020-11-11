using Chess.MonoGame.Board;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame.Factories
{
    public abstract class TileFactory
    {
        public abstract Tile GetTile(int row, int column, TileColor tileColor, Texture2D texture);
    }
}
