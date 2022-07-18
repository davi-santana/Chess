﻿using board;
using System;


namespace chess
{
    class Horse : Piece
    {
        public Horse(Color color, Board board) : base(color, board)
        {
        }
        public override string ToString()
        {
            return "H";
        }
    }
}
