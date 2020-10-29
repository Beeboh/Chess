using Chess.MonoGame.Behaviours;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame.Pieces
{
    public class Knight : ChessPiece
    {
        public Knight(Alliance alliance, Texture2D texture, IEnumerable<IPieceBehaviour> pieceBehaviours) : base(alliance, texture, pieceBehaviours)
        {

        }
        public Knight(Alliance alliance, Texture2D texture, IEnumerable<IPieceBehaviour> pieceBehaviours, int row, int column) : base(alliance, texture, pieceBehaviours, row, column)
        {

        }

        public override ChessPiece GetCopy()
        {
            return new Knight(Alliance, Texture, PieceBehaviours, Row, Column);
        }
    }
}
