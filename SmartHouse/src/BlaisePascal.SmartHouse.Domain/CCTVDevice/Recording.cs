using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.CCTVDevice
{
    public class Recording
    {
        public DateTime RecordStart { get; private set; }
        public TimeSpan RecordLength { get; private set; }
        public string Name { get; private set; }

        public Recording(string name, DateTime recStart, TimeSpan length) 
        {
            RecordStart = recStart;
            RecordLength = length;
            Name = name;
        }
    }
}
