using board;
using chess;
using System;
using System.Collections.Generic;

namespace Chess
{
    class Screen
    {
        public static void PrintBoard(Board board)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("  a b c d e f g h");
            Console.ResetColor();

            for (int i = 0; i < board.NumLines; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(8 - i + " ");
                Console.ResetColor();

                for (int j = 0; j < board.NumColumns; j++)
                {

                    PrintPiece(board.Piece(i, j));
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("  a b c d e f g h");
            Console.ResetColor();
        }

        public static void PrintMatch(ChessGame game)
        {
            Screen.PrintBoard(game.Board);
            PrintCapturedPiece(game);
            Console.WriteLine($"\nShift: {game.Shift} ");
            Console.WriteLine($"\nwaiting for play {game.CurrentPlayer} ");
            if (game.Check)
            {
                Console.WriteLine("CHECK!");
            }
        }

        public static void PrintCapturedPiece(ChessGame game)
        {
            Console.WriteLine("\nCaptured pieces: ");
            Console.Write("Whites: ");
            PrintSet(game.CapturedPieces(Color.white));
            Console.WriteLine();
            Console.Write("Blacks: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            PrintSet(game.CapturedPieces(Color.black));
            Console.ForegroundColor = aux;

        }

        public static void PrintSet(HashSet<Piece> set)
        {
            Console.Write("[");
            foreach(Piece piece in set)
            {
                Console.Write(piece + " ");
            }
            Console.Write("] ");
        }
        public static void PrintBoard(Board board, bool[,] possiblePositions)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor backgroundChanged = ConsoleColor.Red;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("  a b c d e f g h");
            Console.ResetColor();

            for (int i = 0; i < board.NumLines; i++)
            {

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(8 - i + " ");
                Console.ResetColor();

                for (int j = 0; j < board.NumColumns; j++)
                {
                    if (possiblePositions[i, j])
                    {
                        Console.BackgroundColor = backgroundChanged;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackground;

                    }
                    PrintPiece(board.Piece(i, j));
                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("  a b c d e f g h");
            Console.ResetColor();

            Console.BackgroundColor = originalBackground;
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
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.white)
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
                Console.Write(" ");
            }
        }
    }
}
