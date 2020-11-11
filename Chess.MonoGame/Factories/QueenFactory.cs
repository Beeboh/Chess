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
    public class QueenFactory : ChessPieceFactory
    {
        public QueenFactory(Alliance alliance, Texture2D texture) : base(alliance, texture)
        {

        }
        public override ChessPiece GetPiece(int row, int column)
        {
            IPieceBehaviour UpMovement = new BasicMovementBehaviour(0, -1, 1000000);
            IPieceBehaviour RightMovement = new BasicMovementBehaviour(1, 0, 1000000);
            IPieceBehaviour DownMovement = new BasicMovementBehaviour(0, 1, 1000000);
            IPieceBehaviour LeftMovement = new BasicMovementBehaviour(-1, 0, 1000000);
            IPieceBehaviour UpRightMovement = new BasicMovementBehaviour(1, -1, 1000000);
            IPieceBehaviour DownRightMovement = new BasicMovementBehaviour(1, 1, 1000000);
            IPieceBehaviour DownLeftMovement = new BasicMovementBehaviour(-1, 1, 1000000);
            IPieceBehaviour UpLeftMovement = new BasicMovementBehaviour(-1, -1, 1000000);
            IPieceBehaviour UpCapture = new BasicCaptureBehaviour(0, -1, 1000000);
            IPieceBehaviour RightCapture = new BasicCaptureBehaviour(1, 0, 1000000);
            IPieceBehaviour DownCapture = new BasicCaptureBehaviour(0, 1, 1000000);
            IPieceBehaviour LeftCapture = new BasicCaptureBehaviour(-1, 0, 1000000);
            IPieceBehaviour UpRightCapture = new BasicCaptureBehaviour(1, -1, 1000000);
            IPieceBehaviour DownRightCapture = new BasicCaptureBehaviour(1, 1, 1000000);
            IPieceBehaviour DownLeftCapture = new BasicCaptureBehaviour(-1, 1, 1000000);
            IPieceBehaviour UpLeftCapture = new BasicCaptureBehaviour(-1, -1, 1000000);

            IPieceBehaviour[] pieceBehaviours = new IPieceBehaviour[] {UpMovement, RightMovement, DownMovement, LeftMovement, UpRightMovement, DownRightMovement, DownLeftMovement, UpLeftMovement,
                                                                        UpCapture, RightCapture, DownCapture, LeftCapture, UpRightCapture, DownRightCapture, DownLeftCapture, UpLeftCapture};

            return new Queen(Alliance, Texture, pieceBehaviours, row, column, false, 9, this);
        }
    }
}
