using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame.Board
{
    public class BasicTile : Tile
    {
        public BasicTile(int row, int column, TileColor tileColor, Texture2D texture) : base(row, column, tileColor, texture)
        {
            
        }

        public override Tile GetCopy()
        {
            return new BasicTile(Row, Column, tileColor, Texture);
        }
        protected override void OnPieceMoved()
        {
            
        }
    }
}
