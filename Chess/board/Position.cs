﻿namespace board
{
    class Position
    {
        public int Line { get; set; }
        public int Colunm { get; set; }

        public Position(int line, int colunm)
        {
            Line = line;
            Colunm = colunm;
        }
    }
}