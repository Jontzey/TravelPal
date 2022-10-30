using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;

namespace TravelPal.Classes
{
    public class Travel
    {
        public string Destination { get; set; }
        Countries Country { get; set; }

        public int travellers { get; set; }

        public string Travels()
        {
            return $"{Destination} {Country} {travellers}";
        }

        public virtual string GetInfo()
        {
            return "TODO";
        }

    }
}
