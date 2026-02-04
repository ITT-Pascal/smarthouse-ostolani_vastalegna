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
        private Temperature(int value) { Value = value; }
        public static Temperature Create(int temp)
        {
            if (temp < MinTemperature || temp > MaxTemperature)
            {
                throw new ArgumentOutOfRangeException($"Brightness level must be between {MinTemperature} and {MaxTemperature}.");
            }
            return new Temperature(temp);
        }

        public static Temperature Increase(Temperature newTemperature)
        {
            if (newTemperature > MaxTemperature)
                throw new ArgumentOutOfRangeException("Cannot be over MaxTemperature");

            return Create(newTemperature.Value);
        }
        public static Temperature Decrease(Temperature newTemperature)
        {
            if (newTemperature < MinTemperature)
                throw new ArgumentOutOfRangeException("Cannot be less MinTemperature");

            return Create(newTemperature.Value);
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
    }
}
