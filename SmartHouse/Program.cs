using SmartHouse.ClimateControlDevices;
using SmartHouse.Devices;
using SmartHouse.EntertainmetDevices;
using SmartHouse.Enums;
using SmartHouse.Models;
using SmartHouse.Repository;
using SmartHouse.SecurityDevices;
using SmartHouse.SmartHouseSystems;
using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace SmartHouse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            InMemoryRepository.PopulateRepository();

            //LightSystem
            Console.WriteLine("\n===== Light System =====\n");

            SmartHouse.LightSystemFunctionalities();

            Console.WriteLine("\nPress any key to continue\n");
            Console.ReadKey();

            //EntertainmentSystem

            Console.WriteLine("\n===== Entertainment System =====\n");

            SmartHouse.EntertainmentSystemFunctionalities();


            Console.WriteLine("\nPress any key to continue\n");
            Console.ReadKey();

            //SecuritySystem

            Console.WriteLine("\n===== Security System =====\n");

            SmartHouse.SecuritySystemFunctionalities();

            Console.WriteLine("\nPress any key to continue\n");
            Console.ReadKey();

            //ClimateControlSystem

            Console.WriteLine("\n===== Climate Control System =====\n");

            SmartHouse.ClimateControlSystemFunctionalities();

            Console.WriteLine("\nPress any key to finish\n");
            Console.ReadKey();
        }
    }
}
