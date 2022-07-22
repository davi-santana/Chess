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

                    Console.Clear();
                    Screen.PrintBoard(game.board);

                    Console.Write("\n Origin: ");
                    Position origin = Screen.ReadPositionChess().ToPosition();

                    bool[,] PossiblePositions = game.board.Piece(origin).PossibelMoves(); 

                    Console.Clear();
                    Screen.PrintBoard(game.board, PossiblePositions);

                    Console.Write("Destiny: ");
                    Position destiny = Screen.ReadPositionChess().ToPosition();

                    game.ExecuteMovement(origin, destiny);

                }

                


                Screen.PrintBoard(game.board);
            }
            catch(BoardException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
