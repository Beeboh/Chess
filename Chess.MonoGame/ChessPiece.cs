using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Chess.MonoGame
{
    public abstract class ChessPiece
    {
        public ChessPiece(Alliance alliance, Texture2D texture)
        {
            SetPosition(0, 0);
            Texture = texture;
        }
        public ChessPiece(Alliance alliance, Texture2D texture, int row, int column)
        {
            SetPosition(row, column);
            Texture = texture;
        }
        public int Column { get; private set; }
        public int Row { get; private set; }
        public void SetPosition(int row, int column)
        {
            Row = row;
            Column = column;
        }
        public Texture2D Texture { get; }
        

    }
}
