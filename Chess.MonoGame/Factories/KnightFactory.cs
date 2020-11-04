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
    public class KnightFactory : ChessPieceFactory
    {
        public override ChessPiece GetPiece(Alliance alliance, Texture2D texture)
        {
            IPieceBehaviour UpLeftMovement = new BasicMovementBehaviour(-1, -2, 1);
            IPieceBehaviour UpRightMovement = new BasicMovementBehaviour(1, -2, 1);
            IPieceBehaviour RightUpMovement = new BasicMovementBehaviour(2, -1, 1);
            IPieceBehaviour RightDownMovement = new BasicMovementBehaviour(2, 1, 1);
            IPieceBehaviour DownRightMovement = new BasicMovementBehaviour(1, 2, 1);
            IPieceBehaviour DownLeftMovement = new BasicMovementBehaviour(-1, 2, 1);
            IPieceBehaviour LeftDownMovement = new BasicMovementBehaviour(-2, 1, 1);
            IPieceBehaviour LeftUpMovement = new BasicMovementBehaviour(-2, -1, 1);
            IPieceBehaviour UpLeftCapture = new BasicCaptureBehaviour(-1, -2, 1);
            IPieceBehaviour UpRightCapture = new BasicCaptureBehaviour(1, -2, 1);
            IPieceBehaviour RightUpCapture = new BasicCaptureBehaviour(2, -1, 1);
            IPieceBehaviour RightDownCapture = new BasicCaptureBehaviour(2, 1, 1);
            IPieceBehaviour DownRightCapture = new BasicCaptureBehaviour(1, 2, 1);
            IPieceBehaviour DownLeftCapture = new BasicCaptureBehaviour(-1, 2, 1);
            IPieceBehaviour LeftDownCapture = new BasicCaptureBehaviour(-2, 1, 1);
            IPieceBehaviour LeftUpCapture = new BasicCaptureBehaviour(-2, -1, 1);
            IPieceBehaviour[] pieceBehaviours = new IPieceBehaviour[] { UpLeftMovement, UpRightMovement, RightUpMovement, RightDownMovement, DownRightMovement, DownLeftMovement, LeftDownMovement, LeftUpMovement,
                                                      UpLeftCapture, UpRightCapture, RightUpCapture, RightDownCapture, DownRightCapture, DownLeftCapture, LeftDownCapture, LeftUpCapture};

            return new Knight(alliance, texture, pieceBehaviours, false);
        }
    }
}
