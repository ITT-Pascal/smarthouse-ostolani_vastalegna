using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlaisePascal.SmartHouse.Domain.LuminuosDevice
{
    public class LampRow
    {
        //Properties
        public List<AbstractLamp> Lamps { get; private set; }
        public string Name { get; private set; }

        //Constructor
        public LampRow(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Nome non valido.");

            Lamps = new List<AbstractLamp>();
            Name = name;
        }
        public LampRow(string name, List<AbstractLamp> lamps)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Nome non valido.");
            Name = name;
            if (lamps == null)
                throw new ArgumentNullException("Lista null");

            Lamps = new List<AbstractLamp>();
                    
            foreach (AbstractLamp lamp in lamps)
            {
                Lamps.Add(lamp);
            }   
        }
        //Methods
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

        public void RomoveLampInPosition(int postion)
        {

        }

        //Remove lamp by position have no paramerter other than position???

        public DeviceStatus Status()
        {
            foreach (var lamp in Lamps)
            {
                if (lamp.Status == DeviceStatus.On)
                    return DeviceStatus.On;
            }
            return DeviceStatus.Off;
        }


        public void TurnAllOn()
        {
            for (int i = 0; i < Lamps.Count; i++)
            {
                Lamps[i].SwitchOn();
            }
        }
        public void TurnAllOff()
        {
            for (int i = 0; i < Lamps.Count; i++)
            {
                Lamps[i].SwitchOff();
            }
        }

        public void TurnOnOneLamp(Guid id)
        {
            foreach (AbstractLamp lamp in Lamps)
            {
                if (lamp.Id == id)
                {
                    lamp.SwitchOn();
                }
            }
        }
        public void TurnOnOneLamp(string name)
        {
            foreach (AbstractLamp lamp in Lamps)
            {
                if (lamp.Name == name)
                {
                    lamp.SwitchOn();
                }
            }
        }
        public void TurnOffOneLamp(Guid id)
        {
            foreach (AbstractLamp lamp in Lamps)
            {
                if (lamp.Id == id)
                {
                    lamp.SwitchOff();
                }
            }
        }
        public void TurnOffOneLamp(string name)
        {
            foreach (AbstractLamp lamp in Lamps)
            {
                if (lamp.Name == name)
                {
                    lamp.SwitchOff();
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
