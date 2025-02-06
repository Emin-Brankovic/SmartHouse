using SmartHouse.Devices;
using SmartHouse.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.EntertainmetDevices
{
    public class SmartTV : EntertainmentDevice
    {
        public SmartTV(string deviceName, string brand ,List<ConnectivityTypes> connectivityTypes,List<StreamingApps> apps,
            List<string> sources,List<string> supportedResolutions, int screenSize, bool connection = true, int maxVolume = 100) 
            : base(deviceName, connectivityTypes, brand, connection, maxVolume)
        {
            SupportedApps = apps;
            Sources = sources;
            SupportedResolutions = supportedResolutions;
            ScreenSize = screenSize;
        }

        public int RefreshRate { get; set; } = 60;
        public bool IsAdaptiveBrightness { get; set; }
        public PictureModes PictureMode { get; set; } = PictureModes.Standard;
        public int Brightness { get; set; } = 100;
        public int Contrast { get; set; } = 50;
        public int Sharpness { get; set; } = 50;
        public int Color { get; set; } = 50;
        public string Resolution { get; private set; } = "1080p";
        public List<string> SupportedResolutions { get; private set; }=new List<string>();
        public string CurrentApp { get; private set; }=string.Empty;
        public List<StreamingApps> SupportedApps { get; set; } = new List<StreamingApps>();
        public List<string> Sources { get; private set; }=new List<string>();
        public string Source { get; set; } = "HDMI1";
        public int ScreenSize { get; private set; }

        public void ChangePictureMode(PictureModes mode)
        {
            switch (mode)
            {
                case PictureModes.Standard:
                    PictureMode = PictureModes.Standard;
                    Brightness = 100;
                    Contrast = 50;
                    Sharpness = 50;
                    Color = 50;
                    break;

                case PictureModes.Vivid:
                    PictureMode = PictureModes.Vivid;
                    Brightness = 100;
                    Contrast = 50;
                    Sharpness = 50;
                    Color = 80;
                    break;

                case PictureModes.Movie:
                    PictureMode = PictureModes.Movie;
                    Brightness = 80;
                    Contrast = 50;
                    Sharpness = 20;
                    Color = 70;
                    break;

                case PictureModes.Game:
                    PictureMode = PictureModes.Game;
                    Brightness = 100;
                    Contrast = 50;
                    Sharpness = 70;
                    Color = 70;
                    RefreshRate = 120;
                    break;

                case PictureModes.Natural:
                    PictureMode = PictureModes.Natural;
                    Brightness = 100;
                    Contrast = 50;
                    Sharpness = 90;
                    Color = 90;
                    break;

                default:
                    Console.WriteLine("Invalid command. Try again.");
                    break;
            }
        }

        public void TurnOnAdaptiveBrigness()
        {
            IsAdaptiveBrightness = true;
        }
        public void TurnOffAdaptiveBrigness()
        {
            IsAdaptiveBrightness = false;
        }

        public void OpenApp()
        {
            string userInput=string.Empty;
            int chosenApp;

            

            for (int i = 0; i <SupportedApps.Count; i++)
            {
                Console.WriteLine($"{i+1}. {SupportedApps[i]}");
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
                Resolution = SupportedResolutions[chosenRes-1].ToString();

        }


    }

}
