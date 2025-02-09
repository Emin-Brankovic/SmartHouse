using SmartHouse.Devices;
using SmartHouse.Models;
using SmartHouse.Repository;

namespace SmartHouse.SmartHouseSystems
{
    public class EntertainmentSystem : DeviceManager
    {
        public EntertainmentSystem()
        {
            InitDevices();
        }

        public EntertainmentDevice GetDevice(string deviceId)
        {
            var device = GetDeviceById(deviceId) as EntertainmentDevice;
            if (device != null)
                return device;
            else
                throw new Exception("Device not found");
        }

        private void InitDevices()
        {
            _devices.AddRange(InMemoryRepository.SmartTVs);
            _devices.AddRange(InMemoryRepository.SmartProjectors);
            _devices.AddRange(InMemoryRepository.Speakers);
        }


        public void MuteDevices(EntertainmentDeviceTypes deviceType)
        {
            Console.WriteLine($"Muting {deviceType} devices\n");

            foreach (var device in _devices)
            {
                EntertainmentDevice? entertainmentDevice = device as EntertainmentDevice;
                if (entertainmentDevice != null && entertainmentDevice.IsOn &&
                    (deviceType == EntertainmentDeviceTypes.All || entertainmentDevice.DeviceType == deviceType))
                {
                    entertainmentDevice.MuteDevice();

                }
            }

        }

        public void UnmuteDevices(EntertainmentDeviceTypes deviceType)
        {
            Console.WriteLine($"Unmuting {deviceType} devices\n");
            foreach (var device in _devices)
           {
               EntertainmentDevice? entertainmentDevice = device as EntertainmentDevice;
               if (entertainmentDevice != null && entertainmentDevice.IsOn &&
                  (deviceType == EntertainmentDeviceTypes.All || entertainmentDevice.DeviceType == deviceType))
               {
                   entertainmentDevice.UnmuteDevice();

               }
           }

        }

        public void ChangeVolumeDevices(int volume, EntertainmentDeviceTypes deviceType)
        {
            Console.WriteLine($"Changing volume {deviceType} devices\n");
            foreach (var device in _devices)
            {
                EntertainmentDevice? entertainmentDevice = device as EntertainmentDevice;
                if (entertainmentDevice != null && entertainmentDevice.IsOn &&
                   (deviceType == EntertainmentDeviceTypes.All || entertainmentDevice.DeviceType == deviceType))
                {
                    entertainmentDevice.CurrentVolume = volume;

                }
            }


        }
    }
}
