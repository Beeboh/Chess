using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.MonoGame.Board;
using Microsoft.Xna.Framework.Graphics;

namespace Chess.MonoGame.Factories
{
    public class PawnPromotionTileFactory : TileFactory
    {
        public PawnPromotionTileFactory(Alliance alliancetopromote, ChessPieceFactory promotionFactory)
        {
            AllianceToPromote = alliancetopromote;
            PromotionFactory = promotionFactory;
        }
        private ChessPieceFactory PromotionFactory { get; }
        private Alliance AllianceToPromote { get; }
        public override Tile GetTile(int row, int column, TileColor tileColor, Texture2D texture)
        {
            return new PawnPromotionTile(row, column, tileColor, texture, new List<Alliance>() { AllianceToPromote }, PromotionFactory);
        }
    }
}
