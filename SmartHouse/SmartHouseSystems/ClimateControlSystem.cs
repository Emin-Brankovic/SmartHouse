using SmartHouse.Devices;
using SmartHouse.Interfaces;
using SmartHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.SmartHouseSystems
{
    public class ClimateControlSystem : DeviceManager
    {
        public ClimateControlDevice GetDevice(int deviceId)
        {
            var device = GetDeviceById(deviceId) as ClimateControlDevice;
            if (device != null)
                return device;
            else
                throw new Exception("Device not found");
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
