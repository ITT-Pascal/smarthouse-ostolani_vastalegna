using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Abstraction
{
    public sealed record DeviceName
    {
        public string Name { get; }

        private DeviceName(string name)
        {
            Name = name;
        }

        public static DeviceName Create(string name)
        {
            if (name.Length < 4)
                throw new ArgumentException("Name must be at least 4 letters");

            return new DeviceName(name);
        }

    }
}
