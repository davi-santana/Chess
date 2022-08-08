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
            bool[,] mat = new bool[Board.NumLines, Board.NumColumns];
            Position position = new Position(0, 0);

            
            position.SetValues(Position.Line - 1, Position.Colunm - 2);
            if(Board.PositionValid(position)&& CanMove(position))
            {
                mat[position.Line, position.Colunm] = true;
            } 

            position.SetValues(Position.Line - 2, Position.Colunm - 1);
            if(Board.PositionValid(position)&& CanMove(position))
            {
                mat[position.Line, position.Colunm] = true;
            }  

            position.SetValues(Position.Line - 2, Position.Colunm + 1);
            if(Board.PositionValid(position)&& CanMove(position))
            {
                mat[position.Line, position.Colunm] = true;
            }  
            
            position.SetValues(Position.Line - 1, Position.Colunm + 2);
            if(Board.PositionValid(position)&& CanMove(position))
            {
                mat[position.Line, position.Colunm] = true;
            }
            
            position.SetValues(Position.Line +  1, Position.Colunm + 2);
            if(Board.PositionValid(position)&& CanMove(position))
            {
                mat[position.Line, position.Colunm] = true;
            } 
            
            position.SetValues(Position.Line +  2, Position.Colunm + 1 );
            if(Board.PositionValid(position)&& CanMove(position))
            {
                mat[position.Line, position.Colunm] = true;
            }
            
            position.SetValues(Position.Line +  2, Position.Colunm - 1 );
            if(Board.PositionValid(position)&& CanMove(position))
            {
                mat[position.Line, position.Colunm] = true;
            } 
            position.SetValues(Position.Line +  2, Position.Colunm - 1 );
            if(Board.PositionValid(position)&& CanMove(position))
            {
                mat[position.Line, position.Colunm] = true;
            }  
            
            position.SetValues(Position.Line +1, Position.Colunm - 2 );
            if(Board.PositionValid(position)&& CanMove(position))
            {
                mat[position.Line, position.Colunm] = true;
            }
            return mat;
        }

        private bool CanMove(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece == null || piece.Color != Color;
        }



        public override string ToString()
        {
            return "H";
        }
    }
}
