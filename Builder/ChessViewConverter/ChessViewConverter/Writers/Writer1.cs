using System;
using System.Collections.Generic;
using System.IO;

namespace ChessViewConverter.Writers
{
    public class Writer1 : IWriter
    {
        private string path;

        private List<Char[]> board;

        public Writer1(string path)
        {
            this.path = path;
            this.board = new List<char[]>();
            for (int i = 0; i <= 8; ++i)
            {
                var line = new char[] { '.','.', '.', '.', '.', '.', '.', '.' };
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
                board[figure.row][figure.column] = figure.name;
            }
        }
    }
}
