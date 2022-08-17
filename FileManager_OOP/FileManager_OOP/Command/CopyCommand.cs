using FileManager.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Commands
{
    internal class CopyCommand : FileManagerCommand
    {
        private readonly IUserInterface _UserInterface;
        private readonly FileManagerLogic _FileManager;
        public override string Description => "To copy files";

        public CopyCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
        {
            _UserInterface = UserInterface;
            _FileManager = FileManager;
        }

        static void CopyDir(string FromDir, string ToDir)
        {
            Directory.CreateDirectory(ToDir);
            foreach (string first in Directory.EnumerateFiles(FromDir))
            {
                var second = Path.Combine(ToDir, Path.GetFileName(first));
                File.Copy(first, second);
            }
            foreach (string s in Directory.EnumerateDirectories(FromDir))
            {
                CopyDir(s, ToDir + "\\" + Path.GetFileName(s));
            }
        }


        public override void Execute(string[] args)
        {

            if (args.Length > 1 && File.Exists(args[1]))
            {
                File.Copy(args[1], args[2]);
            }
            else if (args.Length > 1 && Directory.Exists(args[1]) && Directory.Exists(args[2]))
            {
                CopyDir(args[1], args[2]);
            }
        }
    }
}
