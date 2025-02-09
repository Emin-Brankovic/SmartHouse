using SmartHouse.Devices;
using SmartHouse.Models;
using SmartHouse.Repository;

namespace SmartHouse.SmartHouseSystems
{
    public class ClimateControlSystem : DeviceManager
    {
        public ClimateControlSystem()
        {
            InitDevices();
        }

        public ClimateControlDevice? GetDevice(string deviceId)
        {
            var device = GetDeviceById(deviceId) as ClimateControlDevice;
            if (device != null)
                return device;
            else
                return null;
        }

        private void InitDevices()
        {
            _devices.AddRange(InMemoryRepository.AirAirHumidifiers);
            _devices.AddRange(InMemoryRepository.AirConditioners);
            _devices.AddRange(InMemoryRepository.AirPurifiers);
        }

        public void ChangeFanSpeedOfDevices(int fanSpeed, ClimateControlDeviceTypes deviceType)
        {
            Console.WriteLine($"Changing fan speed of {deviceType} devices to {fanSpeed} \n");

            foreach (var device in _devices)
            {
                ClimateControlDevice? climateControlDevice = device as ClimateControlDevice;
                if (climateControlDevice != null && climateControlDevice.IsOn &&
                    (deviceType == ClimateControlDeviceTypes.All || climateControlDevice.DeviceType == deviceType))
                {
                    climateControlDevice.CurrentFanSpeed = fanSpeed;

                }
            }

        }
    }
}
