using System.IO;
using System.IO.Compression;
using System.Text;

namespace CanErectors.Common
{
    public static class StreamExtensions
    {
        public static MemoryStream ToMemoryStream(this System.IO.Stream stream)
        {
            if (stream.GetType() == typeof(MemoryStream))
                return (MemoryStream)stream;

            MemoryStream memoryStream = new MemoryStream();

            byte[] buffer = new byte[4096];
            int numBytesRead;

            while ((numBytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                memoryStream.Write(buffer, 0, numBytesRead);
            }

            return memoryStream;
        }

        public static string GetString(this System.IO.Stream stream)
        {
            MemoryStream memoryStream = stream.ToMemoryStream();

            var bytes = memoryStream.ToArray();

            return Encoding.UTF8.GetString(bytes);
        }

        public static MemoryStream GZipDecompress(this System.IO.Stream compressedStream)
        {
            MemoryStream ms = new MemoryStream();

            if (compressedStream.CanSeek)
                compressedStream.Seek(0, SeekOrigin.Begin);

            GZipStream gzip = new GZipStream(compressedStream, CompressionMode.Decompress, true);

            byte[] buffer = new byte[4096];
            int numRead;

            while ((numRead = gzip.Read(buffer, 0, buffer.Length)) != 0)
            {
                ms.Write(buffer, 0, numRead);
            }

            gzip.Flush();
            gzip.Close();

            ms.Seek(0, SeekOrigin.Begin);

            return ms;
        }

        public static MemoryStream GZipCompress(this System.IO.Stream uncompressedStream)
        {
            MemoryStream ms = new MemoryStream();

            GZipStream gzip = new GZipStream(ms, CompressionMode.Compress, true);

            if (uncompressedStream.CanSeek)
                uncompressedStream.Seek(0, SeekOrigin.Begin);

            byte[] buffer = new byte[4096];
            int numRead;

            while ((numRead = uncompressedStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                gzip.Write(buffer, 0, numRead);
            }

            gzip.Flush();
            gzip.Close();

            ms.Seek(0, SeekOrigin.Begin);

            return ms;
        }
    }
}
