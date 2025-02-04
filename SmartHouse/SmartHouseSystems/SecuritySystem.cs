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
        public void ShowBatteryLevel(int deviceId)
        {
            var device=_devices.FirstOrDefault(x => x.DeviceId == deviceId) as SecurityDevice;
            if (device != null && device.IsOn)
                Console.WriteLine($"Battery: {device.BatteryLevel}");
            else
                Console.WriteLine("Device not found");

        }

        public void UpdateDeviceLocation(int deviceId,string location)
        {
            var device = _devices.FirstOrDefault(x => x.DeviceId == deviceId) as SecurityDevice;
            if (device != null && device.IsOn)
            {
                device.Location = location;
                Console.WriteLine($"Device location changed to: {device.Location}");
            }
            else
                Console.WriteLine("Device not found");

        }

        public void UpdateDeviceState(int deviceId, SecurityDeviceStates state)
        {
            var device = _devices.FirstOrDefault(x => x.DeviceId == deviceId) as SecurityDevice;
            if (device != null && device.IsOn)
            {
                device.State = state;
                Console.WriteLine($"Device state changed to: {device.State}");
            }
            else
                Console.WriteLine("Device not found");

        }

        public SecurityDevice GetDevice(int deviceId)
        {
            var device = GetDeviceById(deviceId) as SecurityDevice;
            if (device != null)
                return device;
            else
                throw new Exception("Device not found");
        }
    }
}
