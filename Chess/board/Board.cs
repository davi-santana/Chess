namespace Chess.board
{
    class Board
    {
        public int NumLines { get; set; }
        public int NumColumns { get; set; }
        private Piece[,] Pieces;

        public Board(int numLines, int numColumns)
        {
            NumLines = numLines;
            NumColumns = numColumns;
            Pieces = new Piece[numLines, NumColumns];
        }

        public Piece piece(int numLine, int numColumn)
        {
            return Pieces[numLine, numColumn]; 
        }
    }
}