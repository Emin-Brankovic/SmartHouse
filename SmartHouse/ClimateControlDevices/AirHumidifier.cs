using SmartHouse.Devices;
using SmartHouse.Enums;
using SmartHouse.Helpers;

namespace SmartHouse.ClimateControlDevices
{
    public class AirHumidifier : ClimateControlDevice
    {
        public AirHumidifier(string deviceName, string brand, List<int> fanSpeeds, double energyUsage, double noiseLevel, bool isAutoAdjustEnabled, double waterTankCapacity, double waterLevel, double currentHumidity, double targetHumidity, int mistOutputLevel, List<int> mistOutputLevels, ClimateControlDeviceTypes deviceType = ClimateControlDeviceTypes.Humidifier, FiltersStatuses filterStatus = FiltersStatuses.Clean, bool connection = true)
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
            Console.WriteLine("Change the mist output level\n");
            MistOutputLevel = Helper.SelectSupported<int>(MistOutputLevels);
        }

        public void ShowWaterLevel()
        {
            Console.WriteLine($"Water level is {WaterLevel} L");
        }

        public override void GetStatus()
        {
            base.GetStatus();

            Console.WriteLine($"Water Tank Capacity: {WaterTankCapacity} liters");
            Console.WriteLine($"Current Water Level: {WaterLevel} liters");
            Console.WriteLine($"Current Humidity: {CurrentHumidity}%");
            Console.WriteLine($"Target Humidity: {TargetHumidity}%");
            Console.WriteLine($"Mist Output Level: {MistOutputLevel}");
            Console.WriteLine($"Available Mist Output Levels: {string.Join(", ", MistOutputLevels)}");
        }

    }
}
