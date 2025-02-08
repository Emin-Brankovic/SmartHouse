using SmartHouse.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.SecurityDevices
{
    public class SmartLock : SecurityDevice
    {
        public SmartLock(string deviceName, string brand, string location, bool isPINCode=false, bool isFingerPrint = false, bool isRFID = false, SecurityDeviceTypes deviceType = SecurityDeviceTypes.SmartLock, bool connection = true) 
            : base(deviceName, location, brand ,deviceType,connection)
        {
            IsPINCode = isPINCode;
            IsFingerPrint = isFingerPrint;
            IsRFID = isRFID;
        }

        public bool IsLocked { get; set; }
        public bool IsPINCode { get; set; }
        public bool IsFingerPrint { get; set; }
        public bool IsRFID { get; set; }

        public void LockDoor()
        {
            IsLocked = true;
            Console.WriteLine($"{DeviceName} is unlocked");
        }

        public void UnlockDoor()
        {
            IsLocked = false;
            Console.WriteLine($"{DeviceName} is locked");
        }
    }
}
