using System;

namespace Patterns
{
    class Bridge
    {
        static void _Main(string[] args)
        {
            File apk = new File();

            IFileSender fileSender = new ViberFileSender(apk, new Zip());
            fileSender.SendFile();

            Console.WriteLine();

            fileSender.Archiver = new Rar();
            fileSender.SendFile();

            Console.ReadLine();
        }
    }

    interface IFileSender
    {
        File File { get; set; }        
        IArchiver Archiver { get; set; }// оце, власне, і є міст

        void SendFile();        
    }

    class ViberFileSender : IFileSender
    {
        public File File { get; set; }
        public IArchiver Archiver { get; set; }

        public ViberFileSender(File file, IArchiver archiver)
        {
            File = file;
            Archiver = archiver;
        }

        public void SendFile()
        {
            Archiver.Compress(File);
            Console.WriteLine("Файл надіслано в Viber");
        }
    }

    interface IArchiver
    {
        File Compress(File file);
    }

    class Zip : IArchiver
    {        
        public File Compress(File file)
        {
            Console.WriteLine("Файл стиснено в .zip");
            return file;
        }
    }

    class Rar : IArchiver
    {
        public File Compress(File file)
        {
            Console.WriteLine("Файл стиснено в .rar");
            return file;
        }
    }

    class File
    {

    }
}
