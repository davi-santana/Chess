using board;
using System;

namespace chess
{
    class ChessGame
    {
        public Board Board { get; private set; }
        public int Shift { get; private set; }
        public Color CurrentPlayer { get; private set;}
        public bool Finished { get; private set; }

        public ChessGame()
        {
            Board = new Board(8, 8);
            Shift = 1;
            CurrentPlayer = Color.white;
            Finished = false;
            AddPiece();
        }

        public void ExecuteMovement(Position origin, Position destiny)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.IncreaseMovements();
            Board.RemovePiece(destiny);
            Piece capturePiece = Board.RemovePiece(destiny);
            Board.AddPiece(piece, destiny);
        }

        public void MakeMove(Position origin, Position destiny) 
        {

            ExecuteMovement(origin, destiny);
            Shift++;
            ChangeGame();
        
        }

        public void ValidatePositionOrigin(Position pos)
        {
            if(Board.Piece(pos) == null)
            {
                throw new BoardException("there is no part in the chosen origin position");
            }
            if (CurrentPlayer != Board.Piece(pos).Color)
            {
                throw new BoardException("the original piece chosen is not yours");
            }
            if (!Board.Piece(pos).ThereArePossibleMoves())
            {
                throw new BoardException("there are no possible moves for the chosen origin piece!");
            }
        }

        public void ValidateTargetPosition(Position origin, Position destiny)
        {
            if (!Board.Piece(origin).CanMoveTo(destiny))
            {
                throw new BoardException("Position destiny is insvalid");
            }
        }

        private void ChangeGame()
        {
           if(CurrentPlayer == Color.white)
            {
                CurrentPlayer = Color.black;
            }
            else
            {
                CurrentPlayer = Color.white;
            }
        }

        private void AddPiece()
        {
            Board.AddPiece(new Roock(Color.white, Board), new ChessPosition('a', 1).ToPosition());
            Board.AddPiece(new Horse(Color.white, Board), new ChessPosition('b', 1).ToPosition());
            Board.AddPiece(new Bishop(Color.white, Board), new ChessPosition('c', 1).ToPosition());
            Board.AddPiece(new Queen(Color.white, Board), new ChessPosition('d', 1).ToPosition());
            Board.AddPiece(new King(Color.white, Board), new ChessPosition('e', 1).ToPosition());
            Board.AddPiece(new Bishop(Color.white, Board), new ChessPosition('f', 1).ToPosition());
            Board.AddPiece(new Horse(Color.white, Board), new ChessPosition('g', 1).ToPosition());
            Board.AddPiece(new Roock(Color.white, Board), new ChessPosition('h', 1).ToPosition());
            Board.AddPiece(new Roock(Color.black, Board), new ChessPosition('a', 8).ToPosition());
            Board.AddPiece(new Horse(Color.black, Board), new ChessPosition('b', 8).ToPosition());
            Board.AddPiece(new Bishop(Color.black, Board), new ChessPosition('c', 8).ToPosition());
            Board.AddPiece(new Queen(Color.black, Board), new ChessPosition('d', 8).ToPosition());
            Board.AddPiece(new King(Color.black, Board), new ChessPosition('e', 8).ToPosition());
            Board.AddPiece(new Bishop(Color.black, Board), new ChessPosition('f', 8).ToPosition());
            Board.AddPiece(new Horse(Color.black, Board), new ChessPosition('g', 8).ToPosition());
            Board.AddPiece(new Roock(Color.black, Board), new ChessPosition('h', 8).ToPosition());


        }
    }
}
