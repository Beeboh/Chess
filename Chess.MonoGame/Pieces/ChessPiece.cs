using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.MonoGame.Behaviours;
using Chess.MonoGame.Board;
using Chess.MonoGame.Factories;
using Chess.MonoGame.Moves;
using Microsoft.Xna.Framework.Graphics;

namespace Chess.MonoGame.Pieces
{
    public abstract class ChessPiece
    {
        public ChessPiece(Alliance alliance, Texture2D texture, IEnumerable<IPieceBehaviour> pieceBehaviours, bool hasmoved, int materialValue, ChessPieceFactory factory)
        {
            Row = 0;
            Column = 0;
            Alliance = alliance;
            Texture = texture;
            PieceBehaviours = pieceBehaviours;
            HasMoved = hasmoved;
            MaterialValue = materialValue;
            Factory = factory;
        }
        public ChessPiece(Alliance alliance, Texture2D texture, IEnumerable<IPieceBehaviour> pieceBehaviours, int row, int column, bool hasmoved, int materialValue, ChessPieceFactory factory)
        {
            Row = row;
            Column = column;
            Alliance = alliance;
            Texture = texture;
            PieceBehaviours = pieceBehaviours;
            HasMoved = hasmoved;
            MaterialValue = materialValue;
            Factory = factory;
        }

        public int Row { get; private set; }
        public int Column { get; private set; }
        public Alliance Alliance { get; }
        public Texture2D Texture { get; }
        protected IEnumerable<IPieceBehaviour> PieceBehaviours { get; }
        public bool HasMoved { get; private set; }
        public int MaterialValue { get; }
        protected ChessPieceFactory Factory { get; }

        public void InitializePosition(int row, int column)
        {
            Row = row;
            Column = column;
            HasMoved = false;
        }
        public void MovePosition(int row, int column)
        {
            Row = row;
            Column = column;
            HasMoved = true;
        }
        public void SetPoition(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public ReadOnlyCollection<Move> GetCandidateMoves(BoardState board)
        {
            List<Move> CandidateMoves = new List<Move>();
            foreach(IPieceBehaviour pieceBehaviour in PieceBehaviours)
            {
                ReadOnlyCollection<Move> behaviourmoves = pieceBehaviour.GetCandidateMoves(board, this);
                CandidateMoves.AddRange(behaviourmoves);
            }
            return CandidateMoves.AsReadOnly();
        }
        public ChessPiece GetCopy()
        {
            return Factory.GetPiece(Row, Column);
        }
    }
}
