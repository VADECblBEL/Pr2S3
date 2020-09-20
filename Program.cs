using System;
using System.IO;
using System.IO.Compression;

namespace Pr2S3
{
    class Program
    {
        static void CompressFile(string inFilename, string outFilename)
        {
            FileStream sourceFile = File.OpenRead(inFilename);
            FileStream destFile = File.Create(outFilename);
            GZipStream compStream = new GZipStream(destFile, CompressionMode.Compress);

            int theByte = sourceFile.ReadByte();
            while (theByte != -1)
            {
                compStream.WriteByte((byte)theByte);
                theByte = sourceFile.ReadByte();
            }

            compStream.Close();
        }

        static void UncompressFile(string InFilename, string OutFilename)
        {
            FileStream sourceFile = File.OpenRead(InFilename);
            FileStream destFile = File.Create(OutFilename);
            GZipStream compStream = new GZipStream(sourceFile, CompressionMode.Decompress);

            int theByte = compStream.ReadByte();
            while (theByte != -1)
            {
                destFile.WriteByte((byte)theByte);
                theByte = compStream.ReadByte();
            }

            compStream.Close();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Starting to compress file \nMmmmm\nMmmmmmm");
            CompressFile("C:\\All\\newfile.txt", "C:\\All\\newfile.txt.gz");
            Console.WriteLine("Compression done");
            Console.WriteLine("Oh yes, decompression. Let's do it");
            Console.WriteLine("Mmmmmmmm \nMmmmmMMmMmMm\nMMmmmmmMmm");
            UncompressFile("C:\\All\\newfile.txt.gz", "C:\\All\\newfile.txt.test");
            Console.WriteLine("Decompression done. You are welcome. Goodbye");
        }
    }
}
