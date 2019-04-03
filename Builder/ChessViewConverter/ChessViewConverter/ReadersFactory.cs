using ChessViewConverter.Readers;

namespace ChessViewConverter
{
    public class ReadersFactory
    {
        private string path { get; set; }

        public ReadersFactory(string path)
        {
            this.path = path;
        }
        
        /// <summary>
        /// create new reader
        /// </summary>
        /// <param name="className">class Name which object you want</param>
        /// <returns>Reader Object</returns>
        public dynamic CreateReader(string className)
        {
            switch (className)
            {
                case "Reader1":
                    return new Reader1(this.path);
                case "Reader2":
                    return new Reader2(this.path);
                case "Reader3":
                    return new Reader3(this.path);
            }
            return null;
        }
    }
}


