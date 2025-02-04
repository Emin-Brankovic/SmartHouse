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

            LightSystem lightSystem = new LightSystem();
            EntertainmentSystem entertainmentSystem = new EntertainmentSystem();
            SecuritySystem securitySystem = new SecuritySystem();

            for (int i = 0; i < 5; i++)
            {
                lightSystem.AddDevice(new LightDevice($"Light device {i+1}"));
            }

            for (int i = 0; i < 5; i++)
            {
                entertainmentSystem.AddDevice(new EntertainmentDevice($"Entertainment device {i + 1}",
                    new List<ConnectivityTypes> { ConnectivityTypes.Bluetooth,ConnectivityTypes.WiFi,ConnectivityTypes.Wired}));
            }


            for (int i = 0; i < 5; i++)
            {
                securitySystem.AddDevice(new SecurityDevice($"Security device {i + 1}","Garage"));
            }

            lightSystem.TurnOnAllDevicesOn();

            lightSystem.ChangeLightColor(1, LightColors.Blue);
            lightSystem.ChangeLightBrightnes(1, 55);
            lightSystem.ChangeLightColor(2, LightColors.Red);
            lightSystem.ChangeLightColor(3, LightColors.Purple);
            lightSystem.ChangeColorTemperature(4, 4500);


            lightSystem.ShowDevices();
            securitySystem.ShowDevices();
            entertainmentSystem.ShowDevices();

            Console.WriteLine("------------------------------------------");

            try
            {
                var lightdevice=lightSystem.GetDevice(12);
                Console.WriteLine(lightdevice.Color);
                Console.WriteLine(lightdevice.Brightnes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                var lightdevice1 = lightSystem.GetDevice(4);
                Console.WriteLine(lightdevice1.Color);
                Console.WriteLine(lightdevice1.Brightnes);
                Console.WriteLine(lightdevice1.CurrentColorTemperature);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



        }
    }
}
