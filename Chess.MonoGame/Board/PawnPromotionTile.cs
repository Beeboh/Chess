using Chess.MonoGame.Factories;
using Chess.MonoGame.Pieces;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame.Board
{
    public class PawnPromotionTile : Tile
    {
        public PawnPromotionTile(int row, int column, TileColor tileColor, Texture2D texture, IEnumerable<Alliance> alliancesToPromote, ChessPieceFactory promotionFactory) : base(row, column, tileColor, texture)
        {
            AlliancesToPromote = new List<Alliance>(alliancesToPromote).AsReadOnly();
            PromotionFactory = promotionFactory;
        }
        private ChessPieceFactory PromotionFactory { get; }
        private ReadOnlyCollection<Alliance> AlliancesToPromote { get; }

        public override Tile GetCopy()
        {
            return new PawnPromotionTile(Row, Column, tileColor, Texture, AlliancesToPromote, PromotionFactory);
        }

        protected override void OnPieceMoved()
        {
            if(Piece is Pawn)
            {
                if (AlliancesToPromote.Contains(Piece.Alliance))
                {
                    ChessPiece NewPiece = PromotionFactory.GetPiece(Row, Column);
                    Piece = NewPiece;
                }
            }
            
        }
    }
}
