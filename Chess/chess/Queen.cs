using board;
using System;
using System.Collections.Generic;
using System.Text;

namespace chess
{
    class Queen : Piece
    {
        public Queen(Color color, Board board) : base(color, board)
        {
        }

        public override bool[,] PossibelMoves()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "Q";
        }
    }
}
