using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlaisePascal.SmartHouse.Domain.LuminuosDevice
{
    public record Brightness
    {

        public const int MinBrightness = 0;
        public const int MaxBrightness = 100;

        public int Value { get; }

        public Brightness(int value)
        {
            if (value < MinBrightness || value > MaxBrightness)
            {
                throw new ArgumentOutOfRangeException($"Brightness level must be between {MinBrightness} and {MaxBrightness}.");
            }

            Value = value;
        }

        public static Brightness operator -(Brightness b1, int amount)
        {
            return new Brightness(b1.Value - amount);
        }
        public static Brightness operator +(Brightness b1, int amount)
        {
            return new Brightness(b1.Value + amount);
        }
        public static bool operator <(Brightness b1, Brightness b2)
        {
            return b1.Value < b2.Value;
        }
        public static bool operator >(Brightness b1, Brightness b2)
        {
            return b1.Value > b2.Value;
        }
        public static bool operator <=(Brightness b1, Brightness b2)
        {
            return b1.Value <= b2.Value;
        }
        public static bool operator >=(Brightness b1, Brightness b2)
        {
            return b1.Value >= b2.Value;
        }
        public static bool operator <(Brightness b1, int amount)
        {
            return b1.Value < amount;
        }
        public static bool operator >(Brightness b1, int amount)
        {
            return b1.Value > amount;
        }
        public static bool operator <=(Brightness b1, int amount)
        {
            return b1.Value <= amount;
        }
        public static bool operator >=(Brightness b1, int amount)
        {
            return b1.Value >= amount;


        }
    }
}
