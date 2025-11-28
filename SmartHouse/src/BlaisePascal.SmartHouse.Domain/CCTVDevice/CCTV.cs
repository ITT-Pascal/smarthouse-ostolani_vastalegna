using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.CCTVDevice
{
    public class CCTV:AbstractDevice
    {
        public CCTV(string name) : base(name) { }
        public CCTV(Guid guid, string name);

    }
}
