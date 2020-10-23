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
        public Turn(int number, Player whiteplayer, Player blackplayer)
        {
            Number = number;
            WhitePlayer = whiteplayer;
            BlackPlayer = blackplayer;
            WhiteTurn = new PartialTurn(WhitePlayer);
            CurrentPartialTurn = WhiteTurn;
        }
        private Player WhitePlayer { get; }
        private Player BlackPlayer { get; }

        public int Number { get; }
        public PartialTurn WhiteTurn { get; private set; }
        public PartialTurn BlackTurn { get; private set; }
        public PartialTurn CurrentPartialTurn { get; private set; }

        public void SwitchPartialTurn()
        {
            BlackTurn = new PartialTurn(BlackPlayer);
            CurrentPartialTurn = BlackTurn;
        }
    }
}
