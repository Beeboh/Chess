using Chess.MonoGame.Board;
using Chess.MonoGame.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame.Moves
{
    public abstract class StartingMove : Move
    {
        public StartingMove(Tile selectedTile, Tile targetTile) : base(selectedTile.Piece, selectedTile, targetTile)
        {

        }
        
    }
}
