using board;
using System;
using System.Collections.Generic;
using System.Text;

namespace chess
{
    class Roock : Piece
    {
        public Roock(Color color, Board board) : base(color, board)
        {
        }
        public override string ToString()
        {
            return "R";
        }
    }
}
