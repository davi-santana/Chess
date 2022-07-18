using board;
using chess;
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

        public static ChessPosition ReadPositionChess()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");

            return new ChessPosition(column, line);


        }

      public static void PrintPiece(Piece piece)
        {
            if(piece.Color == Color.white)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }
    }
}
