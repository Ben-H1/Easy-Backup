using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBackup
{
    class Program
    {
        private static string versionNumber = "0.1";
        private static string backup;

        static void Main(string[] args)
        {
            if (args.Length != 0) {
                int argIndex = 0;
                bool argsOk = true;

                while (argIndex < args.Length && argsOk) {
                    switch(args[argIndex]) {
                        case "--backup":
                            argIndex++;
                            if (argIndex < args.Length) {
                                backup = args[argIndex];
                                if (backup != "all" && backup != "folder") {
                                    Console.Error.WriteLine($"Invalid backup argument: {args[argIndex]}");
                                    argsOk = false;
                                }
                                argIndex++;
                            } else {
                                Console.Error.WriteLine("Invalid backup argument");
                                argsOk = false;
                            }
                            break;
                        default:
                            Console.Error.WriteLine($"Unknown argument: {args[argIndex]}");
                            argsOk = false;
                            break;
                    }
                }

                if (! argsOk) {
                    Environment.Exit(0);
                }
            }

            switch (backup) {
                case "all":
                    backupEverything();
                    break;

                case "folder":
                    backupSingleFolder();
                    break;

                default:
                    displayMenu();
                    break;
            }
        }

        private static void displayMenu()
        {
            Console.Clear();
            displayLogo();
            Console.WriteLine();

            Console.WriteLine("1. Backup everything");
            Console.WriteLine("2. Backup a single folder");
            Console.WriteLine("3. Exit");
            Console.WriteLine();

            Console.Write("Pick an option: ");
            string input = Console.ReadLine();

            switch (input) {
                case "1":
                    backupEverything();
                    break;

                case "2":
                    backupSingleFolder();
                    break;

                case "3":
                    Environment.Exit(0);
                    break;

                default:
                    displayMenu();
                    break;
            }
        }

        private static void displayLogo()
        {
            Console.WriteLine(@"    ______                    ____             __             ");
            Console.WriteLine(@"   / ____/___ ________  __   / __ )____ ______/ /____  ______ ");
            Console.WriteLine(@"  / __/ / __ `/ ___/ / / /  / __  / __ `/ ___/ //_/ / / / __ \");
            Console.WriteLine(@" / /___/ /_/ (__  ) /_/ /  / /_/ / /_/ / /__/ ,< / /_/ / /_/ /");
            Console.WriteLine(@"/_____/\__,_/____/\__, /  /_____/\__,_/\___/_/|_|\__,_/ .___/ ");
            Console.WriteLine($"                 /____/                              /_/      v{versionNumber} by Ben Hawthorn");
        }

        private static void backupEverything()
        {
            Console.Clear();
            displayLogo();
            Console.WriteLine();

            string input = Console.ReadLine();
        }

        private static void backupSingleFolder()
        {
            Console.Clear();
            displayLogo();
            Console.WriteLine();

           string input = Console.ReadLine();
        }
    }
}
