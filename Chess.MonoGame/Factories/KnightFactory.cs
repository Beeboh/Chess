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
            IPieceBehaviour UpLeftMovement = new MovementBehaviour(-1, -2, 1);
            IPieceBehaviour UpRightMovement = new MovementBehaviour(1, -2, 1);
            IPieceBehaviour RightUpMovement = new MovementBehaviour(2, -1, 1);
            IPieceBehaviour RightDownMovement = new MovementBehaviour(2, 1, 1);
            IPieceBehaviour DownRightMovement = new MovementBehaviour(1, 2, 1);
            IPieceBehaviour DownLeftMovement = new MovementBehaviour(-1, 2, 1);
            IPieceBehaviour LeftDownMovement = new MovementBehaviour(-2, 1, 1);
            IPieceBehaviour LeftUpMovement = new MovementBehaviour(-2, -1, 1);
            IPieceBehaviour UpLeftCapture = new CaptureBehaviour(-1, -2, 1, alliance);
            IPieceBehaviour UpRightCapture = new CaptureBehaviour(1, -2, 1, alliance);
            IPieceBehaviour RightUpCapture = new CaptureBehaviour(2, -1, 1, alliance);
            IPieceBehaviour RightDownCapture = new CaptureBehaviour(2, 1, 1, alliance);
            IPieceBehaviour DownRightCapture = new CaptureBehaviour(1, 2, 1, alliance);
            IPieceBehaviour DownLeftCapture = new CaptureBehaviour(-1, 2, 1, alliance);
            IPieceBehaviour LeftDownCapture = new CaptureBehaviour(-2, 1, 1, alliance);
            IPieceBehaviour LeftUpCapture = new CaptureBehaviour(-2, -1, 1, alliance);
            IPieceBehaviour[] pieceBehaviours = new IPieceBehaviour[] { UpLeftMovement, UpRightMovement, RightUpMovement, RightDownMovement, DownRightMovement, DownLeftMovement, LeftDownMovement, LeftUpMovement,
                                                      UpLeftCapture, UpRightCapture, RightUpCapture, RightDownCapture, DownRightCapture, DownLeftCapture, LeftDownCapture, LeftUpCapture};

            return new Knight(alliance, texture, pieceBehaviours);
        }
    }
}
