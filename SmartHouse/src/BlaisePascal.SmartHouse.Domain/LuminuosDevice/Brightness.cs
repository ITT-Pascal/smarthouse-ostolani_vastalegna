using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.LuminuosDevice
{
    public record Brightness
    {
        //public Brightness MinBrightness = new Brightness(0);
        //public Brightness MaxBrightness = new Brightness(100);

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

        
    }

}
