using Chess.board;
using System;

namespace Chess
{
    class Screen
    {
        public static void PrintBoard(Board board)
        {
            for(int i=0; i<board.NumLines; i++)
            {
                for(int j=0; j<board.NumColumns; j++)
                {
                    if (board.piece(i,j)==null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(board.piece(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
