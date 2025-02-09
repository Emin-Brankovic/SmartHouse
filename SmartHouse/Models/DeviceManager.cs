using SmartHouse.Interfaces;

namespace SmartHouse.Models
{
    public abstract class DeviceManager : IDeviceManager
    {
        protected List<SmartHouseDevice> _devices = new List<SmartHouseDevice>();


        public void AddDevice(SmartHouseDevice device)
        {
            _devices.Add(device);
            Console.WriteLine($"Device {device.DeviceName} was successfully added ");
        }

        public void RemoveDevice(string deviceName)
        {
            var device = _devices.FirstOrDefault(x => x.DeviceName.ToLower() == deviceName.ToLower());
            if (device != null)
            {
                _devices.Remove(device);
                Console.WriteLine($"Device {deviceName} was successfully removed ");
            }
            else
                Console.WriteLine($"Device with ID: {deviceName} was not found as a registred device in your house");
        }

        public void RemoveAllDevices()
        {
            Console.WriteLine("Removing devices");
            _devices.Clear();
        }

        public void ShowDevices()
        {
            if (_devices.Count < 1)
            {
                Console.WriteLine("No devices registered\n");
                return;
            }

            Console.WriteLine("Registered devices:");
            foreach (var device in _devices)
                Console.WriteLine($"{device.DeviceName} : {device.GetType().Name}");
        }

        public void TurnOffAllDevices()
        {
            Console.WriteLine("Turning off all devices");
            foreach (var device in _devices)
            {
                device.TurnOff();
            }
        }

        public void TurnOnAllDevices()
        {
            Console.WriteLine("Turning on all devices");
            foreach (var device in _devices)
            {
                device.TurnOn();
            }
        }

        //Znam da se treba dohvatati preko Id uređaja ali zbog jednostavnosti testiranja radim preko imena
        protected SmartHouseDevice? GetDeviceById(string deviceName)
        {
            var device = _devices.FirstOrDefault(x => x.DeviceName.ToLower() == deviceName.ToLower());
            if (device != null) return device;
            else
            {
                Console.WriteLine("Device not found");
                return null;
            }
        }
    }
}
