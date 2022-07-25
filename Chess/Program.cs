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
                ChessGame game = new ChessGame();

                while (!game.Finished)
                {
                    try
                    {
                        //print board
                        Console.Clear();
                        Screen.PrintBoard(game.Board);
                        Console.WriteLine($"\nShift: {game.Shift} ");
                        Console.WriteLine($"\nwaiting for play {game.CurrentPlayer} ");

                        Console.Write("\nOrigin: ");
                        Position origin = Screen.ReadPositionChess().ToPosition();
                        game.ValidatePositionOrigin(origin);

                        bool[,] PossiblePositions = game.Board.Piece(origin).PossibelMoves();

                        Console.Clear();
                        Screen.PrintBoard(game.Board, PossiblePositions);

                        Console.Write("Destiny: ");
                        Position destiny = Screen.ReadPositionChess().ToPosition();
                        game.ValidateTargetPosition(origin, destiny);

                        game.MakeMove(origin, destiny);
                    }
                    catch(BoardException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.Write("\n type enter to play again");
                        Console.ReadLine();
                    }

                }




                Screen.PrintBoard(game.Board);
            }
            catch (BoardException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
