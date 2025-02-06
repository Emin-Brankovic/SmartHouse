using SmartHouse.Devices;
using SmartHouse.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.EntertainmetDevices
{
    public class SmartProjector : EntertainmentDevice
    {
        public SmartProjector(string deviceName, List<ConnectivityTypes> connectivityTypes,string brand ,bool connection = true, int maxVolume = 100) : base(deviceName, connectivityTypes, brand,connection, maxVolume)
        {
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
            string userInput = string.Empty;
            int chosenRes;



            for (int i = 0; i < SupportedResolutions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {SupportedResolutions[i]}");
            }

            Console.WriteLine("Select resolution by entering the number");

            Console.WriteLine("----------------------------------------------");

            do
            {
                Console.Write("Choose resolution: ");
                userInput = Console.ReadLine();
            }
            while (!int.TryParse(userInput, out chosenRes) || chosenRes < 0 || chosenRes >= SupportedResolutions.Count);

            if (chosenRes <= SupportedResolutions.Count && chosenRes >= 0)
                Resolution = SupportedResolutions[chosenRes - 1].ToString();

        }

        public void OpenApp()
        {
            string userInput = string.Empty;
            int chosenApp;



            for (int i = 0; i < SupportedApps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {SupportedApps[i]}");
            }

            Console.WriteLine("Select App by entering the number");

            Console.WriteLine("----------------------------------------------");

            do
            {
                Console.Write("Choose Application: ");
                userInput = Console.ReadLine();
            }
            while (!int.TryParse(userInput, out chosenApp) || chosenApp < 0 || chosenApp >= SupportedApps.Count);

            if (chosenApp <= SupportedApps.Count && chosenApp >= 0)
                CurrentApp = SupportedApps[chosenApp].ToString();

        }


    }
}
