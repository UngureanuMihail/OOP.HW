using FileManager.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Commands
{

    internal class DeleteCommand : FileManagerCommand
    {
        private readonly IUserInterface _UserInterface;
        private readonly FileManagerLogic _FileManager;
        public override string Description => "To delete the path";

        public DeleteCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
        {
            _UserInterface = UserInterface;
            _FileManager = FileManager;
        }

        public override void Execute(string[] args)
        {
            if (args.Length > 1)
            {
                if (File.Exists(args[1]))
                {
                    File.Delete(args[1]);
                }
                else if (Directory.Exists(args[1]))
                {
                    try
                    {
                        Directory.Delete(args[1], true);
                    }
                    catch (DirectoryNotFoundException ex)
                    {
                        Console.WriteLine("Directory is not found: " + ex.Message);
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        Console.WriteLine("Acces denied: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
        }
    }
}