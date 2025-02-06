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
        public SecurityDevice(string deviceName,string location,string brand ,bool connection = true)
            : base(deviceName, brand, connection)
        {
            Location = location;
        }

        public int BatteryLevel { get; set; } = 60;
        public string Location { get; set; }
        public SecurityDeviceStates State { get; set; } = SecurityDeviceStates.Disarmed;
    }
}
