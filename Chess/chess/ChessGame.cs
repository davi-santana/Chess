using board;
using System;

namespace chess
{
    class ChessGame
    {
        public Board board { get; private set; }
        private int shift;
        private Color currentPlayer;
        public bool Finished { get; private set; }

        public ChessGame()
        {
            board = new Board(8, 8);
            shift = 1;
            currentPlayer = Color.white;
            Finished = false;
            AddPiece();
        }

        public void ExecuteMovement(Position origin, Position destiny)
        {
            Piece piece = board.RemovePiece(origin);
            piece.IncreaseMovements();
            board.RemovePiece(destiny);
            Piece capturePiece = board.RemovePiece(destiny);
            board.AddPiece(piece, destiny);
        }

        private void AddPiece()
        {
            board.AddPiece(new Roock(Color.white, board), new ChessPosition('a', 1).ToPosition());
            board.AddPiece(new Horse(Color.white, board), new ChessPosition('b', 1).ToPosition());
            board.AddPiece(new Bishop(Color.white, board), new ChessPosition('c', 1).ToPosition());
            board.AddPiece(new Queen(Color.white, board), new ChessPosition('d', 1).ToPosition());
            board.AddPiece(new King(Color.white, board), new ChessPosition('e', 1).ToPosition());
            board.AddPiece(new Bishop(Color.white, board), new ChessPosition('f', 1).ToPosition());
            board.AddPiece(new Horse(Color.white, board), new ChessPosition('g', 1).ToPosition());
            board.AddPiece(new Roock(Color.white, board), new ChessPosition('h', 1).ToPosition());
            board.AddPiece(new Roock(Color.black, board), new ChessPosition('a', 8).ToPosition());
            board.AddPiece(new Horse(Color.black, board), new ChessPosition('b', 8).ToPosition());
            board.AddPiece(new Bishop(Color.black, board), new ChessPosition('c', 8).ToPosition());
            board.AddPiece(new Queen(Color.black, board), new ChessPosition('d', 8).ToPosition());
            board.AddPiece(new King(Color.black, board), new ChessPosition('e', 8).ToPosition());
            board.AddPiece(new Bishop(Color.black, board), new ChessPosition('f', 8).ToPosition());
            board.AddPiece(new Horse(Color.black, board), new ChessPosition('g', 8).ToPosition());
            board.AddPiece(new Roock(Color.black, board), new ChessPosition('h', 8).ToPosition());


        }
    }
}
