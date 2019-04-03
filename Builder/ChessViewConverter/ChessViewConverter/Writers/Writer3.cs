using System;
using System.Collections.Generic;
using System.IO;

namespace ChessViewConverter.Writers
{
    public class Writer3 : IWriter
    {
        private string path;

        private List<Char[]> board;

        public Writer3(string path)
        {
            this.path = path;
            this.board = new List<char[]>();
            for (int i = 0; i <= 8; ++i)
            {
                var line = new char[] { '.', '.', '.', '.', '.', '.', '.', '.' };
                this.board.Add(line);
            }
            var emptyLine = new char[] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
            this.board.Add(emptyLine);
            for (int i = 0; i <= 8; ++i)
            {
                var line = new char[] { '.', '.', '.', '.', '.', '.', '.', '.' };
                this.board.Add(line);
            }
        }

        public void finalize()
        {
            using (var stream = new StreamWriter(this.path))
            {
                foreach (var row in this.board)
                {
                    if (this.board.IndexOf(row) != 0)
                    {
                        stream.WriteLine(new string(row));
                    }
                }
            }
        }

        public void write(List<ChessFigureCoords> data)
        {
            foreach (var figure in data)
            {
                if (char.IsLower(figure.name))
                {
                    board[figure.row + 9][figure.column] = figure.name;
                }
                else
                {
                    board[figure.row][figure.column] = figure.name;
                }
            }
        }
    }
}
