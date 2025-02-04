using SmartHouse.Enums;
using SmartHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Devices
{
    public class LightDevice : SmartHouseDevice
    {
        public LightDevice(string deviceName, bool connection = true,LightColors color=LightColors.White, int brightnes=100,
            int colorTemperature=3000) 
            : base(deviceName, connection)
        {
            Color = color;
            Brightnes = brightnes;
            CurrentColorTemperature = 3000;
        }

        public LightColors Color { get; set; }
        public int Brightnes { get; set; }
        public readonly int MaxColorTemperature = 6500;
        public readonly int MinColorTemperature = 2700; 
        public int CurrentColorTemperature { get; set; }


    }
}
