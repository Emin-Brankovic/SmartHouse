using SmartHouse.Devices;
using SmartHouse.Enums;
using SmartHouse.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.SecurityDevices
{
    public class SecurityCamera : SecurityDevice
    {
        public SecurityCamera(string deviceName, string brand, string location, List<string> supportedResolutions, int fps, bool isRecording, 
            string capacity, SecurityDeviceTypes deviceType = SecurityDeviceTypes.SecurityCamera, bool connection = true) : base(deviceName, location, brand, deviceType, connection)
        {
            SupportedResolutions = supportedResolutions;
            FPS = fps;
            IsRecording = isRecording;
            Capacity = capacity;
        }

        public string Resolution { get; private set; }
        public List<string> SupportedResolutions { get; private set; } = new List<string>();
        private readonly int MinFPS = 30;
        private readonly int MaxFPS = 120;
        public int FPS { get; private set; }
        public bool IsRecording { get; private set; }
        public string Capacity { get; private set; }

        public void ChangeResolution()
        {
            Console.WriteLine("Change resolution");
            var selected = Helper.SelectSupported<string>(SupportedResolutions);
            if (selected != null)
                Resolution = selected;
            else
                Resolution = SupportedResolutions[0];

            Console.WriteLine($"{DeviceName} resolution changed to {Resolution}");
        }

        public void ChangeFPS(int fps)
        {
            Console.WriteLine($"Change the FPS, {DeviceName} supports between {MinFPS}-{MaxFPS}");
            if (fps >= MinFPS && fps<=MaxFPS)
           {
                FPS = fps;
           }
        }

        public void StartRecording()
        {
            IsRecording = true;
            Console.WriteLine("Recording started");
        }

        public void StopRecording()
        {
            IsRecording = false;
            Console.WriteLine("Recording stopped");
        }

        public override void GetStatus()
        {
            base.GetStatus();

            Console.WriteLine($"Resolution: {Resolution}");
            Console.WriteLine($"Supported Resolutions: {string.Join(", ", SupportedResolutions)}");
            Console.WriteLine($"FPS: {FPS} (Range: {MinFPS} - {MaxFPS})");
            Console.WriteLine($"Recording Status: {(IsRecording ? "Recording" : "Not Recording")}");
            Console.WriteLine($"Capacity: {Capacity}");

        }
    }
}
