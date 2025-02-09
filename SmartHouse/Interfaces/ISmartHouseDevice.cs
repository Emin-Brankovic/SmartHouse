namespace SmartHouse.Interfaces
{
    public interface ISmartHouseDevice
    {
        public void TurnOn();
        public void TurnOff();
        public void Reset();
        public void GetStatus();
        public void Connect();
        public void Disconnect();
    }
}
