using SmartHouse.Enums;
using SmartHouse.Helpers;
using SmartHouse.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Devices
{
    public abstract class LightDevice : SmartHouseDevice
    {
        public LightDevice(string deviceName, string brand ,bool connection = true,LightColors color=LightColors.White, int brightnes=100,
            int colorTemperature=3000) 
            : base(deviceName,brand,connection)
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


        public void ChangeLightColor(LightColors color)
        {
 
            if(Helper.IsDeviceOn(this))
            {
                Color = color;
                Console.WriteLine($"Color set to {color}.");
            }

        }
        public void ChangeLightBrightnes(int brightnesLevel)
        {

            if (Helper.IsDeviceOn(this))
            {
                if(brightnesLevel>=0 &&  brightnesLevel<=100)
                {
                    Brightnes = brightnesLevel;
                    Console.WriteLine($"Brightness set to {brightnesLevel}.");
                }
                else if(brightnesLevel<0)
                {
                    Brightnes = 0;
                    Console.WriteLine($"Brightness set to 0.");
                }
                else if (brightnesLevel > 100)
                {
                    Brightnes = 100;
                    Console.WriteLine($"Brightness set to 100.");
                }

            }
            
        }

        public void ChangeColorTemperature(int temperature)
        {
           
            if (Helper.IsDeviceOn(this))
            {
                if (temperature <=MaxColorTemperature && temperature >= MinColorTemperature)
                {
                    CurrentColorTemperature = temperature;
                    Console.WriteLine($"Color temperature set to {CurrentColorTemperature}K.");
                }
                else
                    Console.WriteLine("Entered temperature out of range");
            }
        }

    }
}
