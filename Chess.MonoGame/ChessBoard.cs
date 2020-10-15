using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Chess.MonoGame
{
    public abstract class ChessBoard
    {
        public ChessBoard(Point origin, BoardTexturePack boardtextures, PieceTexturePack piecetextures)
        {
            Origin = origin;
        }
        public Point Origin { get; }
        public abstract int Width { get; } //in tiles
        public abstract int Height { get; } //in tiles
        public abstract int TileWidth { get; } //in pixels
        public abstract int TileHeight { get; } //in pixels
        public ReadOnlyCollection<Tile> Tiles { get; protected set; }
        public Tile this[int row, int column]
        {
            get
            {
                return Tiles.Where(tile => tile.Row == row && tile.Column == column).ToList().First();
            }
        }
        public void AddPiece(ChessPiece piece, int row, int column)
        {
            this[row, column].AttachPiece(piece);
        }
        public bool ValidTile(int row, int column)
        {
            bool ValidRow = row >= 0 && row < Height;
            bool ValidColumn = column >= 0 && column < Width;
            return ValidRow && ValidColumn;
        }

    }
    public class StandardBoard : ChessBoard
    {
        public StandardBoard(Point origin, BoardTexturePack boardtextures, PieceTexturePack piecetextures) : base(origin, boardtextures, piecetextures)
        {
            List<Tile> tiles = new List<Tile>();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if ((i + j) % 2 == 0) 
                    {
                        tiles.Add(new Tile(i, j, TileColor.LightSquare, boardtextures.LightSquare));
                    }
                    else
                    {
                        tiles.Add(new Tile(i, j, TileColor.DarkSquare, boardtextures.DarkSquare));
                    }
                }
            }
            Tiles = tiles.AsReadOnly();

            Pawn aPawn_white = new Pawn(Alliance.White, piecetextures.WhitePawn);
            Pawn bPawn_white = new Pawn(Alliance.White, piecetextures.WhitePawn);
            Pawn cPawn_white = new Pawn(Alliance.White, piecetextures.WhitePawn);
            Pawn dPawn_white = new Pawn(Alliance.White, piecetextures.WhitePawn);
            Pawn ePawn_white = new Pawn(Alliance.White, piecetextures.WhitePawn);
            Pawn fPawn_white = new Pawn(Alliance.White, piecetextures.WhitePawn);
            Pawn gPawn_white = new Pawn(Alliance.White, piecetextures.WhitePawn);
            Pawn hPawn_white = new Pawn(Alliance.White, piecetextures.WhitePawn);
            Knight bKnight_white = new Knight(Alliance.White, piecetextures.WhiteKnight);
            Knight gKnight_white = new Knight(Alliance.White, piecetextures.WhiteKnight);
            Bishop cBishop_white = new Bishop(Alliance.White, piecetextures.WhiteBishop);
            Bishop fBishop_white = new Bishop(Alliance.White, piecetextures.WhiteBishop);
            Rook aRook_white = new Rook(Alliance.White, piecetextures.WhiteRook);
            Rook hRook_white = new Rook(Alliance.White, piecetextures.WhiteRook);
            Queen queen_white = new Queen(Alliance.White, piecetextures.WhiteQueen);
            King king_white = new King(Alliance.White, piecetextures.WhiteKing);

            Pawn aPawn_black = new Pawn(Alliance.Black, piecetextures.BlackPawn);
            Pawn bPawn_black = new Pawn(Alliance.Black, piecetextures.BlackPawn);
            Pawn cPawn_black = new Pawn(Alliance.Black, piecetextures.BlackPawn);
            Pawn dPawn_black = new Pawn(Alliance.Black, piecetextures.BlackPawn);
            Pawn ePawn_black = new Pawn(Alliance.Black, piecetextures.BlackPawn);
            Pawn fPawn_black = new Pawn(Alliance.Black, piecetextures.BlackPawn);
            Pawn gPawn_black = new Pawn(Alliance.Black, piecetextures.BlackPawn);
            Pawn hPawn_black = new Pawn(Alliance.Black, piecetextures.BlackPawn);
            Knight bKnight_black = new Knight(Alliance.Black, piecetextures.BlackKnight);
            Knight gKnight_black = new Knight(Alliance.Black, piecetextures.BlackKnight);
            Bishop cBishop_black = new Bishop(Alliance.Black, piecetextures.BlackBishop);
            Bishop fBishop_black = new Bishop(Alliance.Black, piecetextures.BlackBishop);
            Rook aRook_black = new Rook(Alliance.Black, piecetextures.BlackRook);
            Rook hRook_black = new Rook(Alliance.Black, piecetextures.BlackRook);
            Queen queen_black = new Queen(Alliance.Black, piecetextures.BlackQueen);
            King king_black = new King(Alliance.Black, piecetextures.BlackKing);

            this[0, 0].AttachPiece(aRook_black);
            this[0, 1].AttachPiece(bKnight_black);
            this[0, 2].AttachPiece(cBishop_black);
            this[0, 3].AttachPiece(queen_black);
            this[0, 4].AttachPiece(king_black);
            this[0, 5].AttachPiece(fBishop_black);
            this[0, 6].AttachPiece(gKnight_black);
            this[0, 7].AttachPiece(hRook_black);

            this[1, 0].AttachPiece(aPawn_black);
            this[1, 1].AttachPiece(bPawn_black);
            this[1, 2].AttachPiece(cPawn_black);
            this[1, 3].AttachPiece(dPawn_black);
            this[1, 4].AttachPiece(ePawn_black);
            this[1, 5].AttachPiece(fPawn_black);
            this[1, 6].AttachPiece(gPawn_black);
            this[1, 7].AttachPiece(hPawn_black);

            this[6, 0].AttachPiece(aPawn_white);
            this[6, 1].AttachPiece(bPawn_white);
            this[6, 2].AttachPiece(cPawn_white);
            this[6, 3].AttachPiece(dPawn_white);
            this[6, 4].AttachPiece(ePawn_white);
            this[6, 5].AttachPiece(fPawn_white);
            this[6, 6].AttachPiece(gPawn_white);
            this[6, 7].AttachPiece(hPawn_white);

            this[7, 0].AttachPiece(aRook_white);
            this[7, 1].AttachPiece(bKnight_white);
            this[7, 2].AttachPiece(cBishop_white);
            this[7, 3].AttachPiece(queen_white);
            this[7, 4].AttachPiece(king_white);
            this[7, 5].AttachPiece(fBishop_white);
            this[7, 6].AttachPiece(gKnight_white);
            this[7, 7].AttachPiece(hRook_white);
        }
        public override int Width => 8;
        public override int Height => 8;
        public override int TileWidth => 100;
        public override int TileHeight => 100;
    }
    //public class CustomBoard : ChessBoard
    //{
    //    public CustomBoard(int width, int height, int tilewidth, int tileheight)
    //    {
    //        Width = width;
    //        Height = height;
    //        TileWidth = tilewidth;
    //        TileHeight = tileheight;
    //    }

    //    public override int Width { get; }
    //    public override int Height { get; }
    //    public override int TileWidth { get; }
    //    public override int TileHeight { get; }
    //}
}
