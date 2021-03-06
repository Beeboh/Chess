﻿using Chess.MonoGame.Board;
using Chess.MonoGame.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame.Moves
{
    public class MovementMove : Move
    {
        public MovementMove(Tile selectedTile, Tile targetTile) : base(selectedTile.Piece, selectedTile, targetTile)
        {
            executed = false;
            PieceHasMoved = Piece.HasMoved;
        }
        private bool executed { get; set; }
        private bool PieceHasMoved { get; set; }

        public override void Execute()
        {
            if (!executed)
            {
                SelectedTile.DetachPiece();
                TargetTile.AttachPiece(Piece, true);
                executed = true;
            }
        }

        public override void Undo()
        {
            if (executed)
            {
                TargetTile.DetachPiece();
                SelectedTile.AttachPiece(Piece, PieceHasMoved);
                executed = false;
            }
        }
    }
}
