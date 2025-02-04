using SmartHouse.Devices;
using SmartHouse.Enums;
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
        public void ChangeLightColor(int deviceId,LightColors color)
        {
            var lightDevice = _devices.FirstOrDefault(x => x.DeviceId == deviceId) as LightDevice;
            if (lightDevice != null)
                lightDevice.Color = color;
            else
            {
                Console.WriteLine("Could not change color");
                return;
            }

        }
        public void ChangeLightBrightnes(int deviceId, int brightnesLevel)
        {
            var lightDevice = _devices.FirstOrDefault(x => x.DeviceId == deviceId) as LightDevice;
            if (lightDevice != null)
                lightDevice.Brightnes = brightnesLevel;
            else
            {
                Console.WriteLine("Could not change brightnes");
                return;
            }
        }
    }
}
