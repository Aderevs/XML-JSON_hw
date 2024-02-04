using Microsoft.Extensions.Configuration;
using System;

namespace Task4
{
    public delegate void ChangeColor();
    
    internal class Program
    {

        public static event ChangeColor OnFontColorChanged;
        public static event ChangeColor OnBackgroundColorChanged;

        static Admin admin = new Admin();
        static void Main(string[] args)
        {
            OnFontColorChanged += new ChangeColor(admin.ChangeColorOfFont);
            OnBackgroundColorChanged += new ChangeColor(admin.ChangeColorOfBackgroud);

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

