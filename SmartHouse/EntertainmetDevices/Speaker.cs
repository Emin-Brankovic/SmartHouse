using SmartHouse.Devices;
using SmartHouse.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.EntertainmetDevices
{
    public class Speaker : EntertainmentDevice
    {
        public Speaker(string deviceName, string brand ,List<ConnectivityTypes> types,bool multiDevice, bool connection = true, int maxVolume = 100) 
            : base(deviceName, types, brand, connection, maxVolume)
        {
            IsMultiDeviceSupport = multiDevice;
        }

        private int _bass = 50;
        private int _treble = 50;
        private int _mid = 50;

        public int Bass { 
            get=> _bass  ; 
            set
            {
                if(value>=0 && value <= 100)
                    _bass = value;
                else if(value<0)
                    _bass = 0;
                else if (value > 100)
                    _bass = 100;
            } 
        }

        public int Treble
        {
            get => _treble;
            set
            {
                if (value >= 0 && value <= 100)
                    _treble = value;
                else if (value < 0)
                    _treble = 0;
                else if (value > 100)
                    _treble = 100;
            }
        }

        public int Mid
        {
            get => _mid;
            set
            {
                if (value >= 0 && value <= 100)
                    _mid = value;
                else if (value < 0)
                    _mid = 0;
                else if (value > 100)
                    _mid = 100;
            }
        }

        public EqualizerModes EqualizerMode { get; private set; } = EqualizerModes.Standard;
        public bool IsMultiDeviceSupport { get; private set; }
        public List<Speaker> ConnectedDevices=new List<Speaker>();

        public void ChangeEqualizerMode(EqualizerModes mode)
        {
            switch (mode)
            {

                case EqualizerModes.BassBoost:
                    EqualizerMode = EqualizerModes.BassBoost;
                    _bass = 100;
                    _treble = 50;
                    _mid = 50;
                    break;


                case EqualizerModes.TrebleBoost: 
                    EqualizerMode=EqualizerModes.TrebleBoost;
                    _bass = 50;
                    _treble = 100;
                    _mid = 50;
                    break;

                case EqualizerModes.Studio:
                    EqualizerMode=EqualizerModes.Studio;
                    _bass = 30;
                    _treble = 60;
                    _mid = 80;
                    break;

                case EqualizerModes.Voice:
                    EqualizerMode = EqualizerModes.Voice;
                    _bass = 5;
                    _treble = 10;
                    _mid = 70;
                    break;

                case EqualizerModes.Concert:
                    EqualizerMode = EqualizerModes.Concert;
                    _bass = 40;
                    _treble = 70;
                    _mid = 50;
                    break;


                case EqualizerModes.Standard:
                    EqualizerMode = EqualizerModes.Standard;
                    _bass = 50;
                    _treble = 50;
                    _mid = 50;
                    break;

                default:
                    Console.WriteLine("Invalid command. Try again.");
                    break;
            }
        }


        public void ConnectDeviceToSpeaker(Speaker speaker)
        {
            if(!IsMultiDeviceSupport)
            {
                Console.WriteLine($"Speaker {DeviceName} does not support this feature");
                return;
            }

            if (!speaker.IsMultiDeviceSupport)
            {
                Console.WriteLine($"Speaker {speaker.DeviceName} does not support this feature");
                return;
            }

            if(string.Compare(Brand,speaker.Brand,true)!=0)
            {
                Console.WriteLine("Speakers are not the same brand");
                return;
            }

            if (!ConnectedDevices.Contains(speaker))
            {
                ConnectedDevices.Add(speaker);
                Console.WriteLine($"Speaker: {speaker.DeviceName} connected");
            }
            else
                Console.WriteLine($"Speaker {speaker.DeviceName}  already connected");


        }


        public void DisconnectDeviceFromSpeaker(Speaker speaker)
        {
            if (!IsMultiDeviceSupport)
            {
                Console.WriteLine($"Speaker {DeviceName} does not support this feature");
                return;
            }

            if (!speaker.IsMultiDeviceSupport)
            {
                Console.WriteLine($"Speaker {speaker.DeviceName} does not support this feature");
                return;
            }

            ConnectedDevices.Remove(speaker);
            Console.WriteLine($"Speaker: {speaker.DeviceName} is disconnected");
        }

        public void ShowConnectedSpeakers()
        {
            Console.WriteLine($"Connected speakers to {DeviceName} : ");
            foreach (Speaker speaker in ConnectedDevices)
            {
                Console.WriteLine(speaker.DeviceName);
            }
        }
    }
}
