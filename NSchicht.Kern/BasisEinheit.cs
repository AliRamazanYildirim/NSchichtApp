using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSchicht.Kern
{
    public abstract class BasisEinheit
    {
        public int ID { get; set; }
        public DateTime ErstellungsDatum { get; set; }
        public DateTime NeuesDatum { get; set; }
    }
}
