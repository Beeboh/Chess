using Chess.MonoGame.Behaviours;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame.Pieces
{
    public class Bishop : ChessPiece
    {
        public Bishop(Alliance alliance, Texture2D texture, IEnumerable<IPieceBehaviour> pieceBehaviours, bool hasMoved) : base(alliance, texture, pieceBehaviours, hasMoved)
        {

        }
        public Bishop(Alliance alliance, Texture2D texture, IEnumerable<IPieceBehaviour> pieceBehaviours, int row, int column, bool hasMoved) : base(alliance, texture, pieceBehaviours, row, column, hasMoved)
        {

        }

        public override ChessPiece GetCopy()
        {
            return new Bishop(Alliance, Texture, PieceBehaviours, Row, Column, HasMoved);
        }
    }
}
