using SmartHouse.Devices;
using SmartHouse.Interfaces;
using SmartHouse.Models;
using SmartHouse.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.SmartHouseSystems
{
    public class ClimateControlSystem : DeviceManager
    {
        public ClimateControlSystem()
        {
            InitDevices();
        }

        public ClimateControlDevice? GetDevice(string deviceId)
        {
            var device = GetDeviceById(deviceId) as ClimateControlDevice;
            if (device != null)
                return device;
            else
                return null;
        }

        public void InitDevices()
        {
            _devices.AddRange(InMemoryRepository.AirAirHumidifiers);
            _devices.AddRange(InMemoryRepository.AirConditioners);
            _devices.AddRange(InMemoryRepository.AirPurifiers);
        }

        public void ChangeFanSpeedOfAllDevices(int fanSpeed,ClimateControlDeviceTypes deviceType)
        {
            if (deviceType == ClimateControlDeviceTypes.All)
            {
                foreach (var device in _devices)
                {
                    ClimateControlDevice? climateControlDevice = device as ClimateControlDevice;
                    if (climateControlDevice != null && climateControlDevice.IsOn)
                    {
                        climateControlDevice.CurrentFanSpeed=fanSpeed;

                    }
                }
            }
            else
            {
                foreach (var device in _devices)
                {
                    ClimateControlDevice? climateControlDevice = device as ClimateControlDevice;
                    if (climateControlDevice != null && climateControlDevice.IsOn && climateControlDevice.DeviceType==deviceType)
                    {
                        climateControlDevice.CurrentFanSpeed = fanSpeed;
                    }
                }
            }
        }
    }
}
