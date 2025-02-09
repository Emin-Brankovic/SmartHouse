using SmartHouse.Devices;
using SmartHouse.Enums;

namespace SmartHouse.ClimateControlDevices
{
    public class AirPurifier : ClimateControlDevice
    {
        public AirPurifier(string deviceName, string brand, List<int> fanSpeeds, double energyUsage, double noiseLevel, bool isAutoAdjustEnabled, int cleanAirDeliveryRate, double coverageArea, bool hasAirQualitySensor, int currentAirQualityLevel, string filterType, ClimateControlDeviceTypes deviceType = ClimateControlDeviceTypes.Purifier, FiltersStatuses filterStatus = FiltersStatuses.Clean, bool connection = true)
                    : base(deviceName, brand, fanSpeeds, energyUsage, noiseLevel, isAutoAdjustEnabled, deviceType, filterStatus, connection)
        {
            FilterType = filterType;
            CleanAirDeliveryRate = cleanAirDeliveryRate;
            CoverageArea = coverageArea;
            HasAirQualitySensor = hasAirQualitySensor;
            CurrentAirQualityLevel = currentAirQualityLevel;
        }


        public string FilterType { get; private set; }
        public int CleanAirDeliveryRate { get; private set; }
        public double CoverageArea { get; private set; }
        public bool HasAirQualitySensor { get; private set; }
        public int CurrentAirQualityLevel { get; private set; }

        public override void GetStatus()
        {
            base.GetStatus();

            Console.WriteLine($"Filter Type: {FilterType}");
            Console.WriteLine($"Clean Air Delivery Rate (CADR): {CleanAirDeliveryRate}");
            Console.WriteLine($"Coverage Area: {CoverageArea} m²");
            Console.WriteLine($"Air Quality Sensor: {(HasAirQualitySensor ? "Enabled" : "Disabled")}");
            Console.WriteLine($"Current Air Quality Level: {CurrentAirQualityLevel}");
        }
    }
}
