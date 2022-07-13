using board;

namespace board
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
            Pieces = new Piece[numLines, numColumns];
        }

        public Piece Piece(int numLine, int numColumn)
        {
            return Pieces[numLine, numColumn]; 
        }
        public Piece Piece(Position pos)
        {
            return Pieces[pos.Line, pos.Colunm];
        }

        public bool PieceExists(Position pos)
        {
            ValidatePosition(pos);
            return Piece(pos) != null;
        }

        public void AddPiece(Piece p, Position pos)
        {
            if (PieceExists(pos))
            {
                throw new BoardException("there is already a piece in that position");
            }
            Pieces[pos.Line, pos.Colunm] = p;
            p.Position = pos;
            
        }

        public bool PositionValid(Position pos)
        {
            if (pos.Line<0 || pos.Line>=NumLines || pos.Colunm<0 || pos.Colunm>=NumColumns)
            {
                return false;
            }
            return true;
        }

        public void ValidatePosition(Position pos)
        {
            if (!PositionValid(pos))
            {
                throw new BoardException("invalid position");
            }
        }
    }
}