using SmartHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Interfaces
{
    public interface IDeviceManager
    {
        public void AddDevice(SmartHouseDevice device);
        public void RemoveDevice(string deviceName);
        public void RemoveAllDevices();
        public void TurnOnAllDevices();
        public void TurnOffAllDevices();
        public void ShowDevices();
    }
}
