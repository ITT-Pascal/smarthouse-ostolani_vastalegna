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
        public void AddLamp(AbstractLamp lamp){ Lamps.Add(lamp); }
        public void AddLampInPosition(AbstractLamp lamp, int position){ Lamps.Insert(position, lamp); }

        public void RemoveLamp(Guid id) { Lamps.Remove(GetLamp(id)); }
        public void RemoveLamp(string name) { Lamps.Remove(GetLamp(name)); }
        public void RemoveLampInPosition(int postion) { Lamps.RemoveAt(postion);  }


        public DeviceStatus Status()
        {
            foreach (var lamp in Lamps)
            {
                if (lamp.Status == DeviceStatus.On)
                    return DeviceStatus.On;
            }
            return DeviceStatus.Off;
        }

        public void TurnOnOneLamp(Guid id) { GetLamp(id).SwitchOn(); }
        public void TurnOnOneLamp(string name) { GetLamp(name).SwitchOn(); }
        public void TurnOffOneLamp(Guid id) { GetLamp(id).SwitchOff(); }
        public void TurnOffOneLamp(string name) { GetLamp(name).SwitchOff(); }

        public void SetOneBrightness(Guid id, int newBrightness) { GetLamp(id).SetBrightness(newBrightness); }
        public void SetOneBrightness(string name, int newBrightness) { GetLamp(name).SetBrightness(newBrightness); }

        public void Brighten(int position, int amount) => GetLamp(position).Brighten(amount);
        public void Brighten(Guid id, int amount) => GetLamp(id).Brighten(amount);

        public void Dimmer(int position, int amount) => GetLamp(position).Dimmer(amount);
        public void Dimmer(Guid id, int amount) => GetLamp(id).Dimmer(amount);



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

        public void SetAllSameBrightness(int newBrightness)
        {
            for (int i = 0; i < Lamps.Count; i++)
            {
                Lamps[i].SetBrightness(newBrightness);
            }
        }

        public void SetOneEcoLampBrightnessToEco(Guid id)
        {
            if (FindLampById(id) is EcoLamp ecoLamp1)
            {
                ecoLamp1.SetEcoModeBrightness();
            }
        }
        public void SetOneEcoLampBrightnessToEco(string name)
        {
            if (GetLamp(name) is EcoLamp ecoLamp1)
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
        public void TurnOneEcoLampOffAfterTime(Guid id)
        {
            if (FindLampById(id) is EcoLamp ecoLamp1)
            {
                ecoLamp1.TurnOffAfterTime();
            }
        }

        public void TurnOneEcoLampOffAfterTime(string name)
        {
            if (GetLamp(name) is EcoLamp ecoLamp1)
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


        //Sort and find
        public AbstractLamp FindLampWithMaxBrightness()
        {
            AbstractLamp lamp = Lamps[0];

            foreach (AbstractLamp l in Lamps)
            {
                if (l.Brightness > lamp.Brightness)
                    lamp = l;
            }

            return lamp;
        }

        public AbstractLamp FindLampWithMinBrightness()
        {
            AbstractLamp lamp = Lamps[0];

            foreach (AbstractLamp l in Lamps)
            {
                if (l.Brightness < lamp.Brightness)
                    lamp = l;
            }

            return lamp;
        }

        public List<AbstractLamp> FindLampsByIntensityRange(int min, int max)
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();

            foreach (AbstractLamp l in Lamps)
            {
                if (l.Brightness >= min && l.Brightness <= max)
                    lamps.Add(l);

            }

            return lamps;
        }

        public List<AbstractLamp> FindAllOn()
        {
            List<AbstractLamp> onLamps = new List<AbstractLamp>();

            foreach (AbstractLamp l in Lamps)
            {
                if (l.Status == DeviceStatus.On)
                    onLamps.Add(l);
            }

            return onLamps;

        }

        public List<AbstractLamp> FindAllOff()
        {
            List<AbstractLamp> offLamps = new List<AbstractLamp>();

            foreach (AbstractLamp l in Lamps)
            {
                if (l.Status == DeviceStatus.Off)
                    offLamps.Add(l);
            }

            return offLamps;

        }

        public AbstractLamp? FindLampById(Guid id)
        {
            foreach (AbstractLamp l in Lamps)
            {
                if (l.Id == id)
                    return l;
            }

            return null;

        }



        public List<AbstractLamp> SortByBrightness(bool descending)
        {
            List<AbstractLamp> sortedLamps = new List<AbstractLamp>();
            List<AbstractLamp> tmpLamps = new List<AbstractLamp>(Lamps);

            int count = 0;

            while (count < Lamps.Count)
            {
                
                AbstractLamp selected = tmpLamps[0];

                
                foreach (var l in tmpLamps)
                {
                    if (descending)
                    {
                        // decrescente: cerca massima
                        if (l.Brightness > selected.Brightness)
                            selected = l;
                    }
                    else
                    {
                        // crescente: cerca minima
                        if (l.Brightness < selected.Brightness)
                            selected = l;
                    }
                }

                sortedLamps.Add(selected);
                tmpLamps.Remove(selected);
                count++;
            }

            return sortedLamps;
        }


        //Metodi get

        private AbstractLamp GetLamp(int position)
        {
            if (position < 0 || position > Lamps.Count -1)
                throw new ArgumentOutOfRangeException("Not in range");

            return Lamps[position];
        }

        private AbstractLamp GetLamp(Guid id)
        {
            for (int i = 0; i < Lamps.Count; i++)
            {
                if (Lamps[i].Id == id)
                    return Lamps[i];
            }

            throw new ArgumentException("No lamps with this guid");
        }
        private AbstractLamp GetLamp(string name)
        {
            for (int i = 0; i < Lamps.Count; i++)
            {
                if (Lamps[i].Name == name)
                    return Lamps[i];
            }

            throw new ArgumentException("No lamps with this name");
        }

    }



}
