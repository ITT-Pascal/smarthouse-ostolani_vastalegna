namespace BlaisePascal.SmartHouse.Domain.LuminuosDevice
{
    public class Lamp: AbstractLamp
    {
        //Constructor
        public Lamp(Guid guid, string name) : base(guid, name) { }  
        public Lamp(string name): base(name) { }

    }
}
