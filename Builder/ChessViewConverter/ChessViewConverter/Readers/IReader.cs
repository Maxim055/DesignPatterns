using System.Collections.Generic;

namespace ChessViewConverter
{
    interface IReader
    {
        /// <summary>
        /// Read next row if it exists
        /// </summary>
        /// <returns>true if has row</returns>
        bool Next();

        /// <summary>
        /// Read the row and converts it
        /// </summary>
        /// <returns>returns List of chess figures</returns>
        List<ChessFigureCoords> Read();
    }
}
