using BlaisePascal.SmartHouse.Domain.LuminuosDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.TemperatureDevice
{
    public sealed record Temperature
    {
        public const int MinTemperature = 15;
        public const int MaxTemperature = 35;

        public int Value { get; }

        private Temperature(int value) { Value = value; }
        public static Temperature Create(int temp)
        {
            if (temp < MinTemperature || temp > MaxTemperature)
            {
                throw new ArgumentOutOfRangeException($"Brightness level must be between {MinTemperature} and {MaxTemperature}.");
            }
            return new Temperature(temp);
        }

        public static Temperature Increase(Temperature temperature, int step)
        {
            if (temperature + step > MaxTemperature)
                throw new ArgumentOutOfRangeException("Cannot be over MaxTemperature");

            return Create(temperature.Value + step);
        }
        public static Temperature Decrease(Temperature temperature, int step)
        {
            if (temperature - step < MinTemperature)
                throw new ArgumentOutOfRangeException("Cannot be less MinTemperature");

            return Create(temperature.Value - step);
        }

        public static Temperature operator -(Temperature b1, int amount)
        {
            return new Temperature(b1.Value - amount);
        }
        public static Temperature operator +(Temperature b1, int amount)
        {
            return new Temperature(b1.Value + amount);
        }
        
        public static bool operator <(Temperature b1, Temperature b2)
        {
            return b1.Value < b2.Value;
        }
        public static bool operator >(Temperature b1, Temperature b2)
        {
            return b1.Value > b2.Value;
        }
        public static bool operator <=(Temperature b1, Temperature b2)
        {
            return b1.Value <= b2.Value;
        }
        public static bool operator >=(Temperature b1, Temperature b2)
        {
            return b1.Value >= b2.Value;
        }
        public static bool operator <(Temperature b1, int amount)
        {
            return b1.Value < amount;
        }
        public static bool operator >(Temperature b1, int amount)
        {
            return b1.Value > amount;
        }
        public static bool operator <=(Temperature b1, int amount)
        {
            return b1.Value <= amount;
        }
        public static bool operator >=(Temperature b1, int amount)
        {
            return b1.Value >= amount;

        }


        //da testare come tutti i record 
        //rimuovere i test sui controlli di brightness dai test delle varie classi in cui è implementata
    }
}
