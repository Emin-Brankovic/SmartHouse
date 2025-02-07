using SmartHouse.Devices;
using SmartHouse.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.ClimateControlDevices
{
    public class AirPurifier : ClimateControlDevice
    {
        public AirPurifier(string deviceName, string brand, List<int> fanSpeeds, double energyUsage, double noiseLevel, bool isAutoAdjustEnabled, int cleanAirDeliveryRate, double coverageArea,bool hasAirQualitySensor, int currentAirQualityLevel, string filterType, ClimateControlDeviceTypes deviceType = ClimateControlDeviceTypes.Purifier,FiltersStatuses filterStatus = FiltersStatuses.Clean, bool connection = true)
                    : base(deviceName, brand, fanSpeeds, energyUsage, noiseLevel, isAutoAdjustEnabled, deviceType, filterStatus, connection)
        {
            FilterType = filterType;
            CleanAirDeliveryRate = cleanAirDeliveryRate;
            CoverageArea = coverageArea;
            HasAirQualitySensor = hasAirQualitySensor;
            CurrentAirQualityLevel = currentAirQualityLevel;
        }


        public string FilterType { get; set; } 
        public int CleanAirDeliveryRate { get; set; } 
        public double CoverageArea { get; set; } 
        public bool HasAirQualitySensor { get; set; }
        public int CurrentAirQualityLevel { get; set; }
    }
}
