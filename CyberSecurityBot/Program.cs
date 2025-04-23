using System;
using System.Media;
using System.Threading;

namespace CyberSecurityBot
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayVoiceGreeting();
            DisplayBanner();
            string userName = GetUserName();

            typingEffect($"\nWelcome, {userName}! I'm your Cybersecurity Awareness Bot.");
            typingEffect("Ask me anything related to cybersecurity or type 'exit' to quit.\n");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("You: ");
                Console.ResetColor();

                string? rawInput = Console.ReadLine();
                string input = rawInput?.Trim().ToLower() ?? "";

                if (string.IsNullOrWhiteSpace(input))
                {
                    DisplayWithBorder("I didn’t quite understand that.\nCould you rephrase?");
                    continue;
                }

                if (input == "exit")
                {
                    DisplayWithBorder("Stay safe online! Goodbye!");
                    break;
                }

                RespondToInput(input);
            }
        }

        static void PlayVoiceGreeting()
        {
            if (OperatingSystem.IsWindows())
            {
                try
                {
                    SoundPlayer player = new SoundPlayer(@"Recording.wav");
                    player.Load();
                    player.PlaySync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error playing voice greeting: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("(Voice greeting skipped – only available on Windows)");
            }
        }

        static void DisplayBanner()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
===================================================
     _____ _                 _                     
    / ____| |               | |                    
   | |    | | ___  _   _  __| |_ __ ___  ___  ___  
   | |    | |/ _ \| | | |/ _` | '__/ _ \/ __|/ _ \ 
   | |____| | (_) | |_| | (_| | | |  __/\__ \  __/ 
    \_____|_|\___/ \__,_|\__,_|_|  \___||___/\___| 

       🛡️ CYBERSECURITY AWARENESS BOT 🛡️        
===================================================
");
            Console.ResetColor();
            Console.WriteLine();
        }

        static string GetUserName()
        {
            Console.Write("What is your name? ");
            string? name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                return "User";
            }
            return char.ToUpper(name[0]) + name.Substring(1);
        }

        public static void typingEffect(string message, int delay = 30)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            foreach (char ch in message)
            {
                Console.Write(ch);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        static void DisplayWithBorder(string message)
        {
            string[] lines = message.Split('\n');
            int maxLength = 0;

            foreach (string line in lines)
            {
                if (line.Length > maxLength)
                    maxLength = line.Length;
            }

            string topBorder = "╔" + new string('═', maxLength + 2) + "╗";
            string bottomBorder = "╚" + new string('═', maxLength + 2) + "╝";

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(topBorder);

            foreach (string line in lines)
            {
                Console.WriteLine($"║ {line.PadRight(maxLength)} ║");
            }

            Console.WriteLine(bottomBorder);
            Console.ResetColor();
        }

        static void RespondToInput(string input)
        {
            switch (input.ToLower())
            {
                case "how are you":
                    DisplayWithBorder("Thanks for asking! I'm operating smoothly in the digital world.\nHow can I assist you with cybersecurity today?");
                    break;

                case string x when x.Contains("what's your purpose"):
                case string x2 when x2.Contains("what is your purpose"):
                    DisplayWithBorder("I’m here to help you learn and stay safe in the cyber world.");
                    break;

                case string x when x.Contains("what can i ask you about"):
                    DisplayWithBorder("You can ask me about password safety, phishing, and safe browsing!");
                    break;

                case string x when x.Contains("password safety"):
                    DisplayWithBorder("Use strong passwords with letters, numbers, and symbols.\nAvoid using personal info.");
                    break;

                case string x when x.Contains("phishing"):
                    DisplayWithBorder("Beware of emails or messages asking for personal info.\nAlways verify the sender.");
                    break;

                case "safe browsing":
                    DisplayWithBorder("Stick to secure (https) websites and avoid downloading from unknown sources.");
                    break;

                case "help":
                    ShowHelp();
                    break;

                default:
                    DisplayWithBorder("I didn’t quite understand that.\nCould you rephrase or type 'help'?");
                    break;
            }
        }

        static void ShowHelp()
        {
            string helpText = "\nYou can ask me about:\n" +
                              "- how are you\n" +
                              "- what's your purpose / what is your purpose\n" +
                              "- what can I ask you about\n" +
                              "- password safety\n" +
                              "- phishing\n" +
                              "- safe browsing\n" +
                              "- exit";
            DisplayWithBorder(helpText);
        }
    }
}
