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
        public KingFactory(Alliance alliance, Texture2D texture) : base(alliance, texture)
        {

        }
        public override ChessPiece GetPiece(int row, int column)
        {
            IPieceBehaviour UpMovement = new BasicMovementBehaviour(0, -1, 1);
            IPieceBehaviour RightMovement = new BasicMovementBehaviour(1, 0, 1);
            IPieceBehaviour DownMovement = new BasicMovementBehaviour(0, 1, 1);
            IPieceBehaviour LeftMovement = new BasicMovementBehaviour(-1, 0, 1);
            IPieceBehaviour UpRightMovement = new BasicMovementBehaviour(1, -1, 1);
            IPieceBehaviour DownRightMovement = new BasicMovementBehaviour(1, 1, 1);
            IPieceBehaviour DownLeftMovement = new BasicMovementBehaviour(-1, 1, 1);
            IPieceBehaviour UpLeftMovement = new BasicMovementBehaviour(-1, -1, 1);
            IPieceBehaviour UpCapture = new BasicCaptureBehaviour(0, -1, 1);
            IPieceBehaviour RightCapture = new BasicCaptureBehaviour(1, 0, 1);
            IPieceBehaviour DownCapture = new BasicCaptureBehaviour(0, 1, 1);
            IPieceBehaviour LeftCapture = new BasicCaptureBehaviour(-1, 0, 1);
            IPieceBehaviour UpRightCapture = new BasicCaptureBehaviour(1, -1, 1);
            IPieceBehaviour DownRightCapture = new BasicCaptureBehaviour(1, 1, 1);
            IPieceBehaviour DownLeftCapture = new BasicCaptureBehaviour(-1, 1, 1);
            IPieceBehaviour UpLeftCapture = new BasicCaptureBehaviour(-1, -1, 1);
            IPieceBehaviour ShortCastle = new CastleBehaviour(2, 0, 1, 0, 3, -2, 0);
            IPieceBehaviour LongCastle = new CastleBehaviour(-2, 0, -1, 0, 4, 3, 0);

            IPieceBehaviour[] pieceBehaviours = new IPieceBehaviour[] {UpMovement, RightMovement, DownMovement, LeftMovement, UpRightMovement, DownRightMovement, DownLeftMovement, UpLeftMovement,
                                                                        UpCapture, RightCapture, DownCapture, LeftCapture, UpRightCapture, DownRightCapture, DownLeftCapture, UpLeftCapture, ShortCastle, LongCastle};
            return new King(Alliance, Texture, pieceBehaviours, row, column, false, 0, this);
        }
    }
}
