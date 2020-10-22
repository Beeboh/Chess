using System;
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
            StartingRow = 0;
            StartingColumn = 0;
            Row = StartingRow;
            Column = StartingColumn;
            Alliance = alliance;
            Texture = texture;
            PieceBehaviours = pieceBehaviours;
            HasMoved = false;
        }
        public ChessPiece(Alliance alliance, Texture2D texture, IEnumerable<IPieceBehaviour> pieceBehaviours, int row, int column)
        {
            StartingRow = row;
            StartingColumn = column;
            Row = StartingRow;
            Column = StartingColumn;
            Alliance = alliance;
            Texture = texture;
            PieceBehaviours = pieceBehaviours;
            HasMoved = false;
        }


        public int Column { get; private set; }
        public int Row { get; private set; }
        public bool HasMoved { get; private set; }
        private int StartingColumn { get; set; }
        private int StartingRow { get; set; }

        public void SetPosition(int row, int column)
        {
            Row = row;
            Column = column;
            HasMoved = true;
        }
        public void Initiate()
        {
            HasMoved = false;
            StartingRow = Row;
            StartingColumn = Column;
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
