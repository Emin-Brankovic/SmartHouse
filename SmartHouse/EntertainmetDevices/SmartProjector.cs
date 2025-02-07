using SmartHouse.Devices;
using SmartHouse.Enums;
using SmartHouse.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.EntertainmetDevices
{
    public class SmartProjector : EntertainmentDevice
    {
        public SmartProjector(string deviceName, List<ConnectivityTypes> connectivityTypes,string brand, List<StreamingApps> supportedApps, List<string> supportedResolutions,bool builtInSpeakers,
            int minScreenSize=50,int maxScreenSize=120, bool connection = true, int maxVolume = 100) : base(deviceName, connectivityTypes, brand,connection, maxVolume)
        {
            SupportedApps = supportedApps;
            SupportedResolutions = supportedResolutions;
            MinScreenSize = minScreenSize;
            MaxScreenSize = maxScreenSize;
            BuiltInSpeakers = builtInSpeakers;
        }

        private int _currentScreenSize;
            

        public int Brightness { get; set; } = 100;
        public string Resolution { get; private set; } = "1080p";
        public int MinScreenSize { get; private set; } 
        public int MaxScreenSize { get; private set; } 
        public int CurrentScreenSize { get=>_currentScreenSize;
            set 
            {
                if (value >= MinScreenSize && value <= MaxScreenSize)
                    _currentScreenSize = value;
                else if (value < MinScreenSize)
                    _currentScreenSize = MinScreenSize;
                else if (value > MaxScreenSize)
                    _currentScreenSize = MaxScreenSize;

            } }
        public bool BuiltInSpeakers { get; private set; }
        public string CurrentApp { get; private set; } = string.Empty;
        public List<StreamingApps> SupportedApps { get; set; } = new List<StreamingApps>();
        public List<string> SupportedResolutions { get; private set; } = new List<string>();


        public void ChangeResolution()
        {
            var selected = Helper.SelectSupported<string>(SupportedResolutions);
            if (selected != null)
                Resolution = selected;
            else
                Resolution = SupportedResolutions[0];

        }

        public void OpenApp()
        {
            CurrentApp = Helper.SelectSupported<StreamingApps>(SupportedApps).ToString();
        }


    }
}
