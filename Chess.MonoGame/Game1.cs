using Chess.MonoGame.Board;
using Chess.MonoGame.Builders;
using Chess.MonoGame.Factories;
using Chess.MonoGame.Moves;
using Chess.MonoGame.Pieces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Chess.MonoGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        PieceTexturePack PieceTextures;
        BoardTexturePack BoardTextures;
        ChessMatch Match;

        MouseState PreviousMouseState;

        


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 800;  
            graphics.PreferredBackBufferHeight = 800;  
            graphics.ApplyChanges();
            IsMouseVisible = true;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
            ChessBoardBuilder standardBoardBuilder = new StandardBoardBuilder(BoardTextures, PieceTextures);
            ChessBoardShop BoardShop = new ChessBoardShop();
            ChessBoard Board = BoardShop.GetBoard(Point.Zero, 100, 100, standardBoardBuilder);
            
            Player WhitePlayer = new Player("Player1", Alliance.White);
            Player BlackPlayer = new Player("Player2", Alliance.Black);
            Match = new ChessMatch(Board, WhitePlayer, BlackPlayer);
            Match.Start(); //delete
            PreviousMouseState = Mouse.GetState();
            //debug. remember to (maybe) change the row/column of movementmove to private//

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            List<Texture2D> textures = new List<Texture2D>();
            Texture2D pawn_white = Content.Load<Texture2D>("pawn_white");
            Texture2D pawn_black = Content.Load<Texture2D>("pawn_black");
            Texture2D knight_white = Content.Load<Texture2D>("knight_white");
            Texture2D knight_black = Content.Load<Texture2D>("knight_black");
            Texture2D bishop_white = Content.Load<Texture2D>("bishop_white");
            Texture2D bishop_black = Content.Load<Texture2D>("bishop_black");
            Texture2D rook_white = Content.Load<Texture2D>("rook_white");
            Texture2D rook_black = Content.Load<Texture2D>("rook_black");
            Texture2D queen_white = Content.Load<Texture2D>("queen_white");
            Texture2D queen_black = Content.Load<Texture2D>("queen_black");
            Texture2D king_white = Content.Load<Texture2D>("king_white");
            Texture2D king_black = Content.Load<Texture2D>("king_black");
            Texture2D darksquare_green = Content.Load<Texture2D>("darksquare_green");
            Texture2D lightsquare_green = Content.Load<Texture2D>("lightsquare_green");

            BoardTextures = new BoardTexturePack(lightsquare_green, darksquare_green);
            PieceTextures = new PieceTexturePack(pawn_white, knight_white, bishop_white, rook_white, queen_white, king_white, pawn_black, knight_black, bishop_black, rook_black, queen_black, king_black);


            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            bool UserClicked = mouseState.LeftButton == ButtonState.Pressed && PreviousMouseState.LeftButton == ButtonState.Released;
            if (Match.Started)
            {
                if (UserClicked)
                {
                    Point MousePosition = new Point(mouseState.X, mouseState.Y);
                    Match.MouseClick(MousePosition);
                }
                Match.UpdateClock(gameTime.ElapsedGameTime);
            }
            else
            {
                //idk yet
            }
            PreviousMouseState = mouseState;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            ChessBoard Board = Match.Board;

            spriteBatch.Begin();
            foreach (Tile tile in Board.CurrentState.Tiles)
            {
                Rectangle tileposition = new Rectangle(Board.Origin.X + tile.Column * Board.TileWidth, Board.Origin.Y + tile.Row * Board.TileHeight, Board.TileWidth, Board.TileHeight);
                spriteBatch.Draw(tile.Texture, tileposition, tile.Tint);
                if (!tile.IsVacant)
                {
                    spriteBatch.Draw(tile.Piece.Texture, tileposition, Color.White);
                }
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
