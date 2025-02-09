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

    public enum SecurityDeviceTypes
    {
        SecurityCamera,
        MotionSensor,
        SmartLock,
        All
    }

    public abstract class SecurityDevice : SmartHouseDevice  
    {
        public SecurityDevice(string deviceName,string location,string brand, SecurityDeviceTypes deviceType, bool connection = true)
            : base(deviceName, brand, connection)
        {
            Location = location;
            DeviceType = deviceType;
        }

        public int BatteryLevel { get; private set; } = 60;
        public string Location { get; private set; }
        public SecurityDeviceStates State { get; private set; } = SecurityDeviceStates.Disarmed;
        public SecurityDeviceTypes DeviceType { get; private set; }

        public void ShowBatteryLevel()
        {
            if (Helper.IsDeviceOn(this))
                Console.WriteLine($"Battery level for {DeviceName}: {BatteryLevel}");
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
                Console.WriteLine($"{DeviceName} state changed to: {state}");
            }
        }

        public override void GetStatus()
        {
            base.GetStatus();

            Console.WriteLine($"Device Type: {DeviceType}");
            Console.WriteLine($"Battery Level: {BatteryLevel}%");
            Console.WriteLine($"Location: {Location}");
            Console.WriteLine($"Device State: {State}");
        }

    }
}
