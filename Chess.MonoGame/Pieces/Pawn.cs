using Chess.MonoGame.Behaviours;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame.Pieces
{
    public class Pawn : ChessPiece, IEnPassantable
    {
        public Pawn(Alliance alliance, Texture2D texture, IEnumerable<IPieceBehaviour> pieceBehaviours, bool currentlyenpassantable, bool hasMoved) : base(alliance, texture, pieceBehaviours,  hasMoved)
        {
            CurrentlyEnPassantable = currentlyenpassantable;
        }
        public Pawn(Alliance alliance, Texture2D texture, IEnumerable<IPieceBehaviour> pieceBehaviours, int row, int column, bool currentlyenpassantable, bool hasMoved) : base(alliance, texture, pieceBehaviours, row, column, hasMoved)
        {
            CurrentlyEnPassantable = currentlyenpassantable;
        }

        public bool CurrentlyEnPassantable { get; set; }

        public override ChessPiece GetCopy()
        {
            return new Pawn(Alliance, Texture, PieceBehaviours, Row, Column, CurrentlyEnPassantable, HasMoved);
        }
    }
}
