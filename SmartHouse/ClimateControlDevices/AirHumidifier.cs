using SmartHouse.Devices;
using SmartHouse.Enums;
using SmartHouse.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmartHouse.ClimateControlDevices
{
    public class AirHumidifier : ClimateControlDevice
    {
        public AirHumidifier(string deviceName, string brand, List<int> fanSpeeds, double energyUsage, double noiseLevel, bool isAutoAdjustEnabled, double waterTankCapacity, double waterLevel, double currentHumidity,double targetHumidity, int mistOutputLevel,List<int> mistOutputLevels, ClimateControlDeviceTypes deviceType = ClimateControlDeviceTypes.Humidifier, FiltersStatuses filterStatus = FiltersStatuses.Clean, bool connection = true)
                    : base(deviceName, brand, fanSpeeds, energyUsage, noiseLevel, isAutoAdjustEnabled, deviceType, filterStatus, connection)
        {
            WaterTankCapacity = waterTankCapacity;
            WaterLevel = waterLevel;
            CurrentHumidity = currentHumidity;
            TargetHumidity = targetHumidity;
            MistOutputLevel = mistOutputLevel;
            MistOutputLevels = mistOutputLevels;
        }

        public double WaterTankCapacity { get; private set; }
        public double WaterLevel { get; private set; }
        public double CurrentHumidity { get; private set; }
        public double TargetHumidity { get; private set; }
        public int MistOutputLevel { get; private set; }
        public List<int> MistOutputLevels { get; private set; }


        public void SetTargetHumidity()
        {
            string userInputString = string.Empty;
            double userInputStringDouble = default;

            do
            {
                Console.Write("Air humiditiy can be set between 30-70: ");
                userInputString = Console.ReadLine();
            }
            while (!double.TryParse(userInputString, out userInputStringDouble) || userInputStringDouble < 30 || userInputStringDouble > 70);

            TargetHumidity = userInputStringDouble;
            Console.WriteLine($"{DeviceName} target humidity set to {userInputStringDouble}%.");
        }

        public void SetMistOutput()
        {
            MistOutputLevel = Helper.SelectSupported<int>(MistOutputLevels);
        }

        //public void UpdateRoomHumidity(double currentHumidity)
        //{
        //    CurrentHumidity = currentHumidity;
        //    Console.WriteLine($"Current room humidity: {CurrentHumidity}%.");
        //}

        public void ShowWaterLevel()
        {
            Console.WriteLine($"Water level is {WaterLevel}");
        }

    }
}
