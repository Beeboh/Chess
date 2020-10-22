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
            IPieceBehaviour UpLeftMovement = new MovementBehaviour(-1, -1, 1000000);
            IPieceBehaviour UpRightMovement = new MovementBehaviour(1, -1, 1000000);
            IPieceBehaviour DownLeftMovement = new MovementBehaviour(-1, 1, 1000000);
            IPieceBehaviour DownRightMovement = new MovementBehaviour(1, 1, 1000000);
            IPieceBehaviour UpLeftCapture = new CaptureBehaviour(-1, -1, 1000000, alliance);
            IPieceBehaviour UpRightCapture = new CaptureBehaviour(1, -1, 1000000, alliance);
            IPieceBehaviour DownLeftCapture = new CaptureBehaviour(-1, 1, 1000000, alliance);
            IPieceBehaviour DownRightCapture = new CaptureBehaviour(1, 1, 1000000, alliance);
            IPieceBehaviour[] pieceBehaviours = new IPieceBehaviour[] { UpLeftMovement, UpRightMovement, DownLeftMovement, DownRightMovement, UpLeftCapture, UpRightCapture, DownLeftCapture, DownRightCapture };

            return new Bishop(alliance, texture, pieceBehaviours);
        }
    }
}
