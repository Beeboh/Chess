using Chess.MonoGame.Board;
using Chess.MonoGame.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame
{
    public class PartialTurn
    {
        public PartialTurn(Player player)
        {
            Player = player;
        }
        public Player Player { get; }
        public ChessPiece SelectedPiece { get; private set; }

        public void SetSelectedPiece(ChessPiece piece)
        {
            SelectedPiece = piece;
        }
        public void DeselectPiece()
        {
            SelectedPiece = null;
        }
    }
}
