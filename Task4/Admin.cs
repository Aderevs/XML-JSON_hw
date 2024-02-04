using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Task4
{
    internal class FontConfiguration
    {
        public string FontColor { get; set; }
        public string BackgroundColor { get; set; }
    }
    internal class Admin
    {
        public FontConfiguration fontConfig { get;}


        public Admin()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("userAppearance.json")
                .Build();
            fontConfig = new FontConfiguration();
            config.Bind(fontConfig);
        }
        public void ChangeColorOfFont()
        {
            Console.WriteLine("Enter color you want to apply:");
            string color = Console.ReadLine();
            object? validColor;
            if (Enum.TryParse(typeof(ConsoleColor), color, out validColor) )
            {
                fontConfig.FontColor = validColor.ToString();
                string updatedJson = JsonSerializer.Serialize(fontConfig);
                File.WriteAllText("userAppearance.json", updatedJson);
            }
            else
            {
                Console.WriteLine("Format of Color was invalid try again (the color must begin " +
                    "with a capital letter and be one of the meanings of the Enum ConsoleColor)");
                 Console.WriteLine("Press eny key to continue...");
                 Console.ReadKey();
            }
        }
        public void ChangeColorOfBackgroud()
        {
            Console.WriteLine("Enter color you want to apply:");
            string color = Console.ReadLine();
            object? validColor;
            if (Enum.TryParse(typeof(ConsoleColor), color, out validColor))
            {
                fontConfig.BackgroundColor = validColor.ToString();
                string updatedJson = JsonSerializer.Serialize(fontConfig);
                File.WriteAllText("userAppearance.json", updatedJson);
            }
            else
            {
                Console.WriteLine("Format of Color was invalid try again (the color must begin " +
                    "with a capital letter and be one of the meanings of the Enum ConsoleColor)");
                Console.WriteLine("Press eny key to continue...");
                Console.ReadKey();
            }
        }
    }
}
