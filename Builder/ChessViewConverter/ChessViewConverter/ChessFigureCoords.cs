namespace ChessViewConverter
{
    public class ChessFigureCoords
    {
        public char name { get; set; }

        public int row { get; set; }

        public int column { get; set; }

        public ChessFigureCoords(char name, int row, int column)
        {
            this.name = name;
            this.row = row;
            this.column = column;
        }
    }
}
