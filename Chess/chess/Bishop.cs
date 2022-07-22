using board;
using System;
using System.Collections.Generic;
using System.Text;

namespace chess
{
    class Bishop : Piece
    {
        public Bishop(Color color, Board board) : base(color, board)
        {
        }

        public override bool[,] PossibelMoves()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "B";
        }
    }
}
