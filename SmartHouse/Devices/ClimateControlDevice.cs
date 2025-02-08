using SmartHouse.Enums;
using SmartHouse.Helpers;
using SmartHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Devices
{
    public enum ClimateControlDeviceTypes
    {
        AirCondition,
        Humidifier,
        Purifier,
        All
    }

    public abstract class ClimateControlDevice : SmartHouseDevice
    {
        public ClimateControlDevice(string deviceName, string brand, List<int> fanSpeeds, double energyUsage, double noiseLevel,
           bool isAutoAdjustEnabled, ClimateControlDeviceTypes deviceType, FiltersStatuses filterStatus=FiltersStatuses.Clean, bool connection = true) 
            : base(deviceName, brand, connection)
        {
            FanSpeeds = fanSpeeds;
            EnergyUsage = energyUsage;
            NoiseLevel = noiseLevel;
            IsAutoAdjustEnabled = isAutoAdjustEnabled;  
            FilterStatus = filterStatus;
            DeviceType = deviceType;
        }

        public List<int> FanSpeeds { get; private set; }
        public int CurrentFanSpeed { get; set; }
        public double EnergyUsage { get; private set; } //kWh
        public double NoiseLevel { get; private set; } //dB
        public bool IsAutoAdjustEnabled { get; private set; }
        public FiltersStatuses FilterStatus { get; private set; }
        public ClimateControlDeviceTypes DeviceType { get; set; }

        public void ChangeFanSpeed()
        {
            var selected = Helper.SelectSupported<int>(FanSpeeds);
            CurrentFanSpeed= selected;

            Console.WriteLine($"{DeviceName} fan speed changed to {CurrentFanSpeed}");
        }
    }
}
