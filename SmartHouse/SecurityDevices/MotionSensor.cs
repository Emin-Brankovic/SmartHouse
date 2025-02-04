using SmartHouse.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.SecurityDevices
{
    public class MotionSensor : SecurityDevice
    {
        public MotionSensor(string deviceName, string location,int sensitivity,int range ,bool connection = true) : base(deviceName, location, connection)
        {
            SensorSensitivity = sensitivity;
            DetectionRange = range;
        }

        public int SensorSensitivity { get; set; }
        public int DetectionRange { get; set; }

    }
}
