﻿using Chess.MonoGame.Board;
using Chess.MonoGame.Moves;
using Chess.MonoGame.Pieces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame
{
    public class PartialTurnTracker
    {
        public PartialTurnTracker(Player player, ChessClock clock, ChessBoard board)
        {
            Player = player;
            Clock = clock;
            Board = board;
            StartTime = Clock.Time;
        }
        private Player Player { get; }
        private TimeSpan StartTime { get; }
        private ChessClock Clock { get; }
        private ChessBoard Board { get; }
        public ChessPiece SelectedPiece { get; private set; }
        public PartialTurn PartialTurn { get; private set; }
        public void SelectTile(Tile selectedtile)
        {
            if (selectedtile != null)
            {
                if (!selectedtile.IsVacant && selectedtile.Piece.Alliance == Player.Alliance)
                {
                    if (SelectedPiece != null)
                    {
                        Board.CurrentState[SelectedPiece.Row, SelectedPiece.Column].SetTint(Color.White);
                    }
                    SelectedPiece = selectedtile.Piece;
                    selectedtile.SetTint(Color.LightBlue);
                }
                else if (SelectedPiece != null)
                {
                    ReadOnlyCollection<Move> CandidateMoves = SelectedPiece.GetCandidateMoves(Board.CurrentState);
                    BoardState CopiedBoard = Board.CurrentState.GetCopy();
                    ChessPiece CopiedSelectedPiece = Board.CurrentState[SelectedPiece.Row, SelectedPiece.Column].Piece;
                    ReadOnlyCollection<Move> CopiedCandidateMoves = CopiedSelectedPiece.GetCandidateMoves(CopiedBoard);

                    List<Move> CopiedNonLegalMoves = new List<Move>();
                    foreach(Move CopiedCandidateMove in CopiedCandidateMoves)
                    {
                        CopiedCandidateMove.Execute();
                        bool LegalMove = true;
                        List<ChessPiece> OpponentPieces = new List<ChessPiece>();
                        foreach(Tile tile in CopiedBoard.Tiles)
                        {
                            if (!tile.IsVacant)
                            {
                                if (tile.Piece.Alliance != CopiedSelectedPiece.Alliance)
                                {
                                    OpponentPieces.Add(tile.Piece);
                                }
                            }
                        }
                        foreach(ChessPiece OpponentPiece in OpponentPieces)
                        {
                            ReadOnlyCollection<Move> OpponentCandidateMoves = OpponentPiece.GetCandidateMoves(CopiedBoard);
                            foreach(Move OpponentCandidateMove in OpponentCandidateMoves)
                            {
                                if(OpponentCandidateMove is BasicCaptureMove)
                                {
                                    BasicCaptureMove captureMove = OpponentCandidateMove as BasicCaptureMove;
                                    if (captureMove.CapturedPiece is King)
                                    {
                                        LegalMove = false;
                                    }
                                }
                                if (!LegalMove)
                                {
                                    break;
                                }
                            }
                            if (!LegalMove)
                            {
                                break;
                            }
                        }
                        if (!LegalMove)
                        {
                            CopiedNonLegalMoves.Add(CopiedCandidateMove);
                        }
                        CopiedCandidateMove.Undo();
                    }
                    List<Move> LegalMoves = CandidateMoves.ToList();
                    foreach(Move CopiedNonLegalMove in CopiedNonLegalMoves)
                    {
                        Move NonLegalMove = CandidateMoves.Where(m => m.TargetTile.Row == CopiedNonLegalMove.TargetTile.Row && m.TargetTile.Column == CopiedNonLegalMove.TargetTile.Column).FirstOrDefault();
                        LegalMoves.Remove(NonLegalMove);
                    }

                    Move SelectedMove = LegalMoves.Where(m => m.Piece == SelectedPiece && m.TargetTile == selectedtile).FirstOrDefault();
                    if (SelectedMove != null)
                    {
                        Board.Move(SelectedMove);
                        PartialTurn = new PartialTurn(Player, SelectedMove, StartTime, Clock.Time);
                    }
                    else
                    {
                        Board.CurrentState[SelectedPiece.Row, SelectedPiece.Column].SetTint(Color.White);
                        SelectedPiece = null;
                    }
                }
            }
        }
    }
}
