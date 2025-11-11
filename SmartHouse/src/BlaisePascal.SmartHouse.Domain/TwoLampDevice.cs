using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class TwoLampDevice
    {
        //Attributes
        public LampModel Lamp1 { get; private set; }
        public LampModel Lamp2 { get; private set; }

        //Constructor
        public TwoLampDevice(LampModel lamp1, LampModel lamp2)
        {
            Lamp1 = lamp1;
            Lamp2 = lamp2;
        }


        public void TurnOnOneLamp(LampModel currentLamp)
        {
            currentLamp.TurnOn();
        }
        public void TurnOffOneLamp(LampModel currentLamp)
        {
            currentLamp.TurnOff();
        }

        public void TurnBothOn()
        {
            Lamp1.TurnOn();
            Lamp2.TurnOn();
        }

        public void TurnBothOff()
        {
            Lamp1.TurnOff();
            Lamp2.TurnOff();
        }

        

        public void SetOneBrightness(LampModel currentLamp, int newBrightness)
        {
            currentLamp.SetBrightness(newBrightness); 
        }

        public void SetBothSameBrightness(int newBrightness)
        {
            Lamp1.SetBrightness(newBrightness);
            Lamp2.SetBrightness(newBrightness);

            
        }

        public void SetOneEcoLampBrightnessToEco(LampModel currentLamp)
        {
            // Si fa così per controllare se è di tipo EcoLamp?
            if (currentLamp is EcoLamp ecoLamp1)
            {
                ecoLamp1.SetEcoModeBrightness();
                
            }
        }

        public void SetBothEcoLampsBrightnessToEco()
        {
            if (Lamp1 is EcoLamp ecoLamp1)
            {
                ecoLamp1.SetEcoModeBrightness();
            }
            if (Lamp2 is EcoLamp ecoLamp2)
            {
                ecoLamp2.SetEcoModeBrightness();
            }
        }

        public void TurnOneEcoLampOffAfterTime(LampModel currentLamp)
        {
            if (currentLamp is EcoLamp ecoLamp1)
            {
                ecoLamp1.TurnOffAfterTime();
            }
            
        }
        public void TurnBothEcoLampsOffAfterTime()
        {
            if (Lamp1 is EcoLamp ecoLamp1)
            {
                ecoLamp1.TurnOffAfterTime();
            }
            if (Lamp2 is EcoLamp ecoLamp2)
            {
                ecoLamp2.TurnOffAfterTime();
            }
        }

    }
}
