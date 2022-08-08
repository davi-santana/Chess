using board;


namespace chess
{
    class Bishop : Piece
    {
        public Bishop(Color color, Board board) : base(color, board)
        {
        }

        public override bool[,] PossibelMoves()
        {
            bool[,] mat = new bool[Board.NumLines, Board.NumColumns];
            Position position = new Position(0, 0);

            //NO
            position.SetValues(Position.Line - 1, Position.Colunm-1);
            while (Board.PositionValid(position) && CanMove(position))
            {
                mat[position.Line, position.Colunm] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.SetValues  (position.Line - 1, position.Colunm -1);
            } 
            //NE
            position.SetValues(Position.Line - 1, Position.Colunm+1);
            while (Board.PositionValid(position) && CanMove(position))
            {
                mat[position.Line, position.Colunm] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.SetValues  (position.Line - 1, position.Colunm +1);
            }  
            
            //SE
            position.SetValues(Position.Line + 1, Position.Colunm+1);
            while (Board.PositionValid(position) && CanMove(position))
            {
                mat[position.Line, position.Colunm] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.SetValues  (position.Line + 1, position.Colunm +1);
            }   
            //SO 
            position.SetValues(Position.Line + 1, Position.Colunm-1);
            while (Board.PositionValid(position) && CanMove(position))
            {
                mat[position.Line, position.Colunm] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.SetValues  (position.Line + 1, position.Colunm -1);
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
            return "B";
        }
    }
}
