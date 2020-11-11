using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.MonoGame.Board;
using Microsoft.Xna.Framework.Graphics;

namespace Chess.MonoGame.Factories
{
    public class BasicTileFactory : TileFactory
    {
        public override Tile GetTile(int row, int column, TileColor tileColor, Texture2D texture)
        {
            return new BasicTile(row, column, tileColor, texture);
        }
    }
}
