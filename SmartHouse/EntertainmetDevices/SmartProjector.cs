using SmartHouse.Devices;
using SmartHouse.Enums;
using SmartHouse.Helpers;

namespace SmartHouse.EntertainmetDevices
{
    public class SmartProjector : EntertainmentDevice
    {
        public SmartProjector(string deviceName, List<ConnectivityTypes> connectivityTypes, string brand, List<StreamingApps> supportedApps, List<string> supportedResolutions, bool builtInSpeakers, EntertainmentDeviceTypes deviceType = EntertainmentDeviceTypes.SmartProjector,
            int minScreenSize = 50, int maxScreenSize = 120, bool connection = true, int maxVolume = 100) : base(deviceName, connectivityTypes, brand, deviceType, connection, maxVolume)
        {
            SupportedApps = supportedApps;
            SupportedResolutions = supportedResolutions;
            MinScreenSize = minScreenSize;
            MaxScreenSize = maxScreenSize;
            BuiltInSpeakers = builtInSpeakers;
        }

        private int _currentScreenSize;


        public int Brightness { get; private set; } = 100;
        public string Resolution { get; private set; } = "1080p";
        public int MinScreenSize { get; private set; }
        public int MaxScreenSize { get; private set; }
        public int CurrentScreenSize
        {
            get => _currentScreenSize;
            set
            {
                if (value >= MinScreenSize && value <= MaxScreenSize)
                    _currentScreenSize = value;
                else if (value < MinScreenSize)
                    _currentScreenSize = MinScreenSize;
                else if (value > MaxScreenSize)
                    _currentScreenSize = MaxScreenSize;

            }
        }
        public bool BuiltInSpeakers { get; private set; }
        public string CurrentApp { get; private set; } = string.Empty;
        public List<StreamingApps> SupportedApps { get; private set; } = new List<StreamingApps>();
        public List<string> SupportedResolutions { get; private set; } = new List<string>();


        public void ChangeResolution()
        {
            Console.WriteLine("Change resolution");

            var selected = Helper.SelectSupported<string>(SupportedResolutions);
            if (selected != null)
                Resolution = selected;
            else
                Resolution = SupportedResolutions[0];

        }

        public void OpenApp()
        {
            Console.WriteLine("Open app");
            CurrentApp = Helper.SelectSupported<StreamingApps>(SupportedApps).ToString();
        }

        public void ChangeScreenSize(int screenSize)
        {
            if (screenSize >= MinScreenSize && screenSize <= MaxScreenSize)
            {
                _currentScreenSize = screenSize;
                Console.WriteLine($"{DeviceName} screen size changed to {screenSize}'' ");
            }
        }

        public override void GetStatus()
        {
            base.GetStatus();

            Console.WriteLine($"Resolution: {Resolution}");
            Console.WriteLine($"Brightness: {Brightness}%");
            Console.WriteLine($"Screen Size: {CurrentScreenSize} inches (Range: {MinScreenSize} - {MaxScreenSize} inches)");
            Console.WriteLine($"Built-In Speakers: {(BuiltInSpeakers ? "Yes" : "No")}");
            Console.WriteLine($"Current App: {(string.IsNullOrEmpty(CurrentApp) ? "None" : CurrentApp)}");
            Console.WriteLine($"Supported Resolutions: {string.Join(", ", SupportedResolutions)}");
            Console.WriteLine($"Supported Streaming Apps: {string.Join(", ", SupportedApps)}");
        }

    }
}
