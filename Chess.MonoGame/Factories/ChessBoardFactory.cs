//using Chess.MonoGame.Board;
//using Chess.MonoGame.Pieces;
//using Microsoft.Xna.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Chess.MonoGame.Factories
//{
//    public abstract class ChessBoardFactory
//    {
//        public abstract ChessBoard GetBoard(Point origin, int tilewidth, int tileheight);
//    }
//    public class StandardBoardFactory : ChessBoardFactory
//    {
//        public StandardBoardFactory(BoardTexturePack boardTextures, PieceTexturePack pieceTextures)
//        {
//            BoardTextures = boardTextures;
//            PieceTextures = pieceTextures;
//            PawnFactory = new PawnFactory();
//            KnightFactory = new KnightFactory();
//            BishopFactory = new BishopFactory();
//            RookFactory = new RookFactory();
//            QueenFactory = new QueenFactory();
//            KingFactory = new KingFactory();
//        }
//        private BoardTexturePack BoardTextures { get; }
//        private PieceTexturePack PieceTextures { get; }
//        private ChessPieceFactory PawnFactory { get; }
//        private ChessPieceFactory KnightFactory { get; }
//        private ChessPieceFactory BishopFactory { get; }
//        private ChessPieceFactory RookFactory { get; }
//        private ChessPieceFactory QueenFactory { get; }
//        private ChessPieceFactory KingFactory { get; }

//        public override ChessBoard GetBoard(Point origin, int tileWidth, int tileHeight)
//        {

//            //Create pieces
//            ChessPiece aPawn_white = PawnFactory.GetPiece(Alliance.White, PieceTextures.WhitePawn);
//            ChessPiece bPawn_white = PawnFactory.GetPiece(Alliance.White, PieceTextures.WhitePawn);
//            ChessPiece cPawn_white = PawnFactory.GetPiece(Alliance.White, PieceTextures.WhitePawn);
//            ChessPiece dPawn_white = PawnFactory.GetPiece(Alliance.White, PieceTextures.WhitePawn);
//            ChessPiece ePawn_white = PawnFactory.GetPiece(Alliance.White, PieceTextures.WhitePawn);
//            ChessPiece fPawn_white = PawnFactory.GetPiece(Alliance.White, PieceTextures.WhitePawn);
//            ChessPiece gPawn_white = PawnFactory.GetPiece(Alliance.White, PieceTextures.WhitePawn);
//            ChessPiece hPawn_white = PawnFactory.GetPiece(Alliance.White, PieceTextures.WhitePawn);
//            ChessPiece bKnight_white = KnightFactory.GetPiece(Alliance.White, PieceTextures.WhiteKnight);
//            ChessPiece gKnight_white = KnightFactory.GetPiece(Alliance.White, PieceTextures.WhiteKnight);
//            ChessPiece cBishop_white = BishopFactory.GetPiece(Alliance.White, PieceTextures.WhiteBishop);
//            ChessPiece fBishop_white = BishopFactory.GetPiece(Alliance.White, PieceTextures.WhiteBishop);
//            ChessPiece aRook_white = RookFactory.GetPiece(Alliance.White, PieceTextures.WhiteRook);
//            ChessPiece hRook_white = RookFactory.GetPiece(Alliance.White, PieceTextures.WhiteRook);
//            ChessPiece queen_white = QueenFactory.GetPiece(Alliance.White, PieceTextures.WhiteQueen);
//            ChessPiece king_white = KingFactory.GetPiece(Alliance.White, PieceTextures.WhiteKing);

//            ChessPiece aPawn_black = PawnFactory.GetPiece(Alliance.Black, PieceTextures.BlackPawn);
//            ChessPiece bPawn_black = PawnFactory.GetPiece(Alliance.Black, PieceTextures.BlackPawn);
//            ChessPiece cPawn_black = PawnFactory.GetPiece(Alliance.Black, PieceTextures.BlackPawn);
//            ChessPiece dPawn_black = PawnFactory.GetPiece(Alliance.Black, PieceTextures.BlackPawn);
//            ChessPiece ePawn_black = PawnFactory.GetPiece(Alliance.Black, PieceTextures.BlackPawn);
//            ChessPiece fPawn_black = PawnFactory.GetPiece(Alliance.Black, PieceTextures.BlackPawn);
//            ChessPiece gPawn_black = PawnFactory.GetPiece(Alliance.Black, PieceTextures.BlackPawn);
//            ChessPiece hPawn_black = PawnFactory.GetPiece(Alliance.Black, PieceTextures.BlackPawn);
//            ChessPiece bKnight_black = KnightFactory.GetPiece(Alliance.Black, PieceTextures.BlackKnight);
//            ChessPiece gKnight_black = KnightFactory.GetPiece(Alliance.Black, PieceTextures.BlackKnight);
//            ChessPiece cBishop_black = BishopFactory.GetPiece(Alliance.Black, PieceTextures.BlackBishop);
//            ChessPiece fBishop_black = BishopFactory.GetPiece(Alliance.Black, PieceTextures.BlackBishop);
//            ChessPiece aRook_black = RookFactory.GetPiece(Alliance.Black, PieceTextures.BlackRook);
//            ChessPiece hRook_black = RookFactory.GetPiece(Alliance.Black, PieceTextures.BlackRook);
//            ChessPiece queen_black = QueenFactory.GetPiece(Alliance.Black, PieceTextures.BlackQueen);
//            ChessPiece king_black = KingFactory.GetPiece(Alliance.Black, PieceTextures.BlackKing);

//            //Create Tiles
//            List<Tile> tiles = new List<Tile>();
//            for (int i = 0; i < 8; i++)
//            {
//                for (int j = 0; j < 8; j++)
//                {
//                    if ((i + j) % 2 == 0)
//                    {
//                        tiles.Add(new Tile(i, j, TileColor.LightSquare, BoardTextures.LightSquare));
//                    }
//                    else
//                    {
//                        tiles.Add(new Tile(i, j, TileColor.DarkSquare, BoardTextures.DarkSquare));
//                    }
//                }
//            }

//            //Create the board and add the pieces
//            BoardState InitialBoardState = new StandardBoardState(tiles);

//            InitialBoardState[0, 0].AttachPiece(aRook_black, false);
//            InitialBoardState[0, 1].AttachPiece(bKnight_black, false);
//            InitialBoardState[0, 2].AttachPiece(cBishop_black, false);
//            InitialBoardState[0, 3].AttachPiece(queen_black, false);
//            InitialBoardState[0, 4].AttachPiece(king_black, false);
//            InitialBoardState[0, 5].AttachPiece(fBishop_black, false);
//            InitialBoardState[0, 6].AttachPiece(gKnight_black, false);
//            InitialBoardState[0, 7].AttachPiece(hRook_black, false);

//            InitialBoardState[1, 0].AttachPiece(aPawn_black, false);
//            InitialBoardState[1, 1].AttachPiece(bPawn_black, false);
//            InitialBoardState[1, 2].AttachPiece(cPawn_black, false);
//            InitialBoardState[1, 3].AttachPiece(dPawn_black, false);
//            InitialBoardState[1, 4].AttachPiece(ePawn_black, false);
//            InitialBoardState[1, 5].AttachPiece(fPawn_black, false);
//            InitialBoardState[1, 6].AttachPiece(gPawn_black, false);
//            InitialBoardState[1, 7].AttachPiece(hPawn_black, false);

//            InitialBoardState[6, 0].AttachPiece(aPawn_white, false);
//            InitialBoardState[6, 1].AttachPiece(bPawn_white, false);
//            InitialBoardState[6, 2].AttachPiece(cPawn_white, false);
//            InitialBoardState[6, 3].AttachPiece(dPawn_white, false);
//            InitialBoardState[6, 4].AttachPiece(ePawn_white, false);
//            InitialBoardState[6, 5].AttachPiece(fPawn_white, false);
//            InitialBoardState[6, 6].AttachPiece(gPawn_white, false);
//            InitialBoardState[6, 7].AttachPiece(hPawn_white, false);

//            InitialBoardState[7, 0].AttachPiece(aRook_white, false);
//            InitialBoardState[7, 1].AttachPiece(bKnight_white, false);
//            InitialBoardState[7, 2].AttachPiece(cBishop_white, false);
//            InitialBoardState[7, 3].AttachPiece(queen_white, false);
//            InitialBoardState[7, 4].AttachPiece(king_white, false);
//            InitialBoardState[7, 5].AttachPiece(fBishop_white, false);
//            InitialBoardState[7, 6].AttachPiece(gKnight_white, false);
//            InitialBoardState[7, 7].AttachPiece(hRook_white, false);

//            return new ChessBoard(origin, tileWidth, tileHeight, InitialBoardState);
//        }
//    }
//}
