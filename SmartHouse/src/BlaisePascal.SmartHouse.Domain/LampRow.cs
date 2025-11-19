using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class LampRow
    {
        public List<AbstractLamp> Lamps { get; private set; }
        public LampRow()
        {
            Lamps = new List<AbstractLamp>();
        }

        public void AddLamp(AbstractLamp lamp)
        {
            Lamps.Add(lamp);
        }

        public void AddLampInPosition(AbstractLamp lamp, int position)
        {
            Lamps.Insert(position, lamp);
        }


        public void RemoveLamp(Guid id)
        {
            foreach (AbstractLamp lamp in Lamps)
            {
                if (lamp.Id == id)
                {
                    Lamps.Remove(lamp);

                }
            }

        }


        public void RemoveLamp(string name)
        {
            foreach (AbstractLamp lamp in Lamps)
            {
                if (lamp.Name == name)
                {
                    Lamps.Remove(lamp);

                }
            }

        }

        //Remove lamp by position have no paramerter other than position???


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

        public void TurnOnOneLamp(Guid id)
        {
            foreach (AbstractLamp lamp in Lamps)
            {
                if (lamp.Id == id)
                {
                    lamp.TurnOn();
                }
            }
        }
        public void TurnOnOneLamp(string name)
        {
            foreach (AbstractLamp lamp in Lamps)
            {
                if (lamp.Name == name)
                {
                    lamp.TurnOn();
                }
            }
        }
        public void TurnOffOneLamp(Guid id)
        {
            foreach (AbstractLamp lamp in Lamps)
            {
                if (lamp.Id == id)
                {
                    lamp.TurnOff();
                }
            }
        }
        public void TurnOffOneLamp(string name)
        {
            foreach (AbstractLamp lamp in Lamps)
            {
                if (lamp.Name == name)
                {
                    lamp.TurnOff();
                }
            }
        }

        public void SetOneBrightness(Guid id, int newBrightness)
        {
            foreach (AbstractLamp lamp in Lamps)
            {
                if (lamp.Id == id)
                {
                    lamp.SetBrightness(newBrightness);
                }
            }
        }
        public void SetOneBrightness(string name, int newBrightness)
        {
            foreach (AbstractLamp lamp in Lamps)
            {
                if (lamp.Name == name)
                {
                    lamp.SetBrightness(newBrightness);
                }
            }
        }
        public void SetAllSameBrightness(int newBrightness)
        {
            for (int i = 0; i < Lamps.Count; i++)
            {
                Lamps[i].SetBrightness(newBrightness);
            }
        }

        public void SetOneEcoLampBrightnessToEco(Guid id)
        {
            foreach (AbstractLamp lamp in Lamps)
            {
                if (lamp.Id == id)
                {
                    if (lamp is EcoLamp ecoLamp1)
                    {
                        ecoLamp1.SetEcoModeBrightness();

                    }
                }
            }
        }
        public void SetOneEcoLampBrightnessToEco(string name)
        {
            foreach (AbstractLamp lamp in Lamps)
            {
                if (lamp.Name == name)
                {
                    if (lamp is EcoLamp ecoLamp)
                    {
                        ecoLamp.SetEcoModeBrightness();

                    }
                }
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
        public void TurnOneEcoLampOffAfterTime(Guid id)
        {
            foreach (AbstractLamp lamp in Lamps)
            {
                if (lamp.Id == id)
                {
                    if (lamp is EcoLamp ecoLamp1)
                    {
                        ecoLamp1.TurnOffAfterTime();
                    }
                }
            }
        }

        public void TurnOneEcoLampOffAfterTime(string name)
        {
            foreach (AbstractLamp lamp in Lamps)
            {
                if (lamp.Name == name)
                {
                    if (lamp is EcoLamp ecoLamp1)
                    {
                        ecoLamp1.TurnOffAfterTime();
                    }
                }
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
