using board;
using System;
using System.Collections.Generic;
using System.Text;

namespace chess
{
    class Pawn : Piece
    {
        private ChessGame game;
        public Pawn(Color color, Board board, ChessGame game) : base(color, board)
        {
            this.game = game;
        }
        public override string ToString()
        {
            return "P";
        }

        private bool ThereEnemy(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece != null && piece.Color != Color;
        }

        private bool Free(Position position)
        {
            return Board.Piece(position) == null;
        }
        public override bool[,] PossibelMoves()
        {

            bool[,] mat = new bool[Board.NumLines, Board.NumColumns];

            Position pos = new Position(0, 0);

            if (Color == Color.white)
            {
                pos.SetValues(pos.Line - 1, pos.Colunm);
                if (Board.PositionValid(pos) && Free(pos))
                {
                    mat[pos.Line, pos.Colunm] = true;
                }
                pos.SetValues(Position.Line - 2, Position.Colunm);
                Position p2 = new Position(Position.Line - 1, Position.Colunm);
                if (Board.PositionValid(p2) && Free(p2) && Board.PositionValid(pos) && Free(pos) && NumberMoves == 0)
                {
                    mat[pos.Line, pos.Colunm] = true;
                }
                pos.SetValues(Position.Line - 1, Position.Colunm - 1);
                if (Board.PositionValid(pos) && ThereEnemy(pos))
                {
                    mat[pos.Line, pos.Colunm] = true;
                }
                pos.SetValues(Position.Line - 1, Position.Colunm + 1);
                if (Board.PositionValid(pos) && ThereEnemy(pos))
                {
                    mat[pos.Line, pos.Colunm] = true;
                }

                if (Position.Line == 3)
                {
                    Position right = new Position(Position.Line, Position.Colunm - 1);
                    if (Board.PositionValid(right) && ThereEnemy(right) && Board.Piece(right) == game.vulneravelEnPassant)
                    {
                        mat[right.Line - 1, right.Colunm] = true;
                    }
                    Position left = new Position(Position.Line, Position.Colunm + 1);
                    if (Board.PositionValid(left) && ThereEnemy(left) && Board.Piece(left) == game.vulneravelEnPassant)
                    {
                        mat[left.Line - 1, left.Colunm] = true;
                    }
                }
            }
            else
            {
                pos.SetValues(Position.Line + 1, Position.Colunm);
                if (Board.PositionValid(pos) && Free(pos))
                {
                    mat[pos.Line, pos.Colunm] = true;
                }
                pos.SetValues(pos.Line + 2, pos.Colunm);
                Position p2 = new Position(Position.Line + 1, Position.Colunm);
                if (Board.PositionValid(p2) && Free(p2) && Board.PositionValid(pos) && Free(pos) && NumberMoves == 0)
                {
                    mat[pos.Line, pos.Colunm] = true;
                }
                pos.SetValues(Position.Line + 1, Position.Colunm - 1);
                if (Board.PositionValid(pos) && ThereEnemy(pos))
                {
                    mat[pos.Line, pos.Colunm] = true;
                }
                pos.SetValues(Position.Line + 1, Position.Colunm + 1);
                if (Board.PositionValid(pos) && ThereEnemy(pos))
                {
                    mat[pos.Line, pos.Colunm] = true;
                }

                if (Position.Line == 4)
                {
                    Position right = new Position(Position.Line, Position.Colunm - 1);
                    if (Board.PositionValid(right) && ThereEnemy(right) && Board.Piece(right) == game.vulneravelEnPassant)
                    {
                        mat[right.Line + 1, right.Colunm] = true;
                    }
                    Position left = new Position(Position.Line, Position.Colunm + 1);
                    if (Board.PositionValid(left) && ThereEnemy(left) && Board.Piece(left) == game.vulneravelEnPassant)
                    {
                        mat[left.Line + 1, left.Colunm] = true;
                    }
                }

               
            }
            return mat;
        }
    }
}