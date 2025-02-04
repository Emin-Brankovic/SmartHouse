using SmartHouse.Enums;
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
    public class SecurityDevice : SmartHouseDevice
    {
        public SecurityDevice(string deviceName,string location ,bool connection = true,int batteryLevel=60,SecurityDeviceStates state=SecurityDeviceStates.Disarmed)
            : base(deviceName, connection)
        {
            Location = location;
            BatteryLevel=batteryLevel; 
            State = state;
        }

        public int BatteryLevel { get; set; }
        public string Location { get; set; }
        public SecurityDeviceStates State { get; set; }
    }
}
