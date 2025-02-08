using SmartHouse.ClimateControlDevices;
using SmartHouse.Devices;
using SmartHouse.EntertainmetDevices;
using SmartHouse.Enums;
using SmartHouse.Models;
using SmartHouse.Repository;
using SmartHouse.SecurityDevices;
using SmartHouse.SmartHouseSystems;
using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace SmartHouse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            InMemoryRepository.PopulateRepository();

            LightSystem lightSystem = new LightSystem();
            EntertainmentSystem entertainmentSystem = new EntertainmentSystem();
            SecuritySystem securitySystem = new SecuritySystem();
            ClimateControlSystem climateControlSystem = new ClimateControlSystem();

            //LightSystem

            #region

            //lightSystem.AddDevice(new LightDevice("Hue2", "Philips", true, LightDeviceTypes.Lightbulb));
            //lightSystem.RemoveDevice("Hue2");
            //lightSystem.TurnOnAllDevices();
            //Console.WriteLine("----------------------------------");
            //lightSystem.ShowDevices();
            //Console.WriteLine("----------------------------------");
            //lightSystem.ChangeColorTemperature(4000, LightDeviceTypes.All);
            //Console.WriteLine("----------------------------------");
            //lightSystem.ChangeLightBrightness(85, LightDeviceTypes.Lightbulb);
            //Console.WriteLine("----------------------------------");
            //lightSystem.ChangeLightColorAllDevices(LightColors.Purple, LightDeviceTypes.LEDstrip);
            //Console.WriteLine("----------------------------------");

            //var device = lightSystem.GetDevice("Hue");
            //if (device != null)
            //{
            //    device.ChangeColorTemperature(4200);

            //    device.ChangeLightBrightness(20);
            //    device.ChangeLightColor(LightColors.Red);
            //    Console.WriteLine("----------------------------------");
            //    device.GetStatus();

            //}


            //lightSystem.TurnOffAllDevices();
            //Console.WriteLine("----------------------------------");
            //lightSystem.RemoveAllDevices();

            #endregion

            //EntertainmentSystem

            #region
            //entertainmentSystem.AddDevice(new SmartTV("Neo QLED2", "Samsung2", new List<ConnectivityTypes> { ConnectivityTypes.HDMI, ConnectivityTypes.DisplayPort }, new List<int> { 60, 120, 144, 165 }, new List<StreamingApps> { StreamingApps.Netflix, StreamingApps.HBOMax, StreamingApps.YouTube, StreamingApps.Spotify, StreamingApps.PrimeVideo }, new List<string> { "Analog", "Digital", "HDMI1", "HDMI2", "HDMI3" }, new List<string> { "1080p", "UHD", "4K", "4K UHD", "8K" }, new List<PictureModes> { PictureModes.Standard, PictureModes.Natural, PictureModes.Vivid, PictureModes.Game }, 50));
            //entertainmentSystem.RemoveDevice("Neo QLED2");
            //entertainmentSystem.TurnOnAllDevices();
            //Console.WriteLine("----------------------------------");
            //entertainmentSystem.ShowDevices();
            //Console.WriteLine("----------------------------------");
            //entertainmentSystem.ChangeVolumeAllDevices(21, EntertainmentDeviceTypes.All);
            //Console.WriteLine("----------------------------------");
            //entertainmentSystem.MuteAllDevices(EntertainmentDeviceTypes.All);
            //Console.WriteLine("----------------------------------");
            //entertainmentSystem.UnmuteAllDevices(EntertainmentDeviceTypes.Speaker);
            //Console.WriteLine("----------------------------------");
            //entertainmentSystem.UnmuteAllDevices(EntertainmentDeviceTypes.SmartTV);
            //Console.WriteLine("----------------------------------");

            //var smartTv=entertainmentSystem.GetDevice("Neo QLED") as SmartTV;
            //if(smartTv != null)
            //{
            //    smartTv.TurnOnAdaptiveBrigness();
            //    smartTv.ChangePictureMode(PictureModes.Vivid);
            //    Console.WriteLine("----------------------------------");
            //    smartTv.ChangeRefreshRate();
            //    Console.WriteLine("----------------------------------");
            //    smartTv.ChangeResolution();
            //    Console.WriteLine("----------------------------------");
            //    smartTv.OpenApp();
            //    Console.WriteLine("----------------------------------");
            //    smartTv.TurnOffAdaptiveBrigness();
            //}

            //var speaker1= entertainmentSystem.GetDevice("GO3") as Speaker;
            //var speaker2 = entertainmentSystem.GetDevice("Clip3") as Speaker;
            //var speaker3 = entertainmentSystem.GetDevice("Pill") as Speaker;

            //if (speaker1 != null && speaker2 != null&& speaker3 != null)
            //{
            //    speaker1.Bass = 20;
            //    speaker1.Treble = 86;
            //    speaker1.Mid = 12;

            //    Console.WriteLine($"Bass {speaker1.Bass} Treble {speaker1.Treble} Mid {speaker1.Mid}");
            //    speaker1.ChangeEqualizerMode(EqualizerModes.Concert);
            //    Console.WriteLine($"Bass {speaker1.Bass} Treble {speaker1.Treble} Mid {speaker1.Mid}");
            //    Console.WriteLine("----------------------------------");
            //    speaker1.ShowConnectedSpeakers();
            //    speaker1.ConnectDeviceToSpeaker(speaker2);
            //    speaker1.ShowConnectedSpeakers();
            //    speaker1.ConnectDeviceToSpeaker(speaker3);
            //    speaker1.ShowConnectedSpeakers();
            //    speaker1.ConnectDeviceToSpeaker(speaker2);
            //    speaker1.DisconnectDeviceFromSpeaker(speaker2);
            //    speaker1.ShowConnectedSpeakers();
            //}

            //var smartProjector = entertainmentSystem.GetDevice("TH575") as SmartProjector;
            //if(smartProjector != null)
            //{
            //    smartProjector.ChangeResolution();
            //    smartProjector.OpenApp();
            //    smartProjector.MuteDevice();
            //    smartProjector.UnmuteDevice();
            //    Console.WriteLine(smartProjector.CurrentApp);
            //    Console.WriteLine(smartProjector.Resolution);
            //    Console.WriteLine(smartProjector.MaxScreenSize);
            //    Console.WriteLine(smartProjector.MinScreenSize);
            //    smartProjector.ChangeScreenSize(75);
            //}

            #endregion


            //SecuritySystem

            #region

            //securitySystem.AddDevice(new SecurityCamera("Tapo Wire-Free2", "TP-Link2", "Garage2", new List<string> { "1080p", "UHD", "2K" }, 30, false, "2TB"));

            //securitySystem.TurnOnAllDevices();
            //Console.WriteLine("----------------------------------");
            //securitySystem.ShowDevices();
            //Console.WriteLine("----------------------------------");
            //securitySystem.ArmDevices(SecurityDeviceTypes.All);
            //securitySystem.DisarmDevices(SecurityDeviceTypes.MotionSensor);

            //var securityCamera = securitySystem.GetDevice("Tapo Wire-Free2") as SecurityCamera;
            //if (securityCamera != null)
            //{
            //    securityCamera.StartRecording();
            //    Console.WriteLine("----------------------------------");
            //    securityCamera.ChangeResolution();
            //    Console.WriteLine("----------------------------------");
            //    securityCamera.ChangeFPS(70);
            //    Console.WriteLine(securityCamera.FPS);
            //    Console.WriteLine("----------------------------------");
            //    securityCamera.ShowBatteryLevel();
            //    Console.WriteLine("----------------------------------");
            //    securityCamera.StopRecording();
            //    Console.WriteLine("----------------------------------");
            //    securityCamera.UpdateDeviceLocation("Living room");
            //    Console.WriteLine(securityCamera.Location);
            //    Console.WriteLine("----------------------------------");
            //    securityCamera.UpdateDeviceState(SecurityDeviceStates.Triggered);
            //    Console.WriteLine(securityCamera.State);
            //    Console.WriteLine("----------------------------------");
            //}
            //securitySystem.RemoveDevice("Tapo Wire-Free2");

            //var motionSensor = securitySystem.GetDevice("SmartThings Motion Sensor") as MotionSensor;
            //if (motionSensor != null)
            //{
            //    motionSensor.ShowBatteryLevel();
            //    Console.WriteLine("----------------------------------");
            //    motionSensor.UpdateDeviceLocation("Living room");
            //    Console.WriteLine(motionSensor.Location);
            //    Console.WriteLine("----------------------------------");
            //    motionSensor.UpdateDeviceState(SecurityDeviceStates.Triggered);
            //    Console.WriteLine(motionSensor.State);
            //    Console.WriteLine("----------------------------------");
            //}

            //var smartLock = securitySystem.GetDevice("TTLock Smart RFID") as SmartLock;
            //if (smartLock != null)
            //{
            //    smartLock.ShowBatteryLevel();
            //    Console.WriteLine("----------------------------------");
            //    smartLock.UpdateDeviceLocation("Bathroom");
            //    Console.WriteLine(smartLock.Location);
            //    Console.WriteLine("----------------------------------");
            //    smartLock.UnlockDoor();
            //    smartLock.LockDoor();
            //    Console.WriteLine("----------------------------------");
            //    smartLock.UpdateDeviceState(SecurityDeviceStates.Triggered);
            //    Console.WriteLine(smartLock.State);
            //    Console.WriteLine("----------------------------------");
            //}


            //lightSystem.TurnOffAllDevices();
            //Console.WriteLine("----------------------------------");
            //lightSystem.RemoveAllDevices();
            #endregion


            //ClimateControlSystem
            #region
            climateControlSystem.AddDevice(new AirConditioner("Vivax Cool2", "Vivax", new List<int> { 1, 2, 3, 4, 5 }, 40, 30, true, 21,true));
            //climateControlSystem.RemoveDevice("Vivax Cool2");
            climateControlSystem.TurnOnAllDevices();
            Console.WriteLine("----------------------------------");
            climateControlSystem.ShowDevices();
            Console.WriteLine("----------------------------------");
            climateControlSystem.ChangeFanSpeedOfAllDevices(2, ClimateControlDeviceTypes.All);
            Console.WriteLine("----------------------------------");
            climateControlSystem.ChangeFanSpeedOfAllDevices(3, ClimateControlDeviceTypes.Purifier);
            Console.WriteLine("----------------------------------");

            var airCon=climateControlSystem.GetDevice("Vivax Cool2") as AirConditioner;
            if(airCon != null)
            {
                Console.WriteLine(airCon.CurrentTemperature);
                Console.WriteLine("----------------------------------");
                Console.WriteLine(airCon.TargetTemperature);
                Console.WriteLine("----------------------------------");
                airCon.SetTemperature();
                Console.WriteLine(airCon.TargetTemperature);
                Console.WriteLine("----------------------------------");
                Console.WriteLine(airCon.Mode);
                airCon.ChangeMode();
                Console.WriteLine("----------------------------------");
                airCon.ScheduleWorkingTime("17:00", "20:30");
            }

            climateControlSystem.RemoveDevice("Vivax Cool2");

            var airPurifier= climateControlSystem.GetDevice("Dyson AirPurifier2") as AirPurifier;

            if(airPurifier != null)
            {
                airPurifier.GetStatus();
            }

            var airHumidifier = climateControlSystem.GetDevice("Ph3a Purifier") as AirHumidifier;
            if(airHumidifier != null)
            {
                Console.WriteLine(airHumidifier.MistOutputLevel);
                airHumidifier.SetMistOutput();
                Console.WriteLine(airHumidifier.MistOutputLevel);
                Console.WriteLine("----------------------------------");
                Console.WriteLine(airHumidifier.CurrentHumidity);
                Console.WriteLine(airHumidifier.TargetHumidity);
                airHumidifier.SetTargetHumidity();
                Console.WriteLine(airHumidifier.TargetHumidity);
                Console.WriteLine("----------------------------------");
                airHumidifier.ShowWaterLevel();
                Console.WriteLine("----------------------------------");
                Console.WriteLine(airHumidifier.CurrentFanSpeed); 
                airHumidifier.ChangeFanSpeed();
                Console.WriteLine(airHumidifier.CurrentFanSpeed);

            }
            #endregion

        }
    }
}
