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
        public EntertainmentDevice(string deviceName, List<ConnectivityTypes> connectivityTypes,bool connection = true,int volume=10,int maxVolume=100,bool isMuted=false)
            : base(deviceName, connection)
        {
            CurrentVolume = volume;
            MaxVolume = maxVolume;
            IsMuted = isMuted;
            ConnectivityTypes = connectivityTypes;
        }

        public int CurrentVolume{ get; set; }
        public int MaxVolume { get; set; }  
        public bool IsMuted { get; set; }
        public List<ConnectivityTypes> ConnectivityTypes { get;  set; }

    }
}
