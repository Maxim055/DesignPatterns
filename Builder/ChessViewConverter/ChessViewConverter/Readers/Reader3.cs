using System;
using System.Collections.Generic;
using System.IO;

namespace ChessViewConverter.Readers
{
    public class Reader3 : IReader
    {
        private List<ChessFigureCoords> result = new List<ChessFigureCoords>();
        private string path;

        private StreamReader reader { get; set; }

        private string row { get; set; }

        private int counter { get; set; }
        public Reader3(string path)
        {
            this.path = path;
            this.reader = Open();
            this.counter = 0;
        }

        /// <summary>
        /// Reads next row
        /// </summary>
        /// <returns>true if has row, false if no row to read</returns>
        public bool Next()
        {
            if ((this.row = this.reader.ReadLine()) != null)
            {
                this.counter++;
                if (this.counter > 8)
                {
                    this.counter = 0;
                }
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
            for (int i = 0; i < this.row.Length; ++i)
            {
                if (row[i] != '.')
                {
                    var figure = new ChessFigureCoords(row[i], this.counter, i + 1);
                    result.Add(figure);
                }
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
