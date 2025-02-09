using SmartHouse.Enums;
using SmartHouse.Helpers;
using SmartHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Devices
{

    public enum EntertainmentDeviceTypes
    {
        Speaker,
        SmartTV,
        SmartProjector,
        All
    }

    public abstract class EntertainmentDevice : SmartHouseDevice
    {
        public EntertainmentDevice(string deviceName, List<ConnectivityTypes> connectivityTypes,string brand,
            EntertainmentDeviceTypes deviceType, bool connection = true,int maxVolume=100)
            : base(deviceName, brand ,connection)
        {
            MaxVolume = maxVolume;
            ConnectivityTypes = connectivityTypes;
            DeviceType = deviceType;
        }

        private int _currentVolume=20;

        public int CurrentVolume
        {
            get => _currentVolume;
            set
            {
                if(value>=0 && value<=MaxVolume)
                    _currentVolume = value;
                else if(value<0)
                    _currentVolume = 0;
                else if(value > MaxVolume)
                    _currentVolume = MaxVolume;
                Console.WriteLine($"{DeviceName} volume set to: {_currentVolume}");
            }
        }
        private int MaxVolume { get; set; }
        public bool IsMuted { get; private set; }
        public List<ConnectivityTypes> ConnectivityTypes { get; private set; }
        public EntertainmentDeviceTypes DeviceType { get; private set; }


        public void MuteDevice()
        {
            if (Helper.IsDeviceOn(this))
            {
                if (IsMuted)
                {
                    Console.WriteLine($"{DeviceName} already muted");
                    return;
                }
                IsMuted = true;
                Console.WriteLine($"{DeviceName} muted");
            }
        }

        public void UnmuteDevice()
        {
            if (Helper.IsDeviceOn(this))
            {
                if (!IsMuted)
                {
                    Console.WriteLine($"{DeviceName} already unmuted");
                    return;
                }

                IsMuted = false;
                Console.WriteLine($"{DeviceName} unmuted");
            }
        }

        public override void GetStatus()
        {
            base.GetStatus();
            Console.WriteLine($"Device Type: {DeviceType}");
            Console.WriteLine($"Current Volume: {(IsMuted ? "Muted" : CurrentVolume.ToString())}");
            Console.WriteLine($"Max Volume: {MaxVolume}");
            Console.WriteLine($"Connectivity: {string.Join(", ", ConnectivityTypes)}");
        }
    }
}
