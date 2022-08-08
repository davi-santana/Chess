using board;


namespace chess
{
    class Roock : Piece
    {
        public Roock(Color color, Board board) : base(color, board)
        {
        }

        private bool CanMove(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece == null || piece.Color != Color;
        }

        public override string ToString()
        {
            return "R";
        }

        public override bool[,] PossibelMoves()
        {
            bool[,] mat = new bool[Board.NumLines, Board.NumColumns];

            Position position = new Position(0, 0);

            //above
            position.SetValues(Position.Line - 1, Position.Colunm);
            while (Board.PositionValid(position) && CanMove(position))
            {
                mat[position.Line, position.Colunm] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Line = position.Line - 1;
            }

            //below
            position.SetValues(Position.Line + 1, Position.Colunm);
            while (Board.PositionValid(position) && CanMove(position))
            {
                mat[position.Line, position.Colunm] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Line = position.Line + 1;
            }

            //right
            position.SetValues(Position.Line, Position.Colunm + 1);
            while (Board.PositionValid(position) && CanMove(position))
            {
                mat[position.Line, position.Colunm] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Colunm = position.Colunm + 1;
            }

            //left
            position.SetValues(Position.Line, Position.Colunm - 1);
            while (Board.PositionValid(position) && CanMove(position))
            {
                mat[position.Line, position.Colunm] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Colunm = position.Colunm - 1;
            }

            return mat;
        }
    }
}
