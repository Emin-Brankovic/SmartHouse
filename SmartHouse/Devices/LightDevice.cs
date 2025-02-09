using SmartHouse.Enums;
using SmartHouse.Helpers;
using SmartHouse.Models;

namespace SmartHouse.Devices
{

    public enum LightDeviceTypes
    {
        Lightbulb,
        LEDstrip,
        Lamp,
        All
    }

    public class LightDevice : SmartHouseDevice
    {
        public LightDevice(string deviceName, string brand, bool supportsRGB, LightDeviceTypes deviceType, bool connection = true, LightColors color = LightColors.White, int brightnes = 100,
            int colorTemperature = 3000)
            : base(deviceName, brand, connection)
        {
            Color = color;
            Brightnes = brightnes;
            CurrentColorTemperature = 3000;
            DeviceType = deviceType;
            SupportsRGB = supportsRGB;
        }

        public LightColors Color { get; private set; }
        public int Brightnes { get; private set; }
        public readonly int MaxColorTemperature = 6500;
        public readonly int MinColorTemperature = 2700;
        public int CurrentColorTemperature { get; private set; }
        public LightDeviceTypes DeviceType { get; private set; }
        public bool SupportsRGB { get; private set; }

        public void ChangeLightColor(LightColors color)
        {
            if (!SupportsRGB) return;

            if (Helper.IsDeviceOn(this))
            {
                Color = color;
                Console.WriteLine($"Device {DeviceName} color changed to {color}.");
            }

        }
        public void ChangeLightBrightness(int brightnesLevel)
        {

            if (Helper.IsDeviceOn(this))
            {
                if (brightnesLevel >= 0 && brightnesLevel <= 100)
                {
                    Brightnes = brightnesLevel;
                    Console.WriteLine($"Device {DeviceName} brightness level changed to {brightnesLevel}%.");
                }
                else if (brightnesLevel < 0)
                {
                    Brightnes = 0;
                    Console.WriteLine($"Device {DeviceName} brightnes level changed to 0%.");
                }
                else if (brightnesLevel > 100)
                {
                    Brightnes = 100;
                    Console.WriteLine($"Device {DeviceName} brightnes level changed to 100%.");
                }

            }

        }

        public void ChangeColorTemperature(int temperature)
        {

            if (Helper.IsDeviceOn(this))
            {
                if (temperature <= MaxColorTemperature && temperature >= MinColorTemperature)
                {
                    CurrentColorTemperature = temperature;
                    Console.WriteLine($"Device {DeviceName} color temperature set to {temperature}K.");
                }
                else
                    Console.WriteLine("Entered temperature out of range");
            }
        }

        public override void GetStatus()
        {
            base.GetStatus();
            Console.WriteLine($"Device Type: {DeviceType}");
            Console.WriteLine($"Color: {Color}");
            Console.WriteLine($"Brightness: {Brightnes}%");
            Console.WriteLine($"Color Temperature: {CurrentColorTemperature}K (Range: {MinColorTemperature}K - {MaxColorTemperature}K)");
            Console.WriteLine($"RGB Support: {(SupportsRGB ? "Yes" : "No")}");
        }

    }
}
