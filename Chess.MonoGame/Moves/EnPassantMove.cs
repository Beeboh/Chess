using Chess.MonoGame.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame.Moves
{
    public class EnPassantMove : CaptureMove
    {
        public EnPassantMove(Tile selectedTile, Tile targetMoveTile, Tile targetCaptureTile) : base(selectedTile, targetMoveTile, targetCaptureTile)
        {
           
        }

        
    }
}
