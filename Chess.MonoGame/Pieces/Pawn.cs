﻿using Chess.MonoGame.Behaviours;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame.Pieces
{
    public class Pawn : ChessPiece, IEnPassantable
    {
        public Pawn(Alliance alliance, Texture2D texture, IEnumerable<IPieceBehaviour> pieceBehaviours) : base(alliance, texture, pieceBehaviours)
        {
            CurrentlyEnPassantable = false;
        }
        public Pawn(Alliance alliance, Texture2D texture, IEnumerable<IPieceBehaviour> pieceBehaviours, int x, int y) : base(alliance, texture, pieceBehaviours, x, y)
        {
            CurrentlyEnPassantable = false;
        }

        public bool CurrentlyEnPassantable { get; set; }
    }
}
