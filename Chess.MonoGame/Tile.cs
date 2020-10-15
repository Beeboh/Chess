using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame
{
    public class Tile
    {
        public Tile(int column, int row, TileColor color, Texture2D texture)
        {
            Column = column;
            Row = row;
            Color = color;
            Texture = texture;
        }
        public int Column { get; }
        public int Row { get; }
        public ChessPiece Piece { get; private set; }
        public TileColor Color { get; }
        public Texture2D Texture { get; }
        public bool IsVacant => Piece == null;
        public void AttachPiece(ChessPiece piece)
        {
            Piece = piece;
            Piece.SetPosition(Column, Row);
        }
        public void DetachPiece()
        {
            Piece = null;
        }
    }
}
