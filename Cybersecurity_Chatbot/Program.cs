using System;
using System.Media;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Web;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Cybersecurity_Chatbot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Cybersecuirty Awareness Chatbot";
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            WelcomeSound();

            DisplayAcsiiArt();

            string user = GetUser();

            ChatLoop(user);
        }

        static void WelcomeSound()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("Welcome.wav");
                player.Play();
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                Console.WriteLine("The Welcome Sound Could Not Play: " + ex.Message);
            }
        }

        static void DisplayAcsiiArt()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;

            string asciiArt = @"   ____           _               _   _              
 / ___|   _   _ | |__    _   _  | | | |  ___   _ __ 
| |      | | | || '_ \  | | | | | | | | / _ \ | '__|
| |___   | |_| || |_) | | |_| | | | | || (_) || |   
 \____|   \__,_||_.__/   \__,_| |_| |_| \___/ |_|   

  ___          _                  _   _              
 / _ \        | |                | | (_)             
/ /_\ \ _ __  | |_   _  ______   | |_ _   ___   ___ 
|  _  || '_ \ | __| | | ||_  /   | __| | / __| / _ \
| | | || | | || |_  |_| | / /    | |_| | \__ \|  __/
\_| |_/|_| |_| \__| \__,_|/___|   \__|_| |___/ \___| ";

            Console.WriteLine(asciiArt);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(new string('=', 80));
            Console.ResetColor();
        }

        static string GetUser()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\nHello! What is your full name? ");
            Console.ResetColor();

            string name = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Please enter a valid name: ");
                Console.ResetColor();
                name = Console.ReadLine();
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nWelcome, {name}! I am your Cybersecurity Awareness Assistant.");
            Console.ResetColor();

            return name;
        }

        static void ChatLoop(string user)
        {
            bool exitRequested = false;

            while (!exitRequested)
            {
                DisplayMenu();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"\n{user}, What would you like to enquire about regarding cybersecurity");
                Console.ResetColor();

                string input = Console.ReadLine()?.ToLower()
                                      .Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Please enter a valid question.");
                    Console.ResetColor();
                    continue;
                }

                if (input == "exit" || input == "quit")
                {
                    exitRequested = true;
                    continue;
                }

                ProcessingInput(input, user);
            }

            EndProgram(user);
        }

        static void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n" + new string('-', 50));
            Console.WriteLine("--CYBERSECURITY TOPICS MENU--");
            Console.WriteLine(new string('-', 50));
            Console.ResetColor();

            Console.WriteLine("1. Password Safety");
            Console.WriteLine("2. Safe Browsing");
            Console.WriteLine("3. Phishing Protection");
            Console.WriteLine("4. How are you?");
            Console.WriteLine("5. What is your purpose?");
            Console.WriteLine("Type 'exit' to quit");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(new string('-', 50));
            Console.ResetColor();
        }

        static void ProcessingInput(string input, string user)
        {
            Thread.Sleep(600);

            Console.ForegroundColor = ConsoleColor.Red;


            if (input.Contains("how are you"))
            {
                Writing($"I'm just a program, {user}, but thanks for asking! I'm always ready to help with cybersecurity questions.");
            }
            else if (input.Contains("purpose") || input.Contains("what can you do"))
            {
                Writing($"My purpose is to help {user} learn about important cybersecurity topics like password safety, phishing, and safe browsing.");
            }
            else if (input.Contains("password"))
            {
                Writing($"Great question about passwords, {user}!\n" +
                    "• Use long, unique passwords for each account\n" +
                    "• Consider a password manager\n" +
                    "• Enable two-factor authentication\n" +
                    "• Change passwords after security breaches");
            }
            else if (input.Contains("phish"))
            {
                Writing($"Phishing is a serious threat, {user}!\n" +
                    "• Never click suspicious links in emails\n" +
                    "• Check sender addresses carefully\n" +
                    "• Look for poor grammar/spelling\n" +
                    "• When you're unsure of what to do, contact the company directly");
            }
            else if (input.Contains("brows") || input.Contains("internet"))
            {
                Writing($"Safe browsing is essential, {user}!\n" +
                    "• Look for HTTPS in website URLs\n" +
                    "• Keep your browser updated\n" +
                    "• Use ad blockers and privacy extensions\n" +
                    "• Avoid public Wi-Fi for sensitive transactions");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Writing($"I didn't quite understand that, {user}. Could you please rephrase or ask about password safety, phishing, or safe browsing?");
            }

            Console.ResetColor();
        }

        static void Writing(string text)
        {
            for (int x = 0; x < text.Length; x++)
            {
                Console.Write(text[x]);
                Thread.Sleep(30);
            }
            Console.WriteLine();
        }

        static void EndProgram(string user)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"\nGoodbye, {user}! Keep your online information safe!");
            Console.ResetColor();
            Thread.Sleep(3000);
        }
    }

    
}
