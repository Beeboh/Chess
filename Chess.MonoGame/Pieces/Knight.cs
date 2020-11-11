using Chess.MonoGame.Behaviours;
using Chess.MonoGame.Factories;
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
        public Knight(Alliance alliance, Texture2D texture, IEnumerable<IPieceBehaviour> pieceBehaviours, bool hasMoved, int materialValue, ChessPieceFactory factory) : base(alliance, texture, pieceBehaviours, hasMoved, materialValue, factory)
        {

        }
        public Knight(Alliance alliance, Texture2D texture, IEnumerable<IPieceBehaviour> pieceBehaviours, int row, int column, bool hasMoved, int materialValue, ChessPieceFactory factory) : base(alliance, texture, pieceBehaviours, row, column, hasMoved, materialValue, factory)
        {

        }

    }
}
