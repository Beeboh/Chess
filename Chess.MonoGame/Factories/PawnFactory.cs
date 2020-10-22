using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.MonoGame.Behaviours;
using Chess.MonoGame.Pieces;
using Microsoft.Xna.Framework.Graphics;

namespace Chess.MonoGame.Factories
{
    public class PawnFactory : ChessPieceFactory
    {
        public override ChessPiece GetPiece(Alliance alliance, Texture2D texture)
        {
            int Ydirection;
            if (alliance == Alliance.White)
            {
                Ydirection = -1;
            }
            else
            {
                Ydirection = 1;
            }
            IPieceBehaviour forwardMovement = new MovementBehaviour(0, Ydirection, 1);
            IPieceBehaviour diagonalLeftCapture = new CaptureBehaviour(-1, Ydirection, 1, alliance);
            IPieceBehaviour diagonalRightCapture = new CaptureBehaviour(1, Ydirection, 1, alliance);
            IPieceBehaviour[] pieceBehaviours = new IPieceBehaviour[] { forwardMovement, diagonalLeftCapture, diagonalRightCapture };
            return new Pawn(alliance, texture, pieceBehaviours);
        }
    }
}
