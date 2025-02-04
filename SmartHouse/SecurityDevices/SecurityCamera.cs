using SmartHouse.Devices;
using SmartHouse.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.SecurityDevices
{
    public class SecurityCamera : SecurityDevice
    {
        public SecurityCamera(string deviceName, string location, string resolution, int fps, bool isRecording, int capacity, bool connection = true) : base(deviceName, location, connection)
        {
            Resolution = resolution;
            FPS = fps;
            IsRecording = isRecording;
            Capacity = capacity;
        }

        public string Resolution { get; private set; }
        private readonly int MinFPS = 30;
        private readonly int MaxFPS = 120;
        public int FPS { get; private set; }
        public bool IsRecording { get; private set; }
        public int Capacity { get; private set; }

        public void ChangeResolution(string resolution)
        {
            Resolution = resolution;
        }

        public void ChangeFPS(int fps)
        {
           if(fps >= MinFPS && fps<=MaxFPS)
           {
                FPS = fps;
           }
        }

        public void StartRecording()
        {
            IsRecording = true;
        }

        public void StopRecording()
        {
            IsRecording = false;
        }

    }
}
