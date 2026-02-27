using BlaisePascal.SmartHouse.Domain.Abstraction;

namespace BlaisePascal.SmartHouse.Domain.LuminuosDevice
{
    public class Lamp: AbstractLamp
    {
        //Constructor
        public Lamp(Guid guid, DeviceName name) : base(guid, name) { }  
        public Lamp(DeviceName name): base(name) { }

    }
}
