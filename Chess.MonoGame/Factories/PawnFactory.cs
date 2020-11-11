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
        public PawnFactory(Alliance alliance, Texture2D texture) : base(alliance, texture)
        {

        }
        public override ChessPiece GetPiece(int row, int column)
        {
            int Ydirection;
            if (Alliance == Alliance.White)
            {
                Ydirection = -1;
            }
            else
            {
                Ydirection = 1;
            }
            IPieceBehaviour forwardMovement = new BasicMovementBehaviour(0, Ydirection, 1);
            IPieceBehaviour diagonalLeftCapture = new BasicCaptureBehaviour(-1, Ydirection, 1);
            IPieceBehaviour diagonalRightCapture = new BasicCaptureBehaviour(1, Ydirection, 1);
            IPieceBehaviour startingDoubleMove = new StartingMovementBehaviour(0, Ydirection * 2, 1);
            IPieceBehaviour diagonalLeftEnPassant = new EnpassantBehaviour(-1, Ydirection, -1, 0);
            IPieceBehaviour diagonalRightEnPassant = new EnpassantBehaviour(1, Ydirection, 1, 0);
            IPieceBehaviour[] pieceBehaviours = new IPieceBehaviour[] { forwardMovement, diagonalLeftCapture, diagonalRightCapture, startingDoubleMove, diagonalLeftEnPassant, diagonalRightEnPassant };
            return new Pawn(Alliance, Texture, pieceBehaviours, row, column, false, false, 1, this);
        }
    }
}
