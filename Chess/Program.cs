using Chess.board;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new board.Board(8, 8);

            Screen.PrintBoard(board);
        }
    }
}
