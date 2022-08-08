using board;
using System;
using System.Collections.Generic;
using System.Text;

namespace chess
{
    class Queen : Piece
    {
        public Queen(Color color, Board board) : base(color, board)
        {
        }

        private bool CanMove(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibelMoves()
        {
            bool[,] mat = new bool[Board.NumLines, Board.NumColumns];

            Position position = new Position(0, 0);

            
            position.SetValues(Position.Line, Position.Colunm-1);
            while (Board.PositionValid(position) && CanMove(position))
            {
                mat[position.Line, position.Colunm] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.SetValues(position.Line, position.Colunm -1);
            } 
            
            position.SetValues(Position.Line, Position.Colunm+1);
            while (Board.PositionValid(position) && CanMove(position))
            {
                mat[position.Line, position.Colunm] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.SetValues(position.Line, position.Colunm +1);
            }
            
            position.SetValues(Position.Line-1, Position.Colunm);
            while (Board.PositionValid(position) && CanMove(position))
            {
                mat[position.Line, position.Colunm] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.SetValues(position.Line-1, position.Colunm );
            }
            
            position.SetValues(Position.Line+1, Position.Colunm);
            while (Board.PositionValid(position) && CanMove(position))
            {
                mat[position.Line, position.Colunm] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.SetValues(position.Line+1, position.Colunm );
            } 
            
            position.SetValues(Position.Line-1, Position.Colunm-1);
            while (Board.PositionValid(position) && CanMove(position))
            {
                mat[position.Line, position.Colunm] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.SetValues(position.Line-1, position.Colunm-1 );
            }
            
            position.SetValues(Position.Line-1, Position.Colunm+1);
            while (Board.PositionValid(position) && CanMove(position))
            {
                mat[position.Line, position.Colunm] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.SetValues(position.Line-1, position.Colunm+1 );
            }
            
            position.SetValues(Position.Line+1, Position.Colunm+1);
            while (Board.PositionValid(position) && CanMove(position))
            {
                mat[position.Line, position.Colunm] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.SetValues(position.Line+1, position.Colunm+1 );
            }
            
            position.SetValues(Position.Line+1, Position.Colunm-1);
            while (Board.PositionValid(position) && CanMove(position))
            {
                mat[position.Line, position.Colunm] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.SetValues(position.Line+1, position.Colunm-1 );
            }
            return mat;
        }

        public override string ToString()
        {
            return "Q";
        }
    }
}
