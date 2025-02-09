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
        public MotionSensor(string deviceName, string brand, string location,int sensitivity,int range, SecurityDeviceTypes deviceType = SecurityDeviceTypes.MotionSensor, bool connection = true) : base(deviceName, location, brand,deviceType,connection)
        {
            SensorSensitivity = sensitivity;
            DetectionRange = range;
        }

        public int SensorSensitivity { get; private set; }
        public int DetectionRange { get; private set; }

        public override void GetStatus()
        {
            base.GetStatus();

            Console.WriteLine($"Sensor Sensitivity: {SensorSensitivity}");
            Console.WriteLine($"Detection Range: {DetectionRange} meters");
        }

    }
}
