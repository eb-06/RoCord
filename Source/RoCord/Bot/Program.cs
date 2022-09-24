using System;
using System.IO;

namespace RoCord
{
    class Program
    {
        public static void Main()
        {
            Console.Title = "RoCord";
            if (Directory.Exists("bin/"))
            {
                if (string.IsNullOrEmpty((string)Config.Read("token")))
                {
                    Console.WriteLine("[ERROR]: Failed to find bot token in 'config.json'.", Console.ForegroundColor = ConsoleColor.Red);
                    Console.Write("[INPUT]: Insert new bot token: ", Console.ForegroundColor = ConsoleColor.Blue);
                    Console.ResetColor();
                    Index.NewToken = Console.ReadLine();
                    Config.Write("token", Index.NewToken);
                    Console.WriteLine("[SUCCESS]: Token saved!", Console.ForegroundColor = ConsoleColor.Green);
                    Console.WriteLine("[PROCESSING]: Loading bot...", Console.ForegroundColor = ConsoleColor.Yellow);
                    Console.ResetColor();
                    new Backend().RunBot((string)Config.Read("token")).GetAwaiter().GetResult();
                }
                else
                {
                    Console.WriteLine("[OPTION 1]: Load previous bot data. \n[OPTION 2]: Change bot token.", Console.ForegroundColor = ConsoleColor.DarkMagenta);
                    Console.Write("[INPUT]: OPTION: ", Console.ForegroundColor = ConsoleColor.Blue);
                    Console.ResetColor();
                    var Option = Console.ReadLine();
                    switch (Option)
                    {
                        case "1":
                            Console.WriteLine("[PROCESSING]: Loading bot...", Console.ForegroundColor = ConsoleColor.Yellow);
                            new Backend().RunBot((string)Config.Read("token")).GetAwaiter().GetResult();
                            break;
                        case "2":
                            Console.Write("[INPUT]: Insert new bot token: ", Console.ForegroundColor = ConsoleColor.Blue);
                            Console.ResetColor();
                            Index.NewToken = Console.ReadLine();
                            Config.Write("token", Index.NewToken);
                            Console.WriteLine("[SUCCESS]: Token saved!", Console.ForegroundColor = ConsoleColor.Green);
                            Console.WriteLine("[PROCESSING]: Loading bot...", Console.ForegroundColor = ConsoleColor.Yellow);
                            new Backend().RunBot((string)Config.Read("token")).GetAwaiter().GetResult();
                            break;
                        default:
                            Console.WriteLine("[ERROR] Invalid option! Press any key to exit.", Console.ForegroundColor = ConsoleColor.Red);
                            Console.ReadKey();
                            break;
                    }
                }
            }
            else
            {
                Config.Create();
                Console.WriteLine("[INFO] Looks likes its your first time using RoCord! Lets help you setup.", Console.ForegroundColor = ConsoleColor.White);
                Console.Write("[INPUT]: Insert bot token: ", Console.ForegroundColor = ConsoleColor.Blue);
                Console.ResetColor();
                Index.NewToken = Console.ReadLine();
                Config.Write("token", Index.NewToken);
                Console.WriteLine("[NOTE]: You can change the bot token when you re-launch RoCord or edit via 'config.json' located in the 'bin' folder.", Console.ForegroundColor = ConsoleColor.DarkYellow);
                Console.WriteLine("[SUCCESS]: Token saved!", Console.ForegroundColor = ConsoleColor.Green);
                Console.WriteLine("[PROCESSING]: Loading bot...", Console.ForegroundColor = ConsoleColor.Yellow);
                new Backend().RunBot((string)Config.Read("token")).GetAwaiter().GetResult();
            }
        }
    }
}