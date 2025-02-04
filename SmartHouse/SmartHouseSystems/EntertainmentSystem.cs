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
    public class EntertainmentSystem : DeviceManager
    {
        public void MuteDevice(string deviceName)
        {
            var device=_devices.FirstOrDefault(x => x.DeviceName == deviceName) as EntertainmentDevice;
            if (device != null && device.IsOn)
            {
                device.IsMuted= true;
                Console.WriteLine($"Device muted");
            }
        }

        public void UnmuteDevice(string deviceName)
        {
            var device = _devices.FirstOrDefault(x => x.DeviceName == deviceName) as EntertainmentDevice;
            if (device != null && device.IsOn)
            {
                device.IsMuted = false;
                Console.WriteLine($"Device unmuted");
            }
        }

        public void ChnageVolume(string deviceName,int volume)
        {
            var device = _devices.FirstOrDefault(x => x.DeviceName == deviceName) as EntertainmentDevice;
            if (device != null && device.IsOn)
            {
                if (volume < device.MaxVolume) return;

                device.CurrentVolume = volume;
                Console.WriteLine($"Device volume: {device.CurrentVolume}");
            }
        }

        public EntertainmentDevice GetDevice(int deviceId)
        {
            var device = GetDeviceById(deviceId) as EntertainmentDevice;
            if (device != null)
                return device;
            else
                throw new Exception("Device not found");
        }
    }
}
