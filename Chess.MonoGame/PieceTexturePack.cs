using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;


namespace Chess.MonoGame
{
    public class PieceTexturePack
    {
        public PieceTexturePack(Texture2D white_pawn, Texture2D white_knight, 
            Texture2D white_bishop, Texture2D white_rook, Texture2D white_queen, Texture2D white_king,
            Texture2D black_pawn, Texture2D black_knight, Texture2D black_bishop, Texture2D black_rook, 
            Texture2D black_queen, Texture2D black_king)
        {
            WhitePawn = white_pawn;
            WhiteKnight = white_knight;
            WhiteBishop = white_bishop;
            WhiteRook = white_rook;
            WhiteQueen = white_queen;
            WhiteKing = white_king;

            BlackPawn = black_pawn;
            BlackKnight = black_knight;
            BlackBishop = black_bishop;
            BlackRook = black_rook;
            BlackQueen = black_queen;
            BlackKing = black_king;
        }
        public Texture2D WhitePawn { get; }
        public Texture2D WhiteKnight { get; }
        public Texture2D WhiteBishop { get; }
        public Texture2D WhiteRook { get; }
        public Texture2D WhiteQueen { get; }
        public Texture2D WhiteKing { get; }

        public Texture2D BlackPawn { get; }
        public Texture2D BlackKnight { get; }
        public Texture2D BlackBishop { get; }
        public Texture2D BlackRook { get; }
        public Texture2D BlackQueen { get; }
        public Texture2D BlackKing { get; }
    }
}
