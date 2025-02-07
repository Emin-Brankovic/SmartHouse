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
        public EntertainmentDevice GetDevice(int deviceId)
        {
            var device = GetDeviceById(deviceId) as EntertainmentDevice;
            if (device != null)
                return device;
            else
                throw new Exception("Device not found");
        }


        public void MuteAllDevices()
        {
            foreach (var device in _devices)
            {
                EntertainmentDevice? entertainmentDevice = device as EntertainmentDevice;
                if (entertainmentDevice!=null && entertainmentDevice.IsOn)
                {
                    entertainmentDevice.MuteDevice();
                   
                }
            }
        }

        public void UnmuteAllDevices()
        {
            foreach (var device in _devices)
            {
                EntertainmentDevice? entertainmentDevice = device as EntertainmentDevice;
                if (entertainmentDevice != null && entertainmentDevice.IsOn)
                {
                    entertainmentDevice.UnmuteDevice();
                    Console.WriteLine($"{entertainmentDevice.DeviceName} is now unmuted.");
                }
            }
        }

        public void ChangeVolumeAllDevices(int volume)
        {
            foreach (var device in _devices)
            {
                EntertainmentDevice? entertainmentDevice = device as EntertainmentDevice;
                if (entertainmentDevice != null && entertainmentDevice.IsOn)
                {
                    entertainmentDevice.CurrentVolume=volume;
                    
                }
            }
        }
    }
}
