using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Abstraction
{
    public sealed record DeviceName
    {
        public string Value { get; }

        private DeviceName(string name)
        {
            Value = name;
        }

        public static DeviceName Create(string name)
        {
            string.IsNullOrWhiteSpace(name);
            return new DeviceName(name);
        }

    }
}
