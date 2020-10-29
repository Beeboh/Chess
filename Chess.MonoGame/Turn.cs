using Chess.MonoGame.Board;
using Chess.MonoGame.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame
{
    public class Turn
    {
        public Turn(int number, PartialTurn whiteTurn)
        {
            Number = number;
            WhiteTurn = whiteTurn;
        }
        public Turn(int number, PartialTurn whiteTurn, PartialTurn blackTurn)
        {
            Number = number;
            WhiteTurn = whiteTurn;
            BlackTurn = blackTurn;
        }

        public int Number { get; }
        public PartialTurn WhiteTurn { get; }
        public PartialTurn BlackTurn { get; set; }
    }
}
