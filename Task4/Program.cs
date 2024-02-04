using Microsoft.Extensions.Configuration;
using System;

namespace Task4
{
    public delegate void ChangeColor();
    
    internal class Program
    {

        public static event ChangeColor OnFontColorChanged;
        public static event ChangeColor OnBackgroundColorChanged;

        static Admin admin = new Admin("qwerty");
        static void Main(string[] args)
        {
            Console.WriteLine("enter password:");
            string password = Console.ReadLine();
            if(admin.CheckPassword(password))
            {
                Console.WriteLine("Sign in succesfull");
                OnFontColorChanged += new ChangeColor(admin.ChangeColorOfFont);
                OnBackgroundColorChanged += new ChangeColor(admin.ChangeColorOfBackgroud);
            }
            else
            {
                Console.WriteLine("password is wrong");
                OnFontColorChanged += () => Console.WriteLine("you are not admin, you can change anything");
                OnBackgroundColorChanged += () => Console.WriteLine("you are not admin, you can change anything");
            }

            while (true)
            {
                Console.BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), admin.fontConfig.BackgroundColor);
                Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), admin.fontConfig.FontColor);
                Console.WriteLine("To change font color print cfc");
                Console.WriteLine("To change background color print cbgc");
                string command = Console.ReadLine();
                
                switch (command)
                {
                    case "cfc":
                        OnFontColorChanged();
                        Console.ResetColor();
                        Console.Clear();
                        break;
                    case "cbgc":
                        OnBackgroundColorChanged();
                        Console.ResetColor();
                        Console.Clear();
                        break;
                    default:
                        Console.ResetColor();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}

