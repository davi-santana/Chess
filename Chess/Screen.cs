using board;
using System;

namespace Chess
{
    class Screen
    {
        public static void PrintBoard(Board board)
        {
            for(int i=0; i<board.NumLines; i++)
            {
                Console.Write(8 - i + " ");
                for(int j=0; j<board.NumColumns; j++)
                {
                    if (board.Piece(i,j)==null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        PrintPiece(board.Piece(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

      public static void PrintPiece(Piece piece)
        {
            if(piece.Color == Color.white)
            {
                Console.WriteLine(piece);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }
    }
}
