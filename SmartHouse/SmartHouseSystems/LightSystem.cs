﻿using SmartHouse.Devices;
using SmartHouse.Enums;
using SmartHouse.Helpers;
using SmartHouse.Interfaces;
using SmartHouse.Models;
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
        public LightDevice GetDevice(int deviceId)
        {
            var device = GetDeviceById(deviceId) as LightDevice;
            if (device != null)
                return device;
            else
                throw new Exception("Device not found");
        }



        public void ChangeLightColorAllDevices(LightColors color)
        {

            foreach (var device in _devices)
            {
                LightDevice? lightDevice = device as LightDevice;
                if (lightDevice != null && lightDevice.IsOn)
                {
                    lightDevice.ChangeLightColor(color);
                    Console.WriteLine($"Device{lightDevice.DeviceName} color changed to {color}.");
                }
            }

        }
        public void ChangeLightBrightnes(int brightnesLevel)
        {
            foreach (var device in _devices)
            {
                LightDevice? lightDevice = device as LightDevice;
                if (lightDevice != null && lightDevice.IsOn)
                {
                    lightDevice.ChangeLightBrightnes(brightnesLevel);
                    Console.WriteLine($"Device{lightDevice.DeviceName} brightnes level changed to {brightnesLevel}%.");
                }
            }

        }

        public void ChangeColorTemperature(int temperature)
        {
            foreach (var device in _devices)
            {
                LightDevice? lightDevice = device as LightDevice;
                if (lightDevice != null && lightDevice.IsOn)
                {
                    if (temperature <= lightDevice.MaxColorTemperature && temperature >= lightDevice.MinColorTemperature)
                    {
                        lightDevice.CurrentColorTemperature = temperature;
                        Console.WriteLine($"Device{lightDevice.DeviceName} color temperature set to {temperature}K.");
                    }
                    else
                        Console.WriteLine("Entered temperature out of range");
                }
            }
        }

    }
}
