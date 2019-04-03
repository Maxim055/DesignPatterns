using System;
using System.Collections.Generic;
using System.IO;

namespace ChessViewConverter.Readers
{
    public class Reader2 : IReader
    {
        private List<ChessFigureCoords> result = new List<ChessFigureCoords>();

        private string path;

        private string row { get; set; }

        private StreamReader reader { get; set; }

        public Reader2(string path)
        {
            this.path = path;
            this.reader = Open();
        }

        /// <summary>
        /// Reads next row
        /// </summary>
        /// <returns>true if has row, false if no row to read</returns>
        public bool Next()
        {
            if ((this.row = this.reader.ReadLine()) != null)
            {
                return true;
            }
            this.reader.Close();
            return false;
        }

        /// <summary>
        /// converts row string to List
        /// </summary>
        /// <returns>List of coordinates</returns>
        public List<ChessFigureCoords> Read()
        {
            var result = new List<ChessFigureCoords>();
            if (this.row != string.Empty)
            {
                var spltd = this.row.Split(' ');
                int x = 0;
                int y = 0;
                int.TryParse(spltd[1], out x);
                int.TryParse(spltd[2], out y);

                var figure = new ChessFigureCoords(spltd[0][0], x, y);

                result.Add(figure);
            }
            return result;
        }

        /// <summary>
        /// opens file
        /// </summary>
        /// <returns>stream for reading from file</returns>
        private StreamReader Open()
        {
            try
            {
                var sr = new StreamReader(this.path);
                return sr;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
