using SmartHouse.Devices;

namespace SmartHouse.SecurityDevices
{
    public class SmartLock : SecurityDevice
    {
        public SmartLock(string deviceName, string brand, string location, bool isPINCode = false, bool isFingerPrint = false, bool isRFID = false, SecurityDeviceTypes deviceType = SecurityDeviceTypes.SmartLock, bool connection = true)
            : base(deviceName, location, brand, deviceType, connection)
        {
            IsPINCode = isPINCode;
            IsFingerPrint = isFingerPrint;
            IsRFID = isRFID;
        }

        public bool IsLocked { get; private set; }
        public bool IsPINCode { get; private set; }
        public bool IsFingerPrint { get; private set; }
        public bool IsRFID { get; private set; }

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

        public override void GetStatus()
        {
            base.GetStatus();

            Console.WriteLine($"Device Locked: {(IsLocked ? "Locked" : "Unlocked")}");
            Console.WriteLine($"PIN Code Authentication: {(IsPINCode ? "Supported" : "Unsupported")}");
            Console.WriteLine($"Fingerprint Authentication: {(IsFingerPrint ? "Supported" : "Unsupported")}");
            Console.WriteLine($"RFID Authentication: {(IsRFID ? "Supported" : "Unsupported")}");
        }
    }
}
