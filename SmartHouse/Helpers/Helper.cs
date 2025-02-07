using SmartHouse.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Helpers
{
    public static class Helper
    {
        public static bool IsDeviceOn(SmartHouseDevice device)
        {
            if (device.IsOn)
                return true ;
            else
            {
                Console.WriteLine($"Device is off");
                return false ;
            }
        }

        public static T? SelectSupported<T>(List<T> supported)
        {
            string userInput = string.Empty;
            int chosenValue;

            for (int i = 0; i < supported.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {supported[i]}");
            }

            Console.WriteLine("Select by entering the number");

            Console.WriteLine("----------------------------------------------");

            do
            {
                Console.Write("Choice: ");
                userInput = Console.ReadLine();
            }
            while (!int.TryParse(userInput, out chosenValue) || chosenValue < 1 || chosenValue >= supported.Count);

            
            return  supported[chosenValue - 1];
        }

    }
}
