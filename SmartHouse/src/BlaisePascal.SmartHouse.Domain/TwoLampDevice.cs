using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class TwoLampDevice
    {
        //Properties
        public Lamp lamp1 {get; private set; }
        public Lamp lamp2 { get; private set; }

        //Constructor
        public TwoLampDevice()
        {
            lamp1 = new Lamp();
            lamp2 = new Lamp();
        }

        
        public void TurnOnOneLamp(Lamp currentLamp)
        {
            currentLamp.TurnOn();
        }
        public void TurnOffOneLamp(Lamp currentLamp)
        {
            currentLamp.TurnOff();
        }

        public void TurnBothOn()
        {
            lamp1.TurnOn();
            lamp2.TurnOn();
        }

        public void TurnBothOff()
        {
            lamp1.TurnOff();
            lamp2.TurnOff();
        }

        

        public void SetOneBrightness(Lamp currentLamp, int newBrightness)
        {
            currentLamp.SetBrightness(newBrightness); 
        }

        public void SetBothSameBrightness(int newBrightness)
        {
            lamp1.SetBrightness(newBrightness);
            lamp2.SetBrightness(newBrightness);
        }
    }
}
