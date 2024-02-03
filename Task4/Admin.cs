using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Task4
{
    internal class Admin
    {
        public FontConfiguration fontConfig { get; }

        public Admin()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("userAppearance.json")
                .Build();
            fontConfig = new FontConfiguration();
            config.GetSection("Appearance").Bind(fontConfig);

        }
        public void ChangeColorOfFont()
        {
            Console.WriteLine("Enter color you want to apply:");
            string colour = Console.ReadLine();
            fontConfig.FontColor = colour;
            string updatedJson = JsonSerializer.Serialize(fontConfig);
        }
        public void ChangeColorOfBackgroud()
        {
            Console.WriteLine("Enter color you want to apply:");
            string colour = Console.ReadLine();
            fontConfig.BackgroundColor = colour;
            string updatedJson = JsonSerializer.Serialize(fontConfig);
        }
    }
}
