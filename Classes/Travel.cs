using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;
using TravelPal.Managers;

namespace TravelPal.Classes
{
    public class Travel
    {
        public string Destination { get; set; }
        public Countries Country { get; set; }
        public TravelersEnum travelers { get; set; }
       
        public TravelType TravelType { get; set; }
        public TripType TravelTripType { get; set; }

      


        public virtual string GetInfo()
        {
            return "Todo";
        }

        public virtual string GetCountryInfoName()
        {
            return "";
        }

    }
}
