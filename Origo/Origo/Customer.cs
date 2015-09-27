using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Origo
{
    public class Customer
    {
        public string Id { get; } = "Sysco";

        public string ModifiedID() => Id + " Modified";
    }
}
