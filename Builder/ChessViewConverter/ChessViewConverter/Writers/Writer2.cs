using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessViewConverter.Writers
{
    public class Writer2 : IWriter
    {
        private string path;
        
        private StreamWriter stream;

        public Writer2(string path)
        {
            this.path = path;
            this.stream = new StreamWriter(this.path);
        }

        public void finalize()
        {
            this.stream.Close();
        }

        public void write(List<ChessFigureCoords> data)
        {
            foreach (var figure in data)
            {
                var st = $"{figure.name} {figure.row} {figure.column}";
                this.stream.WriteLine(st);
            }
        }
    }
}
