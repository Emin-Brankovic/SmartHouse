using SmartHouse.Devices;
using SmartHouse.Enums;
using SmartHouse.Interfaces;
using SmartHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.SmartHouseSystems
{
    public class SecuritySystem : DeviceManager
    {
        public SecurityDevice GetDevice(int deviceId)
        {
            var device = GetDeviceById(deviceId) as SecurityDevice;
            if (device != null)
                return device;
            else
                throw new Exception("Device not found");
        }

        public void ArmSystem()
        {
            foreach (var device in _devices)
            {
                SecurityDevice? securityDevice = device as SecurityDevice;
                if (securityDevice != null && securityDevice.IsOn)
                {
                    securityDevice.UpdateDeviceState(SecurityDeviceStates.Armed);
                }
            }
            Console.WriteLine("Security system armed.");
        }

        public void DisarmSystem()
        {
            foreach (var device in _devices)
            {
                SecurityDevice? securityDevice = device as SecurityDevice;
                if (securityDevice != null && securityDevice.IsOn)
                {
                    securityDevice.UpdateDeviceState(SecurityDeviceStates.Disarmed);
                }
            }
            Console.WriteLine("Security system disarmed.");
        }

    }
}
