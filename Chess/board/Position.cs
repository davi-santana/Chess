namespace board
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

        public void SetValues(int line, int colunm)
        {
            Line = line;
            Colunm = colunm;
        }
        public override string ToString()
        {
            return Line
                + ", "
                + Colunm;
        }
    }
}
