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

        //Controlli nel costruttore o in create?
        public Temperature(int value)
        {
            if (value < MinTemperature || value > MaxTemperature)
            {
                throw new ArgumentOutOfRangeException($"Brightness level must be between {MinTemperature} and {MaxTemperature}.");
            }

            Value = value;
        }
        public static Temperature Create(int temp)
        {
            return new Temperature(temp);
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
        public static bool operator <(int amount, Temperature b1)
        {
            return amount < b1.Value;
        }
        public static bool operator >(int amount, Temperature b1)
        {
            return amount > b1.Value;
        }
        public static bool operator <=(int amount, Temperature b1)
        {
            return amount <= b1.Value;
        }
        public static bool operator >=(int amount, Temperature b1)
        {
            return amount >= b1.Value;

        }
    }
}
