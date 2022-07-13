using board;
using chess;
using System;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Board board = new Board(8, 8);

                board.AddPiece(new Tower(Color.black, board), new Position(0, 0));
                board.AddPiece(new Tower(Color.black, board), new Position(1, 3));
                board.AddPiece(new King(Color.white, board), new Position(1, 4));

                Screen.PrintBoard(board);
            }
            catch(BoardException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
