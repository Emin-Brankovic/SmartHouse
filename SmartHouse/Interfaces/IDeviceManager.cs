using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Interfaces
{
    public interface IDeviceManager
    {
        public void AddDevice(ISmartHouseDevice device);
        public void RemoveDevice(string deviceId);
        public void RemoveAllDevices();
        public void TurnOnAllDevicesOn();
        public void TurnOffAllDevicesOff();
        public void ShowDevices();
    }
}
