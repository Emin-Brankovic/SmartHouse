using SmartHouse.Devices;
using SmartHouse.Enums;
using SmartHouse.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.ClimateControlDevices
{
    public class AirConditioner : ClimateControlDevice
    {
        public AirConditioner(string deviceName, string brand, List<int> fanSpeeds, double energyUsage, double noiseLevel, bool isAutoAdjustEnabled,  double currenrTemperature,bool hasScheduling, ClimateControlDeviceTypes deviceType = ClimateControlDeviceTypes.AirCondition, FiltersStatuses filterStatus =FiltersStatuses.Clean, bool connection = true) 
            : base(deviceName, brand, fanSpeeds, energyUsage, noiseLevel, isAutoAdjustEnabled, deviceType, filterStatus, connection)
        {
            CurrentTemperature=currenrTemperature;
            HasScheduling=hasScheduling;
        }

        private List<string> Modes { get; set; } = new List<string> { "Cool", "Heat" };
        public double CurrentTemperature { get; private set; }
        public double TargetTemperature { get; private set; }
        public string Mode { get; private set; } = "Cool";
        public bool HasScheduling { get; private set; }
        public string WorkingStartTime { get; private set; } = string.Empty;
        public string WorkingStopTime { get; private set; } = string.Empty;

        public void ScheduleWorkingTime(string startTime,string stopTime)
        {
            if (!HasScheduling)
            {
                Console.WriteLine("Air condition does not have this feature");
                return;
            }
            WorkingStartTime = startTime;
            WorkingStopTime = stopTime;

            Console.WriteLine($"Air condition will start at: {startTime} and stop: {stopTime}");
        }

        public void SetTemperature()
        {
            string userInputString = string.Empty;
            double userInputStringDouble=default;

            Console.WriteLine($"Current room temperature {CurrentTemperature}");

            Console.Write("Choose desired room temperature between 15-50: ");

            do
            {
                userInputString = Console.ReadLine();
            }
            while (!double.TryParse(userInputString, out userInputStringDouble) || userInputStringDouble < 15 || userInputStringDouble > 50);

            TargetTemperature = userInputStringDouble;
            Console.WriteLine($"Temperature set to {userInputString}");
        }

        public void ChangeMode()
        {
            Console.WriteLine("Select wanted air conditioner mode");
            Mode = Helper.SelectSupported<string>(Modes);
        }

        public override void GetStatus()
        {
            base.GetStatus();

            Console.WriteLine($"Current Mode: {Mode}");
            Console.WriteLine($"Current Temperature: {CurrentTemperature}°C");
            Console.WriteLine($"Target Temperature: {TargetTemperature}°C");
            Console.WriteLine($"Available Modes: {string.Join(", ", Modes)}");
            Console.WriteLine($"Scheduling: {(HasScheduling ? "Enabled" : "Disabled")}");
            Console.WriteLine($"Working Start Time: {(string.IsNullOrEmpty(WorkingStartTime) ? "Not Set" : WorkingStartTime)}");
            Console.WriteLine($"Working Stop Time: {(string.IsNullOrEmpty(WorkingStopTime) ? "Not Set" : WorkingStopTime)}");
        }
    }
}
