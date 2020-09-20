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
            sourceFile.Close();
            destFile.Close();
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Starting to compress file \nMmmmm\nMmmmmmm");
            CompressFile("C:\\All\\newfile.txt", "C:\\All\\newfile.txt.gz");
            Console.WriteLine("Compression done");
        }
    }
}
