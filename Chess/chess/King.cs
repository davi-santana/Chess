using board;
using System;
 
namespace chess
{
    class King : Piece
    {
        public King(Color color, Board board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "K";
        }

        private bool CanMove(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece == null || piece.Color != Color; 
        }

        //public override bool[,] PossibelMoves()
        //{
        //    bool[,] mat = new bool[Board.NumLines, Board.NumColumns];

        //    Position position = new Position(0, 0);

        //    //above
        //    Position.SetValues(Position.Line - 1, Position.Colunm);
        //    if(Board.PositionValid(position) && CanMove(position))
        //    {
        //        mat[position.Line, position.Colunm] = true;
        //    }

        //    //NE
        //    position.SetValues(Position.Line - 1, Position.Colunm +1);
        //    if (Board.PositionValid(position) && CanMove(position))
        //    {
        //        mat[position.Line, position.Colunm] = true;
        //    }

        //    //right
        //    position.SetValues(Position.Line, Position.Colunm + 1);
        //    if (Board.PositionValid(position) && CanMove(position))
        //    {
        //        mat[position.Line, position.Colunm] = true;
        //    }

        //    //S
        //    position.SetValues(Position.Line + 1, Position.Colunm + 1);
        //    if (Board.PositionValid(position) && CanMove(position))
        //    {
        //        mat[position.Line, position.Colunm] = true;
        //    }

        //    //below
        //    position.SetValues(Position.Line + 1, Position.Colunm);
        //    if (Board.PositionValid(position) && CanMove(position))
        //    {
        //        mat[position.Line, position.Colunm] = true;
        //    }

        //    //SO
        //    position.SetValues(Position.Line +1, Position.Colunm -1);
        //    if (Board.PositionValid(position) && CanMove(position))
        //    {
        //        mat[position.Line, position.Colunm] = true;
        //    }

        //    //left
        //    position.SetValues(Position.Line, Position.Colunm -1);
        //    if (Board.PositionValid(position) && CanMove(position))
        //    {
        //        mat[position.Line, position.Colunm] = true;
        //    }

        //    //NO
        //    position.SetValues(Position.Line - 1, Position.Colunm + 1);
        //    if (Board.PositionValid(position) && CanMove(position))
        //    {
        //        mat[position.Line, position.Colunm] = true;
        //    }

        //    return mat;
        //}

        public override bool[,] PossibelMoves()
        {
            bool[,] mat = new bool[Board.NumLines, Board.NumColumns];

            Position position = new Position(0, 0);

            // acima
            position.SetValues(Position.Line - 1, Position.Colunm);
            if (Board.PositionValid(position) && CanMove(position))
            {
                mat[position.Line, position.Colunm] = true;
            }

            //NE
            position.SetValues(Position.Line - 1, Position.Colunm +1);
            if (Board.PositionValid(position) && CanMove(position))
            {
                mat[position.Line, position.Colunm] = true;
            }

            //direita
            position.SetValues(Position.Line, Position.Colunm + 1);
            if (Board.PositionValid(position) && CanMove(position))
            {
                mat[position.Line, position.Colunm] = true;
            }

            //SE
            position.SetValues(Position.Line + 1, Position.Colunm + 1);
            if (Board.PositionValid(position) && CanMove(position))
            {
                mat[position.Line, position.Colunm] = true;
            }

            //abaixo
            position.SetValues(Position.Line + 1, Position.Colunm);
            if (Board.PositionValid(position) && CanMove(position))
            {
                mat[position.Line, position.Colunm] = true;
            }

            //SO
            position.SetValues(Position.Line + 1, Position.Colunm - 1);
            if (Board.PositionValid(position) && CanMove(position))
            {
                mat[position.Line, position.Colunm] = true;
            }

            //
            position.SetValues(Position.Line, Position.Colunm -1);
            if (Board.PositionValid(position) && CanMove(position))
            {
                mat[position.Line, position.Colunm] = true;
            }

            //NO
            position.SetValues(Position.Line - 1, Position.Colunm - 1);
            if (Board.PositionValid(position) && CanMove(position))
            {
                mat[position.Line, position.Colunm] = true;
            }



            return mat;
        }

    }

}
