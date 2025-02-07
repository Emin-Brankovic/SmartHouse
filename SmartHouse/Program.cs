using SmartHouse.Devices;
using SmartHouse.EntertainmetDevices;
using SmartHouse.Enums;
using SmartHouse.Models;
using SmartHouse.Repository;
using SmartHouse.SmartHouseSystems;
using System;

namespace SmartHouse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            InMemoryRepository.PopulateRepository();


            //Console.WriteLine("Hello, World!");

            LightSystem lightSystem = new LightSystem();
            EntertainmentSystem entertainmentSystem = new EntertainmentSystem();
            SecuritySystem securitySystem = new SecuritySystem();

            //for (int i = 0; i < 5; i++)
            //{
            //    lightSystem.AddDevice(new LightDevice($"Light device {i+1}","Philips"));
            //}

            //for (int i = 0; i < 5; i++)
            //{
            //    entertainmentSystem.AddDevice(new EntertainmentDevice($"Entertainment device {i + 1}",
            //        new List<ConnectivityTypes> { ConnectivityTypes.Bluetooth,ConnectivityTypes.WiFi,ConnectivityTypes.Wired},
            //        "Samsung"));
            //}


            //for (int i = 0; i < 5; i++)
            //{
            //    securitySystem.AddDevice(new SecurityDevice($"Security device {i + 1}","Garage","Ring"));
            //}

            //lightSystem.TurnOnAllDevicesOn();

            //lightSystem.ChangeLightColor(1, LightColors.Blue);
            //lightSystem.ChangeLightBrightnes(1, 55);
            //lightSystem.ChangeLightColor(2, LightColors.Red);
            //lightSystem.ChangeLightColor(3, LightColors.Purple);
            //lightSystem.ChangeColorTemperature(4, 4500);


            //lightSystem.ShowDevices();
            //securitySystem.ShowDevices();
            //entertainmentSystem.ShowDevices();

            //Console.WriteLine("------------------------------------------");

            //try
            //{
            //    var lightdevice=lightSystem.GetDevice(12);
            //    Console.WriteLine(lightdevice.Color);
            //    Console.WriteLine(lightdevice.Brightnes);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //try
            //{
            //    var lightdevice1 = lightSystem.GetDevice(4);
            //    Console.WriteLine(lightdevice1.Color);
            //    Console.WriteLine(lightdevice1.Brightnes);
            //    Console.WriteLine(lightdevice1.CurrentColorTemperature);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}


            //var tv = new SmartTV("Gas TV", "Samsung", new List<ConnectivityTypes> { ConnectivityTypes.HDMI, ConnectivityTypes.DisplayPort }, new List<StreamingApps> { StreamingApps.Netflix, StreamingApps.HBOMax, StreamingApps.YouTube, StreamingApps.Spotify }, new List<string> { "Analog", "Digital", "HDMI1", "HDMI2" }, new List<string> { "1080p", "UHD", "4K", "4K UHD" }, 50);

            //tv.TurnOn();
            //Console.WriteLine(tv.Resolution);
            //tv.ChangeResolution();
            //Console.WriteLine(tv.Resolution);
            //Console.WriteLine(tv.PictureMode);
            //tv.ChangePictureMode(PictureModes.Vivid);
            //Console.WriteLine(tv.PictureMode);


            //var speaker1 = new Speaker("Speaker1", "JBL", new List<ConnectivityTypes> { ConnectivityTypes.AUX, ConnectivityTypes.Bluetooth }, true);

            //var speaker2 = new Speaker("Speaker2", "JBL", new List<ConnectivityTypes> { ConnectivityTypes.AUX, ConnectivityTypes.Bluetooth }, true);

            //var speaker3 = new Speaker("Speaker2", "JBL", new List<ConnectivityTypes> { ConnectivityTypes.AUX, ConnectivityTypes.Bluetooth }, true);

            entertainmentSystem.AddDevice(InMemoryRepository.SmartTVs[0]);
            entertainmentSystem.AddDevice(InMemoryRepository.SmartTVs[1]);
            entertainmentSystem.AddDevice(InMemoryRepository.Speakers[0]);
            entertainmentSystem.AddDevice(InMemoryRepository.Speakers[1]);
            entertainmentSystem.AddDevice(InMemoryRepository.Speakers[2]);
            entertainmentSystem.AddDevice(InMemoryRepository.SmartProjectors[0]);

            entertainmentSystem.TurnOnAllDevices();

            entertainmentSystem.MuteAllDevices();


            Console.WriteLine("------------------------------------");

            entertainmentSystem.UnmuteAllDevices();


            Console.WriteLine("------------------------------------");

            entertainmentSystem.ShowDevices();


            Console.WriteLine("------------------------------------");

            entertainmentSystem.ChangeVolumeAllDevices(50);


            //Console.WriteLine(InMemoryRepository.SmartTVs[0].DeviceId);
            //entertainmentSystem.RemoveDevice(19);

            //entertainmentSystem.RemoveAllDevices();

            // Console.WriteLine("------------------------------------");

            //entertainmentSystem.ShowDevices();

            //var speaker = InMemoryRepository.Speakers[0];
            //speaker.ChangeEqualizerMode(EqualizerModes.Studio);
            //Console.WriteLine($"{speaker.Bass} {speaker.Mid} {speaker.Treble}");
            //var speaker2 = InMemoryRepository.Speakers[1];

            //speaker.ConnectDeviceToSpeaker(speaker2);

            //speaker.ShowConnectedSpeakers();


            //var speaker3 = InMemoryRepository.Speakers[2];

            //speaker.ConnectDeviceToSpeaker(speaker3);

            //speaker.DisconnectDeviceFromSpeaker(speaker3);

            //speaker.ConnectDeviceToSpeaker(speaker2);



            //speaker.DisconnectDeviceFromSpeaker(speaker2);

            //speaker.ShowConnectedSpeakers();

             var tv=InMemoryRepository.SmartTVs[0];
            var tv2 = InMemoryRepository.SmartTVs[1];

            //foreach (var v in tv.SupportedPictureMode)
            //{
            //    Console.WriteLine(v);
            //}

            //Console.WriteLine("------------------------------------");

            //tv.ChangePictureMode(PictureModes.Vivid);
            //Console.WriteLine(tv.PictureMode);

            //Console.WriteLine(tv.RefreshRate);

            //Console.WriteLine("------------------------------------");
            //tv.ChangeRefreshRate();

            //Console.WriteLine(tv.RefreshRate);


            //Console.WriteLine("------------------------------------");
            //Console.WriteLine(tv.CurrentApp);
            //Console.WriteLine("------------------------------------");

            //tv.OpenApp();

            //Console.WriteLine(tv.CurrentApp);


            //Console.WriteLine(tv.Resolution);

            //tv.ChangeResolution();

            //Console.WriteLine(tv.Resolution);

        }
    }
}
