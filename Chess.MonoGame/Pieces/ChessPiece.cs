﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.MonoGame.Behaviours;
using Chess.MonoGame.Board;
using Chess.MonoGame.Moves;
using Microsoft.Xna.Framework.Graphics;

namespace Chess.MonoGame.Pieces
{
    public abstract class ChessPiece
    {
        public ChessPiece(Alliance alliance, Texture2D texture, IEnumerable<IPieceBehaviour> pieceBehaviours)
        {
            Row = 0;
            Column = 0;
            Alliance = alliance;
            Texture = texture;
            PieceBehaviours = pieceBehaviours;
        }
        public ChessPiece(Alliance alliance, Texture2D texture, IEnumerable<IPieceBehaviour> pieceBehaviours, int row, int column)
        {
            Row = row;
            Column = column;
            Alliance = alliance;
            Texture = texture;
            PieceBehaviours = pieceBehaviours;
        }


        public int Column { get; private set; }
        public int Row { get; private set; }

        public void SetPosition(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public Alliance Alliance { get; }
        public Texture2D Texture { get; }

        private IEnumerable<IPieceBehaviour> PieceBehaviours { get; }


        //Maybe move to a different class, only downside is making PieceBehaviours public
        public ReadOnlyCollection<Move> GetCandidateMoves(ChessBoard board)
        {
            List<Move> CandidateMoves = new List<Move>();
            foreach(IPieceBehaviour pieceBehaviour in PieceBehaviours)
            {
                ReadOnlyCollection<Move> behaviourmoves = pieceBehaviour.GetCandidateMoves(board, this);
                CandidateMoves.AddRange(behaviourmoves);
            }
            return CandidateMoves.AsReadOnly();
        }
    }
}
