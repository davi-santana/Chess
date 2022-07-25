using board;

namespace board
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int NumberMoves { get; protected set; }
        public Board Board { get; set; }

        public Piece(Color color, Board board)
        {
            Position = null;
            Color = color;
            Board = board;
            NumberMoves = 0;
        }
        public void IncreaseMovements()
        {
            NumberMoves++;
        }
        public bool ThereArePossibleMoves()
        {
            bool[,] mat = PossibelMoves();
            for (int i = 0; i < Board.NumLines; i++)
            {
                for (int j = 0; j < Board.NumColumns; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveTo(Position pos)
        {
            return PossibelMoves()[pos.Line, pos.Colunm]; 
        }

        public abstract bool[,] PossibelMoves();

    }
}
