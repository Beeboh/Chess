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
        public override ChessPiece GetPiece(Alliance alliance, Texture2D texture)
        {
            IPieceBehaviour UpMovement = new MovementBehaviour(0, -1, 1000000);
            IPieceBehaviour RightMovement = new MovementBehaviour(1, 0, 1000000);
            IPieceBehaviour DownMovement = new MovementBehaviour(0, 1, 1000000);
            IPieceBehaviour LeftMovement = new MovementBehaviour(-1, 0, 1000000);
            IPieceBehaviour UpCapture = new CaptureBehaviour(0, -1, 1000000, alliance);
            IPieceBehaviour RightCapture = new CaptureBehaviour(1, 0, 1000000, alliance);
            IPieceBehaviour DownCapture = new CaptureBehaviour(0, 1, 1000000, alliance);
            IPieceBehaviour LeftCapture = new CaptureBehaviour(-1, 0, 1000000, alliance);

            IPieceBehaviour[] pieceBehaviours = new IPieceBehaviour[] { UpMovement, RightMovement, DownMovement, LeftMovement, UpCapture, RightCapture, DownCapture, LeftCapture };
            return new Rook(alliance, texture, pieceBehaviours);
        }
    }
}
