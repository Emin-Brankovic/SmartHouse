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
        public void RemoveDevice(int deviceId);
        public void RemoveAllDevices();
        public void TurnOnAllDevicesOn();
        public void TurnOffAllDevicesOff();
        public void ShowDevices();
    }
}
