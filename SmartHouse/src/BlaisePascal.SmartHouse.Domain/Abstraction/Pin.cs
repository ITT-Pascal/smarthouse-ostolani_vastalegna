using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Abstraction
{
    public sealed record Pin()
    {
        public int PinValue { get; }

        private Pin(int pin)
        {
            PinValue = pin;
        }

        public static Pin Create(int pinValue) 
        {
            if (pinValue.ToString().Length < 4)
                throw new ArgumentException("Pin must be at least 4 numbers");

            return new Pin(pinValue);
        }


        
    }
}
