using SmartHouse.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Models
{
    public class DeviceManager : IDeviceManager
    {
        //Maybe change data type from List to Dictionary. See the what is better for implementation
        protected List<SmartHouseDevice> _devices=new List<SmartHouseDevice>();


        public void AddDevice(SmartHouseDevice device)
        {
           _devices.Add(device);
        }

        public void RemoveDevice(int deviceId)
        {
           var device=_devices.FirstOrDefault(x => x.DeviceId == deviceId);
            if (device != null)
                _devices.Remove(device);
            else
                Console.WriteLine($"Device with ID: {deviceId} was not found as a registred device in your house");
        }

        public void RemoveAllDevices()
        {
            foreach (var device in _devices)
            {
                _devices.Remove(device);
            }
        }

        public void ShowDevices()
        {
           foreach(var device in _devices)
                Console.WriteLine(device.DeviceName + " " + device.DeviceId);
        }

        public void TurnOffAllDevicesOff()
        {
            foreach (var device in _devices)
            {
                device.TurnOff();
            }
        }

        public void TurnOnAllDevicesOn()
        {
            foreach (var device in _devices)
            {
                device.TurnOn();
            }
        }

        public SmartHouseDevice? GetDeviceById(int deviceId)
        {
            var device=_devices.FirstOrDefault(x=>x.DeviceId == deviceId);
            if (device != null) return device;
            else return null;
        }
    }
}
