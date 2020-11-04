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
    public class BishopFactory : ChessPieceFactory
    {
        public override ChessPiece GetPiece(Alliance alliance, Texture2D texture)
        {
            IPieceBehaviour UpLeftMovement = new BasicMovementBehaviour(-1, -1, 1000000);
            IPieceBehaviour UpRightMovement = new BasicMovementBehaviour(1, -1, 1000000);
            IPieceBehaviour DownLeftMovement = new BasicMovementBehaviour(-1, 1, 1000000);
            IPieceBehaviour DownRightMovement = new BasicMovementBehaviour(1, 1, 1000000);
            IPieceBehaviour UpLeftCapture = new BasicCaptureBehaviour(-1, -1, 1000000);
            IPieceBehaviour UpRightCapture = new BasicCaptureBehaviour(1, -1, 1000000);
            IPieceBehaviour DownLeftCapture = new BasicCaptureBehaviour(-1, 1, 1000000);
            IPieceBehaviour DownRightCapture = new BasicCaptureBehaviour(1, 1, 1000000);
            IPieceBehaviour[] pieceBehaviours = new IPieceBehaviour[] { UpLeftMovement, UpRightMovement, DownLeftMovement, DownRightMovement, UpLeftCapture, UpRightCapture, DownLeftCapture, DownRightCapture };

            return new Bishop(alliance, texture, pieceBehaviours, false);
        }
    }
}
