using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Chess.MonoGame.Board;
using Chess.MonoGame.Moves;
using Chess.MonoGame.Pieces;

namespace Chess.MonoGame
{
    public class ChessMatch
    {
        public ChessMatch(ChessBoard board, Player whiteplayer, Player blackplayer)
        {
            Board = board;
            WhitePlayer = whiteplayer;
            BlackPlayer = blackplayer;
            Turns = new List<Turn>();

            Started = false;
            Ended = false;
        }
        private ChessBoard Board { get; }
        private Player WhitePlayer { get; }
        private Player BlackPlayer { get; }
        public Turn CurrentTurn { get; private set; }
        private List<Turn> Turns { get; }

        public bool Started { get; private set; }
        public bool Ended { get; private set; }
        public Player Winner { get; }

        public void MouseClick(Point mouseposition)
        {
            Point MousePositionOnBoard = mouseposition - Board.Origin;
            int SelectedColumn = MousePositionOnBoard.X / Board.TileWidth;
            int SelectedRow = MousePositionOnBoard.Y / Board.TileHeight;
            if (Board.ValidTile(SelectedRow, SelectedColumn))
            {
                Tile SelectedTile = Board[SelectedRow, SelectedColumn];
                if (CurrentTurn.CurrentPartialTurn.SelectedPiece == null)
                {
                    if (!SelectedTile.IsVacant)
                    {
                        if (SelectedTile.Piece.Alliance == CurrentTurn.CurrentPartialTurn.Player.Alliance)
                        {
                            CurrentTurn.CurrentPartialTurn.SetSelectedPiece(SelectedTile.Piece);
                        }
                    }
                }
                else
                {
                    if (!SelectedTile.IsVacant && SelectedTile.Piece.Alliance == CurrentTurn.CurrentPartialTurn.Player.Alliance)
                    {
                        CurrentTurn.CurrentPartialTurn.SetSelectedPiece(SelectedTile.Piece);
                    }
                    else
                    {
                        ReadOnlyCollection<Move> CandidateMoves = CurrentTurn.CurrentPartialTurn.SelectedPiece.GetCandidateMoves(Board);
                        Move SelectedMove = CandidateMoves.Where(m => m.Piece == CurrentTurn.CurrentPartialTurn.SelectedPiece && m.TargetRow == SelectedRow && m.TargetColumn == SelectedColumn).FirstOrDefault();
                        if (SelectedMove != null)
                        {
                            SelectedMove.Execute();
                            if (CurrentTurn.CurrentPartialTurn == CurrentTurn.WhiteTurn)
                            {
                                CurrentTurn.SwitchPartialTurn();
                            }
                            else if (CurrentTurn.CurrentPartialTurn == CurrentTurn.BlackTurn)
                            {
                                NewTurn();
                            }
                        }
                        else
                        {
                            CurrentTurn.CurrentPartialTurn.DeselectPiece();
                        }
                    }
                    
                }
            }
        }
        public void UpdateClock(TimeSpan delta)
        {
            throw new NotImplementedException();
        }
        public void Start()
        {
            Started = true;
            NewTurn();
        }
        public ChessBoard GetBoard()
        {
            return Board;
        }

        private void NewTurn()
        {
            int NewTurnNumber = Turns.Count + 1;
            Turn NewTurn = new Turn(NewTurnNumber, WhitePlayer, BlackPlayer);
            Turns.Add(NewTurn);
            CurrentTurn = NewTurn;
        }
    }

}
