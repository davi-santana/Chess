using board;
using System;
using System.Collections.Generic;

namespace chess
{
    class ChessGame
    {
        public Board Board { get; private set; }
        public int Shift { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }
        public bool Check { get; private set; }
        public Piece vulneravelEnPassant { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;


        public ChessGame()
        {
            Board = new Board(8, 8);
            Shift = 1;
            CurrentPlayer = Color.white;
            Finished = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            vulneravelEnPassant = null;
            AddPiece();
        }

        public Piece ExecuteMovement(Position origin, Position destiny)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.IncreaseMovements();
            Board.RemovePiece(destiny);
            Piece capturePiece = Board.RemovePiece(destiny);
            Check = false;
            Board.AddPiece(piece, destiny);
            if (capturePiece != null)
            {
                captured.Add(capturePiece);
            }
            return capturePiece;
        }
        public void UndoTheMove(Position origin, Position destiny, Piece capturePiece)
        {
            Piece piece = Board.RemovePiece(destiny);
            piece.DecrementMovements();
            if (capturePiece != null)
            {
                Board.AddPiece(capturePiece, destiny);
                captured.Remove(piece);
            }
            Board.AddPiece(piece, origin);
        }
        public void MakeMove(Position origin, Position destiny)
        {

            Piece capturePiece = ExecuteMovement(origin, destiny);
            if (IsInCheck(CurrentPlayer))
            {
                UndoTheMove(origin, destiny, capturePiece);
                throw new BoardException("you can't put yourself in check");
            }
            if (IsInCheck(Adversary(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }

            if (CheckTest(Adversary(CurrentPlayer)))
            {
                Finished = true;
            }
            else
            {
                Shift++;
                ChangeGame();
            }
        }

        public void ValidatePositionOrigin(Position pos)
        {
            if (Board.Piece(pos) == null)
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
            if (CurrentPlayer == Color.white)
            {
                CurrentPlayer = Color.black;
            }
            else
            {
                CurrentPlayer = Color.white;
            }
        }

        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in captured)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        private Color Adversary(Color color)
        {
            if (color == Color.white)
            {
                return Color.black;
            }
            else
            {
                return Color.white;
            }

        }

        private Piece King(Color color)
        {
            foreach (Piece piece in PiecesInPlay(color))
            {
                if (piece is King)
                {
                    return piece;
                }
            }
            return null;
        }

        public bool IsInCheck(Color color)
        {
            Piece K = King(color);
            if (K == null)
            {
                throw new BoardException("there is no king of that color" + color + "on the board");
            }
            foreach (Piece piece in PiecesInPlay(Adversary(color)))
            {
                bool[,] mat = piece.PossibelMoves();
                if (mat[K.Position.Line, K.Position.Colunm])
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckTest(Color color)
        {
            if (!IsInCheck(color))
            {
                return false;
            }
            foreach (Piece x in PiecesInPlay(color))
            {
                bool[,] mat = x.PossibelMoves();
                for (int i = 0; i < Board.NumLines; i++)
                {
                    for (int j = 0; j < Board.NumColumns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = x.Position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = ExecuteMovement(x.Position, new Position(i, j));
                            bool CheckTest = IsInCheck(color);
                            UndoTheMove(x.Position, destiny, capturedPiece);
                            if (!CheckTest)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        public HashSet<Piece> PiecesInPlay(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in pieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }

        public void AddNewPiece(char column, int line, Piece piece)
        {
            Board.AddPiece(piece, new ChessPosition(column, line).ToPosition());
            pieces.Add(piece);
        }

        private void AddPiece()
        {
            //white Piece
            AddNewPiece('a', 1, new Roock(Color.white, Board));
            AddNewPiece('b', 1, new Horse(Color.white, Board));
            AddNewPiece('c', 1, new Bishop(Color.white, Board));
            AddNewPiece('d', 1, new Queen(Color.white, Board));
            AddNewPiece('e', 1, new King(Color.white, Board));
            AddNewPiece('f', 1, new Bishop(Color.white, Board));
            AddNewPiece('g', 1, new Horse(Color.white, Board));
            AddNewPiece('h', 1, new Roock(Color.white, Board));
            AddNewPiece('a', 2, new Pawn(Color.white, Board, this));
            AddNewPiece('b', 2, new Pawn(Color.white, Board, this));
            AddNewPiece('c', 2, new Pawn(Color.white, Board, this));
            AddNewPiece('d', 2, new Pawn(Color.white, Board, this));
            AddNewPiece('e', 2, new Pawn(Color.white, Board, this));
            AddNewPiece('f', 2, new Pawn(Color.white, Board, this));
            AddNewPiece('g', 2, new Pawn(Color.white, Board, this));
            AddNewPiece('h', 2, new Pawn(Color.white, Board, this));


            //Black pieces 
            AddNewPiece('a', 8, new Roock(Color.black, Board));
            AddNewPiece('b', 8, new Horse(Color.black, Board));
            AddNewPiece('c', 8, new Bishop(Color.black, Board));
            AddNewPiece('d', 8, new Queen(Color.black, Board));
            AddNewPiece('e', 8, new King(Color.black, Board));
            AddNewPiece('f', 8, new Bishop(Color.black, Board));
            AddNewPiece('g', 8, new Horse(Color.black, Board));
            AddNewPiece('h', 8, new Roock(Color.black, Board));
            AddNewPiece('a', 7, new Pawn(Color.black, Board, this));
            AddNewPiece('b', 7, new Pawn(Color.black, Board, this));
            AddNewPiece('c', 7, new Pawn(Color.black, Board, this));
            AddNewPiece('d', 7, new Pawn(Color.black, Board, this));
            AddNewPiece('e', 7, new Pawn(Color.black, Board, this));
            AddNewPiece('f', 7, new Pawn(Color.black, Board, this));
            AddNewPiece('g', 7, new Pawn(Color.black, Board, this));
            AddNewPiece('h', 7, new Pawn(Color.black, Board, this));



        }
    }
}
