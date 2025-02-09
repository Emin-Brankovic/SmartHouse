using SmartHouse.Devices;
using SmartHouse.Enums;
using SmartHouse.Models;
using SmartHouse.Repository;

namespace SmartHouse.SmartHouseSystems
{
    public class SecuritySystem : DeviceManager
    {
        public SecuritySystem()
        {
            InitDevices();
        }

        public SecurityDevice? GetDevice(string deviceId)
        {
            var device = GetDeviceById(deviceId) as SecurityDevice;
            if (device != null)
                return device;
            else
                return null;
        }
        private void InitDevices()
        {
            _devices.AddRange(InMemoryRepository.SecurityCameras);
            _devices.AddRange(InMemoryRepository.SmartLocks);
            _devices.AddRange(InMemoryRepository.MotionSensors);

        }


        public void ArmDevices(SecurityDeviceTypes deviceType)
        {

            Console.WriteLine($"Arming {deviceType} devices\n");
            foreach (var device in _devices)
            {
                SecurityDevice? securityDevice = device as SecurityDevice;
                if (securityDevice != null && securityDevice.IsOn &&
                  (deviceType == SecurityDeviceTypes.All || securityDevice.DeviceType == deviceType))
                {
                    securityDevice.UpdateDeviceState(SecurityDeviceStates.Armed);
                }
            }
            Console.WriteLine("\nSecurity system armed.");
           
        }

        public void DisarmDevices(SecurityDeviceTypes deviceType)
        {
            Console.WriteLine($"Disarming {deviceType} devices\n");
            foreach (var device in _devices)
            {
                SecurityDevice? securityDevice = device as SecurityDevice;
                if (securityDevice != null && securityDevice.IsOn &&
                   (deviceType == SecurityDeviceTypes.All || securityDevice.DeviceType == deviceType))
                {
                    securityDevice.UpdateDeviceState(SecurityDeviceStates.Disarmed);
                }
            }
            Console.WriteLine("\nSecurity system disarmed.");
        }

    }
}
