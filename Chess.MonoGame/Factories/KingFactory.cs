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
    public class KingFactory : ChessPieceFactory
    {
        public override ChessPiece GetPiece(Alliance alliance, Texture2D texture)
        {
            IPieceBehaviour UpMovement = new MovementBehaviour(0, -1, 1);
            IPieceBehaviour RightMovement = new MovementBehaviour(1, 0, 1);
            IPieceBehaviour DownMovement = new MovementBehaviour(0, 1, 1);
            IPieceBehaviour LeftMovement = new MovementBehaviour(-1, 0, 1);
            IPieceBehaviour UpRightMovement = new MovementBehaviour(1, -1, 1);
            IPieceBehaviour DownRightMovement = new MovementBehaviour(1, 1, 1);
            IPieceBehaviour DownLeftMovement = new MovementBehaviour(-1, 1, 1);
            IPieceBehaviour UpLeftMovement = new MovementBehaviour(-1, -1, 1);
            IPieceBehaviour UpCapture = new CaptureBehaviour(0, -1, 1, alliance);
            IPieceBehaviour RightCapture = new CaptureBehaviour(1, 0, 1, alliance);
            IPieceBehaviour DownCapture = new CaptureBehaviour(0, 1, 1, alliance);
            IPieceBehaviour LeftCapture = new CaptureBehaviour(-1, 0, 1, alliance);
            IPieceBehaviour UpRightCapture = new CaptureBehaviour(1, -1, 1, alliance);
            IPieceBehaviour DownRightCapture = new CaptureBehaviour(1, 1, 1, alliance);
            IPieceBehaviour DownLeftCapture = new CaptureBehaviour(-1, 1, 1, alliance);
            IPieceBehaviour UpLeftCapture = new CaptureBehaviour(-1, -1, 1, alliance);

            IPieceBehaviour[] pieceBehaviours = new IPieceBehaviour[] {UpMovement, RightMovement, DownMovement, LeftMovement, UpRightMovement, DownRightMovement, DownLeftMovement, UpLeftMovement,
                                                                        UpCapture, RightCapture, DownCapture, LeftCapture, UpRightCapture, DownRightCapture, DownLeftCapture, UpLeftCapture};
            return new King(alliance, texture, pieceBehaviours);
        }
    }
}
