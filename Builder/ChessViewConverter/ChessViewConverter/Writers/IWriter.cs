using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessViewConverter.Writers
{
    public interface IWriter
    {
        /// <summary>
        /// Writes in memory or in file
        /// </summary>
        /// <param name="data">Chess figure coordinates</param>
        void write(List<ChessFigureCoords> data);

        /// <summary>
        /// Writes all data from memory to file, and close it
        /// </summary>
        void finalize();
    }
}
