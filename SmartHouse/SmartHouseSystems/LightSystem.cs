using SmartHouse.Devices;
using SmartHouse.Enums;
using SmartHouse.Helpers;
using SmartHouse.Interfaces;
using SmartHouse.Models;
using SmartHouse.Repository;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.SmartHouseSystems
{
    public class LightSystem:DeviceManager
    {
        public LightSystem()
        {
            InitDevices();
        }

        public LightDevice? GetDevice(string deviceName)
        {
            var device = GetDeviceById(deviceName) as LightDevice;
            if (device != null)
                return device;
            else
                return null;
        }

        public void InitDevices()
        {
            _devices.AddRange(InMemoryRepository.LightDevices);
        }


        public void ChangeLightColorAllDevices(LightColors color,LightDeviceTypes deviceType)
        {

            if (LightDeviceTypes.All == deviceType)
            {
                foreach (var device in _devices)
                {
                    LightDevice? lightDevice = device as LightDevice;
                    if (lightDevice != null && lightDevice.IsOn && lightDevice.SupportsRGB)
                    {
                        lightDevice.ChangeLightColor(color);
                        //Console.WriteLine($"Device{lightDevice.DeviceName} color changed to {color}.");
                    }
                }
            }
            else
            {
                foreach (var device in _devices)
                {
                    LightDevice? lightDevice = device as LightDevice;
                    if (lightDevice != null && lightDevice.IsOn && lightDevice.DeviceType == deviceType && lightDevice.SupportsRGB)
                    {
                        lightDevice.ChangeLightColor(color);
                        //Console.WriteLine($"Device{lightDevice.DeviceName} color changed to {color}.");
                    }
                }
            }

        }
        public void ChangeLightBrightness(int brightnesLevel,LightDeviceTypes deviceType)
        {

            if (LightDeviceTypes.All == deviceType)
            {
                foreach (var device in _devices)
                {
                    LightDevice? lightDevice = device as LightDevice;
                    if (lightDevice != null && lightDevice.IsOn)
                    {
                        lightDevice.ChangeLightBrightness(brightnesLevel);
                        //Console.WriteLine($"Device{lightDevice.DeviceName} brightnes level changed to {brightnesLevel}%.");
                    }
                }
            }
            else
            {
                foreach (var device in _devices)
                {
                    LightDevice? lightDevice = device as LightDevice;
                    if (lightDevice != null && lightDevice.IsOn && lightDevice.DeviceType == deviceType)
                    {
                        lightDevice.ChangeLightBrightness(brightnesLevel);
                        //Console.WriteLine($"Device{lightDevice.DeviceName} brightnes level changed to {brightnesLevel}%.");
                    }
                }
            }

        }

        public void ChangeColorTemperature(int temperature, LightDeviceTypes deviceType)
        {
            if (LightDeviceTypes.All == deviceType)
            {
                foreach (var device in _devices)
                {
                    LightDevice? lightDevice = device as LightDevice;
                    if (lightDevice != null && lightDevice.IsOn)
                    {
                        if (temperature <= lightDevice.MaxColorTemperature && temperature >= lightDevice.MinColorTemperature)
                        {
                            lightDevice.ChangeColorTemperature(temperature);
                           // Console.WriteLine($"Device{lightDevice.DeviceName} color temperature set to {temperature}K.");
                        }
                        else
                            Console.WriteLine("Entered temperature out of range");
                    }
                }
            }
            else
            {
                foreach (var device in _devices)
                {
                    LightDevice? lightDevice = device as LightDevice;
                    if (lightDevice != null && lightDevice.IsOn && lightDevice.DeviceType == deviceType)
                    {
                        if (temperature <= lightDevice.MaxColorTemperature && temperature >= lightDevice.MinColorTemperature)
                        {
                            lightDevice.ChangeColorTemperature(temperature);
                            Console.WriteLine($"Device{lightDevice.DeviceName} color temperature set to {temperature}K.");
                        }
                        else
                            Console.WriteLine("Entered temperature out of range");
                    }
                }
            }
        }

    }
}
