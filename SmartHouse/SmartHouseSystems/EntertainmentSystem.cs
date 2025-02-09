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
    public class EntertainmentSystem : DeviceManager
    {
        public EntertainmentSystem()
        {
            InitDevices();
        }

        public EntertainmentDevice GetDevice(string deviceId)
        {
            var device = GetDeviceById(deviceId) as EntertainmentDevice;
            if (device != null)
                return device;
            else
                throw new Exception("Device not found");
        }

        private void InitDevices()
        {
            _devices.AddRange(InMemoryRepository.SmartTVs);
            _devices.AddRange(InMemoryRepository.SmartProjectors);
            _devices.AddRange(InMemoryRepository.Speakers);
        }


        public void MuteAllDevices(EntertainmentDeviceTypes deviceType)
        {
            if (EntertainmentDeviceTypes.All == deviceType)
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
            else
            {
                foreach (var device in _devices)
                {
                    EntertainmentDevice? entertainmentDevice = device as EntertainmentDevice;
                    if (entertainmentDevice != null && entertainmentDevice.IsOn && entertainmentDevice.DeviceType==deviceType)
                    {
                        entertainmentDevice.MuteDevice();

                    }
                }
            }
        }

        public void UnmuteAllDevices(EntertainmentDeviceTypes deviceType)
        {
            if (EntertainmentDeviceTypes.All == deviceType)
            {
                foreach (var device in _devices)
                {
                    EntertainmentDevice? entertainmentDevice = device as EntertainmentDevice;
                    if (entertainmentDevice != null && entertainmentDevice.IsOn)
                    {
                        entertainmentDevice.UnmuteDevice();

                    }
                }
            }
            else
            {
                foreach (var device in _devices)
                {
                    EntertainmentDevice? entertainmentDevice = device as EntertainmentDevice;
                    if (entertainmentDevice != null && entertainmentDevice.IsOn && entertainmentDevice.DeviceType == deviceType)
                    {
                        entertainmentDevice.UnmuteDevice();

                    }
                }
            }
        }

        public void ChangeVolumeAllDevices(int volume, EntertainmentDeviceTypes deviceType)
        {

            if (EntertainmentDeviceTypes.All == deviceType)
            {
                foreach (var device in _devices)
                {
                    EntertainmentDevice? entertainmentDevice = device as EntertainmentDevice;
                    if (entertainmentDevice != null && entertainmentDevice.IsOn)
                    {
                        entertainmentDevice.CurrentVolume = volume;

                    }
                }
            }
            else
            {
                foreach (var device in _devices)
                {
                    EntertainmentDevice? entertainmentDevice = device as EntertainmentDevice;
                    if (entertainmentDevice != null && entertainmentDevice.IsOn && entertainmentDevice.DeviceType == deviceType)
                    {
                        entertainmentDevice.CurrentVolume = volume;

                    }
                }
            }

        }
    }
}
