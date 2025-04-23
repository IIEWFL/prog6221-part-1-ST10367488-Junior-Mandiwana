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

            // Code Attribution
            //Typing Effect Logic: Inspired by examples from https://gist.github.com/joshschmelzle/610451c749dd14bb777a?utm
            //joshschmelzle
            //https://gist.github.com/joshschmelzle

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

        // Code Attribution
        //SoundPlayer usage: Based on Microsoft's documentation for [System.Media.SoundPlayer](https://learn.microsoft.com/en-us/dotnet/api/system.media.soundplayer)


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

        // Code Attribution
        //This was made using patorjk.com
        //ASCII Banner: Generated using [TAAG] (https://patorjk.com/software/taag)

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
            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (char ch in message)
            {
                Console.Write(ch);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        // Code Attribution
        //Console Border Drawing: Referenced from discussions on[Stack Overflow](https://stackoverflow.com/questions/23245726/how-to-draw-a-border-around-text-in-console-application-c)
        //UvarajGopu
        //https://stackoverflow.com/users/2859140/uvarajgopu

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
