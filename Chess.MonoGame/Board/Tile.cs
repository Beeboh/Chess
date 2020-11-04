using Chess.MonoGame.Pieces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame.Board
{
    public class Tile
    {
        public Tile(int column, int row, TileColor tilecolor, Texture2D texture)
        {
            Column = column;
            Row = row;
            tileColor = tilecolor;
            Texture = texture;
            Tint = Color.White;
        }
        public int Column { get; }
        public int Row { get; }
        public ChessPiece Piece { get; private set; }
        public TileColor tileColor { get; }
        public Texture2D Texture { get; }
        public bool IsVacant => Piece == null;
        public void AttachPiece(ChessPiece piece)
        {
            Piece = piece;
            Piece.SetPoition(Row, Column);
        }
        public void AttachPiece(ChessPiece piece, bool HasMoved)
        {
            Piece = piece;
            if (HasMoved)
            {
                Piece.MovePosition(Row, Column);
            }
            else
            {
                Piece.InitializePosition(Row, Column);
            }
        }
        public void DetachPiece()
        {
            Piece = null;
        }
        public Color Tint { get; private set; }
        public void SetTint(Color color)
        {
            Tint = color;
        }
    }
}
