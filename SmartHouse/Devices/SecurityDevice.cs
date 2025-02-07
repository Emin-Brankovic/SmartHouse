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

namespace SmartHouse.Devices
{
    public abstract class SecurityDevice : SmartHouseDevice  
    {
        public SecurityDevice(string deviceName,string location,string brand ,bool connection = true)
            : base(deviceName, brand, connection)
        {
            Location = location;
        }

        public int BatteryLevel { get; private set; } = 60;
        public string Location { get; private set; }
        public SecurityDeviceStates State { get; private set; } = SecurityDeviceStates.Disarmed;


        public void ShowBatteryLevel(int deviceId)
        {
            if (Helper.IsDeviceOn(this))
                Console.WriteLine($"Battery: {BatteryLevel}");
        }

        public void UpdateDeviceLocation(string location)
        {
            
            if (Helper.IsDeviceOn(this))
            {
                Location = location;
                Console.WriteLine($"Device location changed to: {location}");
            }
        }

        public void UpdateDeviceState(SecurityDeviceStates state)
        {
            if (Helper.IsDeviceOn(this))
            {
                State = state;
                Console.WriteLine($"Device state changed to: {state}");
            }
        }
    }
}
