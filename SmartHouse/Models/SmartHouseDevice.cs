using SmartHouse.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Models
{
    public abstract class SmartHouseDevice : ISmartHouseDevice
    {

        public SmartHouseDevice(string deviceName,string brand,bool connection=true)
        {
            DeviceId=_lastDeviceId++;
            DeviceName=deviceName;
            IsConnected = connection;
            Brand = brand;
        }

        public int DeviceId { get; set; }
        public string? DeviceName { get; set; }
        public bool IsOn { get; set; }
        public bool IsConnected { get; set; }
        private static int _lastDeviceId=1;
        public string Brand { get; private set; }



        public void Connect()
        {

            if(!IsOn) return;

            if (!IsConnected)
            {
                Console.Write("Connecting ");
                for (int i = 0; i < new Random().Next(5,20); i++)
                {
                    Console.Write(".");
                    Thread.Sleep(300);
                }
                Console.WriteLine(" Connected");
                IsConnected = true;
            }
        }

        public void Disconnect()
        {
            if (!IsOn) return;

            if (IsConnected)
            {
                Console.Write("Disconnecting ");
                for (int i = 0; i < new Random().Next(5, 20); i++)
                {
                    Console.Write(".");
                    Thread.Sleep(300);
                }
                Console.WriteLine(" Disconnected");
                IsConnected = false;
            }
        }

        //TODO: Make GetStatus and Reset virtual methods so they can be overriden in the implementation classes
        public virtual void GetStatus()
        {
            Console.WriteLine($"Status for device: {DeviceName}");
            Console.WriteLine($"Brand: {Brand}");
            Console.WriteLine($"Power: {(IsOn ? "On" : "Off")}");
            Console.WriteLine($"Network: {(IsConnected ? "Connected" : "Not Connected")}");
        }

        public void Reset() 
        {
           IsOn = false;
           IsConnected = false;
           DeviceName = string.Empty;
        }

        public void TurnOff()
        {
            IsOn = false;
        }

        public void TurnOn()
        {
           IsOn = true;
        }


    }
}
