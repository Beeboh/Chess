using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.MonoGame.Pieces;
using Microsoft.Xna.Framework;

namespace Chess.MonoGame.Board
{
    public abstract class BoardState
    {
        public BoardState(IEnumerable<Tile> tiles)
        {
            Tiles = tiles.ToList().AsReadOnly();
            Width = Tiles.GroupBy(tile => tile.Column).Select(group => group.First()).ToList().Count;
            Height = Tiles.GroupBy(tile => tile.Row).Select(group => group.First()).ToList().Count;
        }
        public int Width { get; } //in tiles
        public int Height { get; } //in tiles
        public ReadOnlyCollection<Tile> Tiles { get; }
        public Tile this[int row, int column]
        {
            get
            {
                return Tiles.Where(tile => tile.Row == row && tile.Column == column).ToList().First();
            }
        }
        public bool ValidTile(int row, int column)
        {
            bool ValidRow = row >= 0 && row < Height;
            bool ValidColumn = column >= 0 && column < Width;
            return ValidRow && ValidColumn;
        }
        protected ReadOnlyCollection<Tile> GetCopyOfTiles()
        {
            List<Tile> CopiedTiles = new List<Tile>();
            foreach(Tile tile in Tiles)
            {
                Tile CopiedTile = new Tile(tile.Column, tile.Row, tile.tileColor, tile.Texture);
                if (!tile.IsVacant)
                {
                    ChessPiece CopiedPiece = tile.Piece.GetCopy();
                    CopiedTile.AttachPiece(CopiedPiece);
                }
                CopiedTiles.Add(CopiedTile);
            }
            return CopiedTiles.AsReadOnly();
        }
        public abstract BoardState GetCopy();

    }
    public class StandardBoardState : BoardState
    {
        public StandardBoardState(IEnumerable<Tile> tiles) : base(tiles)
        {
           
        }

        public override BoardState GetCopy()
        {
            ReadOnlyCollection<Tile> CopiedTiles = GetCopyOfTiles();
            return new StandardBoardState(CopiedTiles);
        }
    }
}
