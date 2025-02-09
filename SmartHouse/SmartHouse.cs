using SmartHouse.ClimateControlDevices;
using SmartHouse.Devices;
using SmartHouse.EntertainmetDevices;
using SmartHouse.Enums;
using SmartHouse.SecurityDevices;
using SmartHouse.SmartHouseSystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    public static class SmartHouse
    {
        public static LightSystem lightSystem { get; set; } = new LightSystem();

        public static EntertainmentSystem entertainmentSystem { get; set; } = new EntertainmentSystem();
        public static SecuritySystem securitySystem { get; set; } = new SecuritySystem();
        public  static ClimateControlSystem climateControlSystem { get; set; } = new ClimateControlSystem();

        public static void LightSystemFunctionalities()
        {

            lightSystem.AddDevice(new LightDevice("Hue2", "Philips", true, LightDeviceTypes.Lightbulb));
            lightSystem.RemoveDevice("Hue2");
            lightSystem.TurnOnAllDevices();
            Console.WriteLine("----------------------------------");
            lightSystem.ShowDevices();
            Console.WriteLine("----------------------------------");
            lightSystem.ChangeColorTemperature(4000, LightDeviceTypes.All);
            Console.WriteLine("----------------------------------");
            lightSystem.ChangeLightBrightnessOnDevices(85, LightDeviceTypes.Lightbulb);
            Console.WriteLine("----------------------------------");
            lightSystem.ChangeLightColorAllDevices(LightColors.Purple, LightDeviceTypes.LEDstrip);
            Console.WriteLine("----------------------------------");

            var device = lightSystem.GetDevice("Hue");
            if (device != null)
            {
                device.ChangeColorTemperature(4200);

                device.ChangeLightBrightness(20);
                device.ChangeLightColor(LightColors.Red);
                Console.WriteLine("----------------------------------");
                device.GetStatus();

            }

            lightSystem.TurnOffAllDevices();
            Console.WriteLine("----------------------------------");
            lightSystem.RemoveAllDevices();
        }

        public static void EntertainmentSystemFunctionalities()
        {
            entertainmentSystem.AddDevice(new SmartTV("Neo QLED2", "Samsung2", new List<ConnectivityTypes> { ConnectivityTypes.HDMI, ConnectivityTypes.DisplayPort }, new List<int> { 60, 120, 144, 165 }, new List<StreamingApps> { StreamingApps.Netflix, StreamingApps.HBOMax, StreamingApps.YouTube, StreamingApps.Spotify, StreamingApps.PrimeVideo }, new List<string> { "Analog", "Digital", "HDMI1", "HDMI2", "HDMI3" }, new List<string> { "1080p", "UHD", "4K", "4K UHD", "8K" }, new List<PictureModes> { PictureModes.Standard, PictureModes.Natural, PictureModes.Vivid, PictureModes.Game }, 50));

            entertainmentSystem.RemoveDevice("Neo QLED2");
            entertainmentSystem.TurnOnAllDevices();
            Console.WriteLine("----------------------------------");
            entertainmentSystem.ShowDevices();
            Console.WriteLine("----------------------------------");
            entertainmentSystem.ChangeVolumeAllDevices(21, EntertainmentDeviceTypes.All);
            Console.WriteLine("----------------------------------");
            entertainmentSystem.MuteAllDevices(EntertainmentDeviceTypes.All);
            Console.WriteLine("----------------------------------");
            entertainmentSystem.UnmuteAllDevices(EntertainmentDeviceTypes.Speaker);
            Console.WriteLine("----------------------------------");
            entertainmentSystem.UnmuteAllDevices(EntertainmentDeviceTypes.SmartTV);
            Console.WriteLine("----------------------------------");

            Console.WriteLine("=====Smart TV Functionalities=====");
            var smartTv = entertainmentSystem.GetDevice("Neo QLED") as SmartTV;
            if (smartTv != null)
            {
                smartTv.TurnOnAdaptiveBrigness();
                smartTv.ChangePictureMode(PictureModes.Vivid);
                Console.WriteLine("----------------------------------");
                smartTv.ChangeRefreshRate();
                Console.WriteLine("----------------------------------");
                smartTv.ChangeResolution();
                Console.WriteLine("----------------------------------");
                smartTv.OpenApp();
                Console.WriteLine("----------------------------------");
                smartTv.TurnOffAdaptiveBrigness();
                Console.WriteLine("\n==========================================\n");

                smartTv.GetStatus();

                Console.WriteLine("\n==========================================\n");

            }
            Console.WriteLine("=====Speaker Functionalities=====");

            var speaker1 = entertainmentSystem.GetDevice("GO3") as Speaker;
            var speaker2 = entertainmentSystem.GetDevice("Clip3") as Speaker;
            var speaker3 = entertainmentSystem.GetDevice("Pill") as Speaker;

            if (speaker1 != null && speaker2 != null && speaker3 != null)
            {
                speaker1.Bass = 20;
                speaker1.Treble = 86;
                speaker1.Mid = 12;

                Console.WriteLine($"Bass {speaker1.Bass} Treble {speaker1.Treble} Mid {speaker1.Mid}");
                speaker1.ChangeEqualizerMode(EqualizerModes.Concert);
                Console.WriteLine($"Bass {speaker1.Bass} Treble {speaker1.Treble} Mid {speaker1.Mid}");
                Console.WriteLine("----------------------------------");
                speaker1.ShowConnectedSpeakers();
                speaker1.ConnectDeviceToSpeaker(speaker2);
                speaker1.ShowConnectedSpeakers();
                speaker1.ConnectDeviceToSpeaker(speaker3);
                speaker1.ShowConnectedSpeakers();
                speaker1.ConnectDeviceToSpeaker(speaker2);
                speaker1.DisconnectDeviceFromSpeaker(speaker2);
                speaker1.ShowConnectedSpeakers();

                Console.WriteLine("\n==========================================\n");

                speaker1.GetStatus();

                Console.WriteLine("\n==========================================\n");

            }

            Console.WriteLine("=====Smart Projector Functionalities=====");
            var smartProjector = entertainmentSystem.GetDevice("TH575") as SmartProjector;
            if (smartProjector != null)
            {
                smartProjector.ChangeResolution();
                smartProjector.OpenApp();
                smartProjector.MuteDevice();
                smartProjector.UnmuteDevice();
                Console.WriteLine(smartProjector.CurrentApp);
                Console.WriteLine(smartProjector.Resolution);
                Console.WriteLine(smartProjector.MaxScreenSize);
                Console.WriteLine(smartProjector.MinScreenSize);
                smartProjector.ChangeScreenSize(75);

                Console.WriteLine("\n==========================================\n");
                smartProjector.GetStatus();
            }
        }

        public static void SecuritySystemFunctionalities()
        {
            securitySystem.AddDevice(new SecurityCamera("Tapo Wire-Free2", "TP-Link2", "Garage2", new List<string> { "1080p", "UHD", "2K" }, 30, false, "2TB"));

            securitySystem.TurnOnAllDevices();
            Console.WriteLine("----------------------------------");
            securitySystem.ShowDevices();
            Console.WriteLine("----------------------------------");
            securitySystem.ArmDevices(SecurityDeviceTypes.All);
            Console.WriteLine("----------------------------------");
            securitySystem.DisarmDevices(SecurityDeviceTypes.MotionSensor);

            Console.WriteLine("=====Security Camera Functionalities=====");
            var securityCamera = securitySystem.GetDevice("Tapo Wire-Free2") as SecurityCamera;
            Console.WriteLine("----------------------------------");
            if (securityCamera != null)
            {
                Console.WriteLine("----------------------------------");
                securityCamera.StartRecording();
                Console.WriteLine("----------------------------------");
                securityCamera.ChangeResolution();
                Console.WriteLine("----------------------------------");
                securityCamera.ChangeFPS(70);
                Console.WriteLine(securityCamera.FPS);
                Console.WriteLine("----------------------------------");
                securityCamera.ShowBatteryLevel();
                Console.WriteLine("----------------------------------");
                securityCamera.StopRecording();
                Console.WriteLine("----------------------------------");
                securityCamera.UpdateDeviceLocation("Living room");
                Console.WriteLine("----------------------------------");
                securityCamera.UpdateDeviceState(SecurityDeviceStates.Triggered);
                Console.WriteLine("----------------------------------");

                Console.WriteLine("\n==========================================\n");

                securityCamera.GetStatus();

                Console.WriteLine("\n==========================================\n");
            }
            securitySystem.RemoveDevice("Tapo Wire-Free2");

            Console.WriteLine("=====Motion Sensor Functionalities=====");
            var motionSensor = securitySystem.GetDevice("SmartThings Motion Sensor") as MotionSensor;
            Console.WriteLine("----------------------------------");
            if (motionSensor != null)
            {
                motionSensor.ShowBatteryLevel();
                Console.WriteLine("----------------------------------");
                motionSensor.UpdateDeviceLocation("Dining room");
                Console.WriteLine("----------------------------------");
                motionSensor.UpdateDeviceState(SecurityDeviceStates.Triggered);
                Console.WriteLine("----------------------------------");


                Console.WriteLine("\n==========================================\n");

                motionSensor.GetStatus();

                Console.WriteLine("\n==========================================\n");
            }

            Console.WriteLine("=====Smart Lock Functionalities=====");
            var smartLock = securitySystem.GetDevice("TTLock Smart RFID") as SmartLock;
            Console.WriteLine("----------------------------------");
            if (smartLock != null)
            {
                smartLock.ShowBatteryLevel();
                Console.WriteLine("----------------------------------");
                smartLock.UpdateDeviceLocation("Bathroom");
                Console.WriteLine("----------------------------------");
                smartLock.UnlockDoor();
                smartLock.LockDoor();
                Console.WriteLine("----------------------------------");
                smartLock.UpdateDeviceState(SecurityDeviceStates.Triggered);
                Console.WriteLine("----------------------------------");


                Console.WriteLine("\n==========================================\n");

                smartLock.GetStatus();

                Console.WriteLine("\n==========================================\n");
            }


            lightSystem.TurnOffAllDevices();
            Console.WriteLine("----------------------------------");
            lightSystem.RemoveAllDevices();
        }

        public static void ClimateControlSystemFunctionalities()
        {
            climateControlSystem.AddDevice(new AirConditioner("Vivax Cool2", "Vivax", new List<int> { 1, 2, 3, 4, 5 }, 40, 30, true, 21, true));
            climateControlSystem.TurnOnAllDevices();
            Console.WriteLine("----------------------------------");
            climateControlSystem.ShowDevices();
            Console.WriteLine("----------------------------------");
            climateControlSystem.ChangeFanSpeedOfAllDevices(2, ClimateControlDeviceTypes.All);
            Console.WriteLine("----------------------------------");
            climateControlSystem.ChangeFanSpeedOfAllDevices(3, ClimateControlDeviceTypes.Purifier);
            Console.WriteLine("----------------------------------");

            Console.WriteLine("=====Air Conditioner Functionalities=====");
            var airCon = climateControlSystem.GetDevice("Vivax Cool2") as AirConditioner;
            Console.WriteLine("----------------------------------");
            if (airCon != null)
            {
                Console.WriteLine($"Current room temperature: {airCon.CurrentTemperature}");
                Console.WriteLine("----------------------------------");
                Console.WriteLine($"Current room target temperature: {airCon.TargetTemperature}");
                Console.WriteLine("----------------------------------");
                airCon.SetTemperature();
                Console.WriteLine($"Current room target temperature: {airCon.TargetTemperature}");
                Console.WriteLine("----------------------------------");
                Console.WriteLine($"Current mode: {airCon.Mode}");
                airCon.ChangeMode();
                Console.WriteLine("----------------------------------");
                airCon.ScheduleWorkingTime("17:00", "20:30");
                Console.WriteLine("----------------------------------");


                Console.WriteLine("\n==========================================\n");

                airCon.GetStatus();

                Console.WriteLine("\n==========================================\n");

            }

            climateControlSystem.RemoveDevice("Vivax Cool2");
            Console.WriteLine("----------------------------------");


            Console.WriteLine("=====Air Purifier Functionalities=====");
            var airPurifier = climateControlSystem.GetDevice("Dyson AirPurifier2") as AirPurifier;
            Console.WriteLine("----------------------------------");
            if (airPurifier != null)
            {
                Console.WriteLine("\n==========================================\n");

                airPurifier.GetStatus();

                Console.WriteLine("\n==========================================\n");
            }

            Console.WriteLine("=====Air Humidifier Functionalities=====");
            var airHumidifier = climateControlSystem.GetDevice("Ph3a Purifier") as AirHumidifier;
            Console.WriteLine("----------------------------------");
            if (airHumidifier != null)
            {
                Console.WriteLine($"Current mist output level {airHumidifier.MistOutputLevel}");
                airHumidifier.SetMistOutput();
                Console.WriteLine("----------------------------------");
                Console.WriteLine($"Current humidity {airHumidifier.CurrentHumidity}");
                airHumidifier.SetTargetHumidity();
                Console.WriteLine($"Target humidity {airHumidifier.TargetHumidity}");;
                Console.WriteLine("----------------------------------");
                airHumidifier.ShowWaterLevel();
                Console.WriteLine("----------------------------------");
                Console.WriteLine($"Current fan speed {airHumidifier.CurrentFanSpeed}");
                Console.WriteLine("----------------------------------");
                airHumidifier.ChangeFanSpeed();

                Console.WriteLine("\n==========================================\n");

                airHumidifier.GetStatus();

                Console.WriteLine("\n==========================================\n");

            }
        }
    }
}
