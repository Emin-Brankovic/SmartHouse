using SmartHouse.Devices;
using SmartHouse.Enums;
using SmartHouse.Models;
using SmartHouse.SmartHouseSystems;

namespace SmartHouse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            //var lightsystem = new LightSystem();

            //lightsystem.AddDevice(new LightDevice("Livingroom Lamp"));
            //var device = lightsystem.GetDeviceById(1) as LightDevice;
            //Console.WriteLine(device?.Color);
            //lightsystem.ShowDevices();
            //lightsystem.ChangeLightColor(1, LightColors.Red);
            //Console.WriteLine(device?.Color);

            //Console.WriteLine("-------------------------------------------------------------");

            //var security = new SecuritySystem();
            //security.AddDevice(new LightDevice("Device Security"));
            //security.ShowDevices();

            //Console.WriteLine("-------------------------------------------------------------");


            //var enetertainment = new EntertainmentSystem();
            //enetertainment.AddDevice(new LightDevice("Enetertaiment Device"));
            //enetertainment.ShowDevices();


            LightSystem LightSystem = new LightSystem();
            EntertainmentSystem EntertainmentSystem = new EntertainmentSystem();
            SecuritySystem SecuritySystem = new SecuritySystem();


        }
    }
}
