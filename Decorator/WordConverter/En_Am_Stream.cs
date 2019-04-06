using System;
using System.IO;

namespace WordConverter
{
    public class En_Am_Stream : Stream
    {
        #region Props
        private readonly Stream parentStream;

        public const long DefaultBufferSize = 4096;

        private long position = 0;

        private byte[] buff = new byte[DefaultBufferSize];

        #endregion

        #region Ctor
        public En_Am_Stream(Stream st)
        {
            this.parentStream = st;
        }
        #endregion

        #region StreamImplemetation
        public override bool CanRead => this.parentStream.CanRead;

        public override bool CanSeek => this.parentStream.CanSeek;

        public override bool CanWrite => this.parentStream.CanWrite;

        public override long Length => DefaultBufferSize;

        public override long Position { get => this.position; set => this.position = value; }

        public override void Flush()
        {
            this.parentStream.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (buffer == null)
                throw new ArgumentNullException("buffer", "buffer is null");
            if (count < 0 || offset < 0)
                throw new ArgumentException("offset or count is negative.");
            if (offset + count > buffer.Length)
                throw new IndexOutOfRangeException("The sum of offset and count is larger than the buffer length.");

            int readedBytes = 0;

            if (this.position < this.Length)
            {
                for (int i = offset; i < offset + count; ++i)
                {
                    buffer[i] = this.buff[this.position];
                    this.position++;
                    readedBytes++;
                }
            }
            if (this.parentStream != null)
            {
                this.parentStream.Read(this.buff, (int)this.position - count, count);
                this.position -= count;
            }
            return readedBytes;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            int writed = 0;
            if (buffer == null)
                throw new ArgumentNullException("buffer", "buffer is null");
            if (count < 0 || offset < 0)
                throw new ArgumentException("offset or count is negative.");
            if (offset + count > buffer.Length)
                throw new IndexOutOfRangeException("The sum of offset and count is larger than the buffer length.");

            for (int i = offset; i < offset + count; ++i)
            {
                try
                {
                    var c = Dict.En_AmDict[char.ToLower((char)buffer[i])];
                    System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                    Byte[] bytes = encoding.GetBytes(c.ToString());
                    foreach (var ch in bytes)
                    {
                        if (this.position == DefaultBufferSize)
                        {
                            this.parentStream.Write(this.buff, (int)this.position - writed, writed);
                            this.position -= writed;
                        }
                        this.buff[this.position] = ch;
                        this.position++;
                        writed++;
                    }
                }
                catch (Exception ex)
                {
                    this.buff[this.position] = buffer[i];
                    this.position++;
                }
            }
            if (this.parentStream != null)
            {
                this.parentStream.Write(this.buff, (int)this.position - count, count);
                this.position -= count;
            }
        }
        #endregion
    }
}
