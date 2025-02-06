using SmartHouse.EntertainmetDevices;
using SmartHouse.Enums;
using SmartHouse.SecurityDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Repository
{
    public static class InMemoryRepository
    {
        //Entertainment devices
        public static List<SmartTV>? SmartTVs { get; set; }=new List<SmartTV>();
        public static List<SmartProjector>? SmartProjectors { get; set; } =new List<SmartProjector>();
        public static List<Speaker>? Speakers { get; set; } = new List<Speaker>();

        public static void CreateSmartTVs()
        {
            SmartTVs = new List<SmartTV>()
            {
                new SmartTV("Neo QLED", "Samsung", new List<ConnectivityTypes> { ConnectivityTypes.HDMI, ConnectivityTypes.DisplayPort }, new List<int>{ 60,120,144,165 } ,new List<StreamingApps> { StreamingApps.Netflix, StreamingApps.HBOMax, StreamingApps.YouTube, StreamingApps.Spotify,StreamingApps.PrimeVideo }, new List<string> { "Analog", "Digital", "HDMI1", "HDMI2", "HDMI3" }, new List<string> { "1080p", "UHD", "4K", "4K UHD","8K" }, 50),

                new SmartTV("U6K", "Hisens", new List<ConnectivityTypes> { ConnectivityTypes.HDMI}, new List<int>{ 60,120,144} 
                ,new List<StreamingApps> { StreamingApps.Netflix, StreamingApps.HBOMax, StreamingApps.YouTube, StreamingApps.DisneyPlus }, new List<string> { "Analog", "Digital", "HDMI1", "HDMI2" }, new List<string> { "1080p", "UHD", "4K", "4K UHD","6K" }, 42),

                new SmartTV("G5", "LG", new List<ConnectivityTypes> { ConnectivityTypes.HDMI, ConnectivityTypes.DisplayPort }
                ,new List<int>{120,144,165 },new List<StreamingApps> { StreamingApps.Netflix, StreamingApps.YouTube, StreamingApps.Spotify }, new List<string> { "Analog", "Digital", "HDMI1", "HDMI2" }, new List<string> { "1080p", "UHD", "4K", "4K UHD" }, 55),

                new SmartTV("D65Q660M2CW", "Telefunken", new List<ConnectivityTypes> { ConnectivityTypes.HDMI, ConnectivityTypes.DisplayPort }, new List<int>{ 60,120 } , new List<StreamingApps> { StreamingApps.Netflix, StreamingApps.HBOMax, StreamingApps.YouTube, }, new List<string> { "Analog", "Digital", "HDMI1", "HDMI2" }, new List<string> { "1080p", "UHD", "4K" }, 65),


                new SmartTV("Neon LED", "Samsung", new List<ConnectivityTypes> { ConnectivityTypes.HDMI, ConnectivityTypes.DisplayPort }, new List < int > { 60, 120, 144 }, new List<StreamingApps> { StreamingApps.Netflix, StreamingApps.HBOMax, StreamingApps.YouTube, StreamingApps.Spotify }, new List<string> { "Analog", "Digital", "HDMI1", "HDMI2" }, new List<string> { "1080p", "UHD", "4K", "4K UHD" }, 52),


                new SmartTV("58pus8507", "Philips", new List<ConnectivityTypes> { ConnectivityTypes.HDMI, ConnectivityTypes.DisplayPort }, new List < int > {60}, new List<StreamingApps> { StreamingApps.Netflix, StreamingApps.YouTube}, new List<string> { "Analog", "Digital", "HDMI1", "HDMI2" }, new List<string> { "1080p", "UHD"}, 48)
            };

        }

        public static void CreateSmartProjectors()
        {
            SmartProjectors = new List<SmartProjector>()
            {
                new SmartProjector("TH575", new List<ConnectivityTypes> { ConnectivityTypes.HDMI, ConnectivityTypes.DisplayPort, ConnectivityTypes.WiFi },"BenQ",new List<StreamingApps> { StreamingApps.Netflix, StreamingApps.HBOMax, StreamingApps.YouTube, StreamingApps.Spotify}, new List<string> { "1080p", "UHD"},true),

                 new SmartProjector("VPL- VW995ES", new List<ConnectivityTypes> { ConnectivityTypes.HDMI, ConnectivityTypes.DisplayPort,ConnectivityTypes.WiFi,ConnectivityTypes.Bluetooth },"Sony",new List<StreamingApps> { StreamingApps.Netflix, StreamingApps.HBOMax, StreamingApps.YouTube, StreamingApps.Spotify,StreamingApps.PrimeVideo }, new List<string> { "1080p", "UHD", "4K", "4K UHD"},true),

                  new SmartProjector("Epson Home Cinema 3200 ", new List<ConnectivityTypes> { ConnectivityTypes.HDMI, ConnectivityTypes.DisplayPort },"Epson",new List<StreamingApps> { StreamingApps.Netflix,StreamingApps.YouTube}, new List<string> { "1080p", "UHD", "4K"},false),
            };
        }

        public static void CreateSpeakers()
        {
            Speakers = new List<Speaker>()
            {
                new Speaker("Clip2", "JBL", new List<ConnectivityTypes> { ConnectivityTypes.AUX, ConnectivityTypes.Bluetooth }, true),

                new Speaker("Clip3", "JBL", new List<ConnectivityTypes> { ConnectivityTypes.AUX, ConnectivityTypes.Bluetooth }, true),

                new Speaker("Pill", "Beats ", new List<ConnectivityTypes> { ConnectivityTypes.AUX, ConnectivityTypes.Bluetooth },false),

                new Speaker("SoundLink Flex", "Bose", new List<ConnectivityTypes> { ConnectivityTypes.AUX, ConnectivityTypes.Bluetooth }, true),

                new Speaker("SoundLink Max", "Bose", new List<ConnectivityTypes> { ConnectivityTypes.AUX, ConnectivityTypes.Bluetooth }, false),

                new Speaker("GO3", "JBL", new List<ConnectivityTypes> { ConnectivityTypes.AUX, ConnectivityTypes.Bluetooth }, true),

                new Speaker("GO1", "JBL", new List<ConnectivityTypes> { ConnectivityTypes.AUX, ConnectivityTypes.Bluetooth }, false),
        };
        }


        //SecurityDevices
        public static List<MotionSensor> MotionSensors { get; set; } = new List<MotionSensor>();
        public static List<SecurityCamera>? SecurityCameras { get; set; } =new List<SecurityCamera>();
        public static List<SmartLock> SmartLocks { get; set; } = new List<SmartLock>();

        public static void CreateSecurityCameras()
        {
            SecurityCameras = new List<SecurityCamera>()
            {
                new SecurityCamera("Tapo Wire-Free","TP-Link","Garage","2K",30,false,"2TB"),
                new SecurityCamera("Tapo C120","TP-Link","Kitchen","2K",30,false,"1TB"),
                new SecurityCamera("Nest Doorbell","Google","Front door","1080p",60,false,"512GB"),
                new SecurityCamera("Floodlight Cam E340","Eufy","Backyard","2K",30,false,"3TB"),
            };
        }
        public static void CreateSmartLocks() 
        {
            SmartLocks = new List<SmartLock>()
            {
                new SmartLock("Ultraloq UL3 BT","Ultraloq","Front door",true),
                new SmartLock("Lockly Secure Pro","Lockly","Master bedroom",false,true),
                new SmartLock("Schlage Encode","Schlage","Garage door",true),
                new SmartLock("TTLock Smart RFID","TTLock","Back door",false,false,true),

            };
        }
        public static void CreateMotionSensors()
        {
            MotionSensors = new List<MotionSensor>()
            {
                new MotionSensor("Z-Wave MultiSensor 6","Aeotec","Backyard",50,100),
                new MotionSensor("SmartThings Motion Sensor","Samsung","Garage",30,40),
                new MotionSensor("Caséta Wireless Motion Sensor","Lutron","Garage",20,20),
            };
        }




        public static void PopulateRepository() 
        {
            CreateMotionSensors();
            CreateSecurityCameras();
            CreateSmartLocks();
            CreateSpeakers();
            CreateSmartTVs();
            CreateSmartProjectors();
        }
    }
}
