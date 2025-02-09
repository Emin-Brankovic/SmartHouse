using SmartHouse.Devices;
using SmartHouse.Enums;
using SmartHouse.Helpers;

namespace SmartHouse.EntertainmetDevices
{
    public class SmartTV : EntertainmentDevice
    {
        public SmartTV(string deviceName, string brand, List<ConnectivityTypes> connectivityTypes, List<int> supportedRefreshRates,
            List<StreamingApps> apps, List<string> sources, List<string> supportedResolutions, List<PictureModes> supportedPictureMode, int screenSize, EntertainmentDeviceTypes deviceType = EntertainmentDeviceTypes.SmartTV, bool connection = true, int maxVolume = 100) : base(deviceName, connectivityTypes, brand, deviceType, connection, maxVolume)
        {
            SupportedApps = apps;
            Sources = sources;
            SupportedResolutions = supportedResolutions;
            ScreenSize = screenSize;
            SupportedRefreshRates = supportedRefreshRates;
            SupportedPictureMode = supportedPictureMode;
        }

        public int RefreshRate { get; private set; } = 60;
        public List<int> SupportedRefreshRates { get; private set; } = new List<int>();
        public bool IsAdaptiveBrightness { get; private set; }
        public List<PictureModes> SupportedPictureMode { get; private set; } = new List<PictureModes>();
        public PictureModes PictureMode { get; private set; } = PictureModes.Standard;
        public int Brightness { get; private set; } = 100;
        public int Contrast { get; private set; } = 50;
        public int Sharpness { get; private set; } = 50;
        public int Color { get; private set; } = 50;
        public string Resolution { get; private set; } = "1080p";
        public List<string> SupportedResolutions { get; private set; } = new List<string>();
        public string CurrentApp { get; private set; } = string.Empty;
        public List<StreamingApps> SupportedApps { get; private set; } = new List<StreamingApps>();
        public List<string> Sources { get; private set; } = new List<string>();
        public string Source { get; private set; } = "HDMI1";
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
            Console.WriteLine($"{DeviceName} picture mode changed to {PictureMode}");
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
            CurrentApp = Helper.SelectSupported<StreamingApps>(SupportedApps).ToString();
            Console.WriteLine($"{CurrentApp} opened on {DeviceName}");
        }

        public void ChangeResolution()
        {

            var selected = Helper.SelectSupported<string>(SupportedResolutions);
            if (selected != null)
                Resolution = selected;
            else
                Resolution = SupportedResolutions[0];

            Console.WriteLine($"{DeviceName} resolution changed to {Resolution}");


        }

        public void ChangeRefreshRate()
        {
            RefreshRate = Helper.SelectSupported<int>(SupportedRefreshRates);
            Console.WriteLine($"{DeviceName} refreshrate changed to {RefreshRate}");
        }

        public override void GetStatus()
        {
            base.GetStatus();

            Console.WriteLine($"Resolution: {Resolution}");
            Console.WriteLine($"Screen Size: {ScreenSize} inches");
            Console.WriteLine($"Brightness: {Brightness}%");
            Console.WriteLine($"Contrast: {Contrast}%");
            Console.WriteLine($"Sharpness: {Sharpness}%");
            Console.WriteLine($"Color: {Color}%");
            Console.WriteLine($"Refresh Rate: {RefreshRate}Hz");
            Console.WriteLine($"Adaptive Brightness: {(IsAdaptiveBrightness ? "Enabled" : "Disabled")}");
            Console.WriteLine($"Picture Mode: {PictureMode}");
            Console.WriteLine($"Current App: {(string.IsNullOrEmpty(CurrentApp) ? "None" : CurrentApp)}");
            Console.WriteLine($"Source: {Source}");
            Console.WriteLine($"Supported Resolutions: {string.Join(", ", SupportedResolutions)}");
            Console.WriteLine($"Supported Refresh Rates: {string.Join(", ", SupportedRefreshRates)}");
            Console.WriteLine($"Supported Streaming Apps: {string.Join(", ", SupportedApps)}");
            Console.WriteLine($"Supported Picture Modes: {string.Join(", ", SupportedPictureMode)}");
            Console.WriteLine($"Available Sources: {string.Join(", ", Sources)}");
        }

    }

}
