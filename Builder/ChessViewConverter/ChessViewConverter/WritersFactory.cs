using ChessViewConverter.Writers;

namespace ChessViewConverter
{
    public class WritersFactory
    {
        private string path { get; set; }

        public WritersFactory(string path)
        {
            this.path = path;
        }

        /// <summary>
        /// create new writer
        /// </summary>
        /// <param name="className">writer class name</param>
        /// <returns>writer object</returns>
        public dynamic CreateWriter(string className)
        {
            switch (className)
            {
                case "Writer1":
                    return new Writer1(this.path);
                case "Writer2":
                    return new Writer2(this.path);
                case "Writer3":
                    return new Writer3(this.path);
            }
            return null;
        }
    }
}
