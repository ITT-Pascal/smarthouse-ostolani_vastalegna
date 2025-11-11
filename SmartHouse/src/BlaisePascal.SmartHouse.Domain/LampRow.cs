using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class LampRow
    {
        public List<LampModel> Lamps { get; private set; }
        public LampRow()
        {
            Lamps =  new List <LampModel>();
        }

        public void AddLamp(LampModel lamp)
        {
            Lamps.Add(lamp);
        }

        public void RemoveLamp(LampModel lamp)
        {
            Lamps.Remove(lamp);
        }


        public void TurnAllOn()
        {
            for (int i = 0; i < Lamps.Count; i++)
            {
                Lamps[i].TurnOn();
            }
        }
        public void TurnAllOff()
        {
            for (int i = 0; i < Lamps.Count; i++)
            {
                Lamps[i].TurnOff();
            }
        }

        //TO DO: Controllare se la lampada è nella Row (anche in TwoLampDevice)
        // Con questo metodo posso controllare lampade non nella Row!?
        public void TurnOnOneLamp(LampModel currentLamp)
        {
            currentLamp.TurnOn();
        }
        public void TurnOffOneLamp(LampModel currentLamp)
        {
            currentLamp.TurnOff();
        }


        public void SetOneBrightness(LampModel currentLamp, int newBrightness)
        {
            currentLamp.SetBrightness(newBrightness);
        }
        public void SetAllSameBrightness(int newBrightness)
        {
            for (int i = 0; i < Lamps.Count; i++)
            {
                Lamps[i].SetBrightness(newBrightness);
            }
        }

        public void SetOneEcoLampBrightnessToEco(LampModel currentLamp)
        {
            if (currentLamp is EcoLamp ecoLamp1)
            {
                ecoLamp1.SetEcoModeBrightness();

            }
        }
        public void SetAllEcoLampsBrightnessToEco()
        {
            for (int i = 0; i < Lamps.Count; i++)
            {
                if (Lamps[i] is EcoLamp ecoLamp)
                {
                    ecoLamp.SetEcoModeBrightness();
                }
            }
        }
        public void TurnOneEcoLampOffAfterTime(LampModel currentLamp)
        {
            if (currentLamp is EcoLamp ecoLamp1)
            {
                ecoLamp1.TurnOffAfterTime();
            }

        }
        public void TurnAllEcoLampsOffAfterTime()
        {
            for (int i = 0; i < Lamps.Count; i++)
            {
                if (Lamps[i] is EcoLamp ecoLamp)
                {
                    ecoLamp.TurnOffAfterTime();
                }
            }
        }

    }
}
