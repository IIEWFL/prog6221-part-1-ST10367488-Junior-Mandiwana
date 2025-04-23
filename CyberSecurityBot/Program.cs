using System;
using System.Media;

namespace CyberSecurityBot
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayVoiceGreeting();
            DisplayBanner();
            string userName = GetUserName();

            Console.WriteLine($"\nWelcome, {userName}! I'm your Cybersecurity Awareness Bot.");
            Console.WriteLine("Ask me anything related to cybersecurity or type 'exit' to quit.\n");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("You: ");
                Console.ResetColor();

                string? rawInput = Console.ReadLine();
                string input = rawInput?.Trim().ToLower() ?? "";

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("I didn’t quite understand that. Could you rephrase?");
                    continue;
                }

                if (input == "exit")
                {
                    Console.WriteLine("Stay safe online! Goodbye!");
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
                    SoundPlayer player = new SoundPlayer(@"C:\\Users\\Maseo Junior\\Desktop\\CyberSecurityBot\\Recording.wav");
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

        static void RespondToInput(string input)
        {
            switch (input.ToLower())
            {
                case "how are you":
                    Console.WriteLine("Thanks for asking! I'm operating smoothly in the digital world. How can I assist you with cybersecurity today?");
                    break;

                case "what's your purpose":
                case "ce":
                    Console.WriteLine("I’m here to help you learn and stay safe in the cyber world.");
                    break;

                case string x when x.Contains("what can i ask you about"):
                    Console.WriteLine("You can ask me about password safety, phishing, and safe browsing!");
                    break;

                case string x when x.Contains("password safety"):
                    Console.WriteLine("Use strong passwords with letters, numbers, and symbols. Avoid using personal info.");
                    break;

                case string x when x.Contains("phishing") :
                    Console.WriteLine("Beware of emails or messages asking for personal info. Always verify the sender.");
                    break;

                case "safe browsing":
                    Console.WriteLine("Stick to secure (https) websites and avoid downloading from unknown sources.");
                    break;

                case "help":
                    ShowHelp();
                    break;

                default:
                    Console.WriteLine("I didn’t quite understand that. Could you rephrase or type 'help'?");
                    break;
            }
        }

        static void ShowHelp()
        {
            Console.WriteLine("\nYou can ask me about:");
            Console.WriteLine("- how are you");
            Console.WriteLine("- what's your purpose / what is your purpose");
            Console.WriteLine("- what can I ask you about");
            Console.WriteLine("- password safety");
            Console.WriteLine("- phishing");
            Console.WriteLine("- safe browsing");
            Console.WriteLine("- exit");
        }
    }
}
