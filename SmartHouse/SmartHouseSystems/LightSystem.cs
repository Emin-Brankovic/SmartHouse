using SmartHouse.Devices;
using SmartHouse.Enums;
using SmartHouse.Models;
using SmartHouse.Repository;

namespace SmartHouse.SmartHouseSystems
{
    public class LightSystem : DeviceManager
    {
        public LightSystem()
        {
            InitDevices();
        }

        public LightDevice? GetDevice(string deviceName)
        {
            var device = GetDeviceById(deviceName) as LightDevice;
            if (device != null)
                return device;
            else
                return null;
        }

        private void InitDevices()
        {
            _devices.AddRange(InMemoryRepository.LightDevices);
        }


        public void ChangeLightColorAllDevices(LightColors color, LightDeviceTypes deviceType)
        {

            Console.WriteLine($"Changing light color {deviceType} devices\n");
            foreach (var device in _devices)
            {
                LightDevice? lightDevice = device as LightDevice;
                if (lightDevice != null && lightDevice.IsOn && lightDevice.SupportsRGB &&
                 (deviceType == LightDeviceTypes.All || lightDevice.DeviceType == deviceType))
                {
                    lightDevice.ChangeLightColor(color);
                }
            }
        }
        public void ChangeLightBrightnessOnDevices(int brightnesLevel, LightDeviceTypes deviceType)
        {
            Console.WriteLine($"Changing brightness {deviceType} devices\n");
            foreach (var device in _devices)
            {
                LightDevice? lightDevice = device as LightDevice;
                if (lightDevice != null && lightDevice.IsOn &&
                 (deviceType == LightDeviceTypes.All || lightDevice.DeviceType == deviceType))
                {
                    lightDevice.ChangeLightBrightness(brightnesLevel);
                }
            }

        }

        public void ChangeColorTemperatureOnDevices(int temperature, LightDeviceTypes deviceType)
        {
            Console.WriteLine($"Changing color temperature {deviceType} devices\n");
            foreach (var device in _devices)
            {
                LightDevice? lightDevice = device as LightDevice;
                if (lightDevice != null && lightDevice.IsOn && 
                    (deviceType == LightDeviceTypes.All || lightDevice.DeviceType == deviceType))
                {
                    if (temperature <= lightDevice.MaxColorTemperature && temperature >= lightDevice.MinColorTemperature)
                    {
                        lightDevice.ChangeColorTemperature(temperature);
                    }
                    else
                        Console.WriteLine("Entered temperature out of range");
                }
            }
        }

    }
}
