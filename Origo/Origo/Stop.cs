using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Origo
{
    class Stop
    {
        public string Location { get; set; }
        public bool IsDepot { get; set; }

        public string SummaryString => Location;
    }
}
