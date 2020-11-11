using Chess.MonoGame.Board;
using Chess.MonoGame.Factories;
using Chess.MonoGame.Pieces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame.Builders
{
    public class StandardBoardBuilder : ChessBoardBuilder
    {
        public StandardBoardBuilder(BoardTexturePack boardTextures, PieceTexturePack pieceTextures)
        {
            BoardTextures = boardTextures;
            PieceTextures = pieceTextures;
            WhitePawnFactory = new PawnFactory(Alliance.White, pieceTextures.WhitePawn);
            WhiteKnightFactory = new KnightFactory(Alliance.White, pieceTextures.WhiteKnight);
            WhiteBishopFactory = new BishopFactory(Alliance.White, pieceTextures.WhiteBishop);
            WhiteRookFactory = new RookFactory(Alliance.White, pieceTextures.WhiteRook);
            WhiteQueenFactory = new QueenFactory(Alliance.White, pieceTextures.WhiteQueen);
            WhiteKingFactory = new KingFactory(Alliance.White, pieceTextures.WhiteKing);
            BlackPawnFactory = new PawnFactory(Alliance.Black, pieceTextures.BlackPawn);
            BlackKnightFactory = new KnightFactory(Alliance.Black, pieceTextures.BlackKnight);
            BlackBishopFactory = new BishopFactory(Alliance.Black, pieceTextures.BlackBishop);
            BlackRookFactory = new RookFactory(Alliance.Black, pieceTextures.BlackRook);
            BlackQueenFactory = new QueenFactory(Alliance.Black, pieceTextures.BlackQueen);
            BlackKingFactory = new KingFactory(Alliance.Black, pieceTextures.BlackKing); 
            BasicTileFactory = new BasicTileFactory();
            WhitePawnPromotionTileFactory = new PawnPromotionTileFactory(Alliance.White, WhiteQueenFactory);
            BlackPawnPromotionTileFactory = new PawnPromotionTileFactory(Alliance.Black, BlackQueenFactory);
        }
        private BoardTexturePack BoardTextures { get; }
        private PieceTexturePack PieceTextures { get; }
        private ChessPieceFactory WhitePawnFactory { get; }
        private ChessPieceFactory WhiteKnightFactory { get; }
        private ChessPieceFactory WhiteBishopFactory { get; }
        private ChessPieceFactory WhiteRookFactory { get; }
        private ChessPieceFactory WhiteQueenFactory { get; }
        private ChessPieceFactory WhiteKingFactory { get; }
        private ChessPieceFactory BlackPawnFactory { get; }
        private ChessPieceFactory BlackKnightFactory { get; }
        private ChessPieceFactory BlackBishopFactory { get; }
        private ChessPieceFactory BlackRookFactory { get; }
        private ChessPieceFactory BlackQueenFactory { get; }
        private ChessPieceFactory BlackKingFactory { get; }

        private TileFactory BasicTileFactory { get; }
        private TileFactory WhitePawnPromotionTileFactory { get; }
        private TileFactory BlackPawnPromotionTileFactory { get; }
        public override void AddPieces()
        {
            ChessPiece aPawn_white = WhitePawnFactory.GetPiece();
            ChessPiece bPawn_white = WhitePawnFactory.GetPiece();
            ChessPiece cPawn_white = WhitePawnFactory.GetPiece();
            ChessPiece dPawn_white = WhitePawnFactory.GetPiece();
            ChessPiece ePawn_white = WhitePawnFactory.GetPiece();
            ChessPiece fPawn_white = WhitePawnFactory.GetPiece();
            ChessPiece gPawn_white = WhitePawnFactory.GetPiece();
            ChessPiece hPawn_white = WhitePawnFactory.GetPiece();
            ChessPiece bKnight_white = WhiteKnightFactory.GetPiece();
            ChessPiece gKnight_white = WhiteKnightFactory.GetPiece();
            ChessPiece cBishop_white = WhiteBishopFactory.GetPiece();
            ChessPiece fBishop_white = WhiteBishopFactory.GetPiece();
            ChessPiece aRook_white = WhiteRookFactory.GetPiece();
            ChessPiece hRook_white = WhiteRookFactory.GetPiece();
            ChessPiece queen_white = WhiteQueenFactory.GetPiece();
            ChessPiece king_white = WhiteKingFactory.GetPiece();

            ChessPiece aPawn_black = BlackPawnFactory.GetPiece();
            ChessPiece bPawn_black = BlackPawnFactory.GetPiece();
            ChessPiece cPawn_black = BlackPawnFactory.GetPiece();
            ChessPiece dPawn_black = BlackPawnFactory.GetPiece();
            ChessPiece ePawn_black = BlackPawnFactory.GetPiece();
            ChessPiece fPawn_black = BlackPawnFactory.GetPiece();
            ChessPiece gPawn_black = BlackPawnFactory.GetPiece();
            ChessPiece hPawn_black = BlackPawnFactory.GetPiece();
            ChessPiece bKnight_black = BlackKnightFactory.GetPiece();
            ChessPiece gKnight_black = BlackKnightFactory.GetPiece();
            ChessPiece cBishop_black = BlackBishopFactory.GetPiece();
            ChessPiece fBishop_black = BlackBishopFactory.GetPiece();
            ChessPiece aRook_black = BlackRookFactory.GetPiece();
            ChessPiece hRook_black = BlackRookFactory.GetPiece();
            ChessPiece queen_black = BlackQueenFactory.GetPiece();
            ChessPiece king_black = BlackKingFactory.GetPiece();

            Board.CurrentState[0, 0].AttachPiece(aRook_black, false);
            Board.CurrentState[0, 1].AttachPiece(bKnight_black, false);
            Board.CurrentState[0, 2].AttachPiece(cBishop_black, false);
            Board.CurrentState[0, 3].AttachPiece(queen_black, false);
            Board.CurrentState[0, 4].AttachPiece(king_black, false);
            Board.CurrentState[0, 5].AttachPiece(fBishop_black, false);
            Board.CurrentState[0, 6].AttachPiece(gKnight_black, false);
            Board.CurrentState[0, 7].AttachPiece(hRook_black, false);

            Board.CurrentState[1, 0].AttachPiece(aPawn_black, false);
            Board.CurrentState[1, 1].AttachPiece(bPawn_black, false);
            Board.CurrentState[1, 2].AttachPiece(cPawn_black, false);
            Board.CurrentState[1, 3].AttachPiece(dPawn_black, false);
            Board.CurrentState[1, 4].AttachPiece(ePawn_black, false);
            Board.CurrentState[1, 5].AttachPiece(fPawn_black, false);
            Board.CurrentState[1, 6].AttachPiece(gPawn_black, false);
            Board.CurrentState[1, 7].AttachPiece(hPawn_black, false);

            Board.CurrentState[6, 0].AttachPiece(aPawn_white, false);
            Board.CurrentState[6, 1].AttachPiece(bPawn_white, false);
            Board.CurrentState[6, 2].AttachPiece(cPawn_white, false);
            Board.CurrentState[6, 3].AttachPiece(dPawn_white, false);
            Board.CurrentState[6, 4].AttachPiece(ePawn_white, false);
            Board.CurrentState[6, 5].AttachPiece(fPawn_white, false);
            Board.CurrentState[6, 6].AttachPiece(gPawn_white, false);
            Board.CurrentState[6, 7].AttachPiece(hPawn_white, false);

            Board.CurrentState[7, 0].AttachPiece(aRook_white, false);
            Board.CurrentState[7, 1].AttachPiece(bKnight_white, false);
            Board.CurrentState[7, 2].AttachPiece(cBishop_white, false);
            Board.CurrentState[7, 3].AttachPiece(queen_white, false);
            Board.CurrentState[7, 4].AttachPiece(king_white, false);
            Board.CurrentState[7, 5].AttachPiece(fBishop_white, false);
            Board.CurrentState[7, 6].AttachPiece(gKnight_white, false);
            Board.CurrentState[7, 7].AttachPiece(hRook_white, false);
        }

        public override void CreateEmptyBoard(Point origin, int tileWidth, int tileHeight)
        {
            TileFactory tileFactory = BasicTileFactory;
            List<Tile> tiles = new List<Tile>();
            for (int row = 0; row < 8; row++)
            {
                if (row == 0)
                {
                    tileFactory = WhitePawnPromotionTileFactory;
                }
                else if(row == 7)
                {
                    tileFactory = BlackPawnPromotionTileFactory;
                }
                else
                {
                    tileFactory = BasicTileFactory;
                }
                for (int column = 0; column < 8; column++)
                {
                    if ((row + column) % 2 == 0)
                    {
                        tiles.Add(tileFactory.GetTile(row, column, TileColor.LightSquare, BoardTextures.LightSquare));
                    }
                    else
                    {
                        tiles.Add(tileFactory.GetTile(row, column, TileColor.DarkSquare, BoardTextures.DarkSquare));
                    }
                }
            }
            StandardBoardState initialState = new StandardBoardState(tiles);
            Board = new ChessBoard(origin, tileWidth, tileHeight, initialState);
        }
    }
}
