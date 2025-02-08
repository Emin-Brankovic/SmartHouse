﻿using SmartHouse.Devices;
using SmartHouse.Enums;
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
    public class SecuritySystem : DeviceManager
    {
        public SecuritySystem()
        {
            InitDevices();
        }

        public SecurityDevice? GetDevice(string deviceId)
        {
            var device = GetDeviceById(deviceId) as SecurityDevice;
            if (device != null)
                return device;
            else
                return null;
        }
        public void InitDevices()
        {
            _devices.AddRange(InMemoryRepository.SecurityCameras);
            _devices.AddRange(InMemoryRepository.SmartLocks);
            _devices.AddRange(InMemoryRepository.MotionSensors);

        }


        public void ArmDevices(SecurityDeviceTypes deviceType)
        {

            if (SecurityDeviceTypes.All == deviceType)
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
            else
            {
                foreach (var device in _devices)
                {
                    SecurityDevice? securityDevice = device as SecurityDevice;
                    if (securityDevice != null && securityDevice.IsOn && securityDevice.DeviceType == deviceType)
                    {
                        securityDevice.UpdateDeviceState(SecurityDeviceStates.Armed);
                        Console.WriteLine($"Device{securityDevice.DeviceName} is armed.");
                    }
                }
            }
        }

        public void DisarmDevices(SecurityDeviceTypes deviceType)
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

            if (SecurityDeviceTypes.All == deviceType)
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
            else
            {
                foreach (var device in _devices)
                {
                    SecurityDevice? securityDevice = device as SecurityDevice;
                    if (securityDevice != null && securityDevice.IsOn && securityDevice.DeviceType == deviceType)
                    {
                        securityDevice.UpdateDeviceState(SecurityDeviceStates.Disarmed);
                        Console.WriteLine($"Device{securityDevice.DeviceName} is disarmed.");
                    }
                }
            }
        }

    }
}
