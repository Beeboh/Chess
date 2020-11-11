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
    public class RookFactory : ChessPieceFactory
    {
        public RookFactory(Alliance alliance, Texture2D texture) : base(alliance, texture)
        {

        }
        public override ChessPiece GetPiece(int row, int column)
        {
            IPieceBehaviour UpMovement = new BasicMovementBehaviour(0, -1, 1000000);
            IPieceBehaviour RightMovement = new BasicMovementBehaviour(1, 0, 1000000);
            IPieceBehaviour DownMovement = new BasicMovementBehaviour(0, 1, 1000000);
            IPieceBehaviour LeftMovement = new BasicMovementBehaviour(-1, 0, 1000000);
            IPieceBehaviour UpCapture = new BasicCaptureBehaviour(0, -1, 1000000);
            IPieceBehaviour RightCapture = new BasicCaptureBehaviour(1, 0, 1000000);
            IPieceBehaviour DownCapture = new BasicCaptureBehaviour(0, 1, 1000000);
            IPieceBehaviour LeftCapture = new BasicCaptureBehaviour(-1, 0, 1000000);

            IPieceBehaviour[] pieceBehaviours = new IPieceBehaviour[] { UpMovement, RightMovement, DownMovement, LeftMovement, UpCapture, RightCapture, DownCapture, LeftCapture };
            return new Rook(Alliance, Texture, pieceBehaviours, row, column, false, 5, this);
        }
    }
}
