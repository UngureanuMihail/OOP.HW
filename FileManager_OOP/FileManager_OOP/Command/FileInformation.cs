using FileManager.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Commands
{
    internal class FileInformation : FileManagerCommand
    {
        private readonly IUserInterface _UserInterface;
        private readonly FileManagerLogic _FileManager;
        public override string Description => "To count the number of words in a file";

        public FileInformation(IUserInterface UserInterface, FileManagerLogic FileManager)
        {
            _UserInterface = UserInterface;
            _FileManager = FileManager;
        }

        public override void Execute(string[] args)
        {
            using StreamReader sr = new StreamReader(args[1]);
            int words = 0;
            int lines = 0;
            int paragraph = 0;
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                lines++;
                if (line[0] == '\t')
                {
                    paragraph++;
                }
                var count = line.Split(' ').Length;
                words += count;
            };
            FileInfo fileInfo = new FileInfo(args[1]);
            _UserInterface.WriteLine($"Wordks in document: {words}\n" +
                                $"Size of document: {fileInfo.Length}\n" +
                                $"Lines in document: {lines}\n" +
                                $"Paragraphs in document: {paragraph}");
        }
    }
}