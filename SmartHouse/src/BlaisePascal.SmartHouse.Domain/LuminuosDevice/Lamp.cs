using BlaisePascal.SmartHouse.Domain.Abstraction;

namespace BlaisePascal.SmartHouse.Domain.LuminuosDevice
{
    public class Lamp: AbstractLamp
    {
        //Constructor
        public Lamp(Guid guid, DeviceName name) : base(guid, name) { }  
        public Lamp(DeviceName name): base(name) { }
        public Lamp(Guid guid, DeviceName name, DeviceStatus deviceStatus, Brightness brightness, DateTime creationTime, DateTime lastUpdateTime) : base(guid, name, deviceStatus, brightness, creationTime, lastUpdateTime) { }

    }
}
