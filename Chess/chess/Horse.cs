using board;
using System;


namespace chess
{
    class Horse : Piece
    {
        public Horse(Color color, Board board) : base(color, board)
        {
        }

        public override bool[,] PossibelMoves()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "H";
        }
    }
}
