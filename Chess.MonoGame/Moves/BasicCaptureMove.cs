using Chess.MonoGame.Board;
using Chess.MonoGame.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame.Moves
{
    public class BasicCaptureMove : CaptureMove
    {
        public BasicCaptureMove(Tile selectedTile, Tile targetTile) : base(selectedTile, targetTile, targetTile)
        {

            
        }
        
        
    }
}
