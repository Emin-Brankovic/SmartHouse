using SmartHouse.Enums;
using SmartHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Devices
{
    public class EntertainmentDevice : SmartHouseDevice
    {
        public EntertainmentDevice(string deviceName, List<ConnectivityTypes> connectivityTypes,string brand,
            bool connection = true,int maxVolume=100)
            : base(deviceName, brand ,connection)
        {
            MaxVolume = maxVolume;
            ConnectivityTypes = connectivityTypes;
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
            }
        }
        public int MaxVolume { get; set; }
        public bool IsMuted { get; set; }
        public List<ConnectivityTypes> ConnectivityTypes { get;  set; }
        public string CurrentlyPlaying { get; set; }=string.Empty;

    }
}
