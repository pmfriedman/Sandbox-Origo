using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Origo
{
    class Route
    {
        public List<Stop> Stops { get; } = new List<Stop>();
        public string Id { get; set; }
        public string Equipment { get; set; }
        public int DayNum { get; set; }

        public override string ToString()
        {
            return SummaryString;
        }


        public string StopsString => string.Concat(Stops.Select(s => s.Location).ToArray());

        public string SummaryString
        {
            get
            {
                string stops = string.Concat(Stops.Select(s => s.SummaryString).ToArray());
                return $"{Id}-{DayNum}({stops})";
            }
        }
    }
}
