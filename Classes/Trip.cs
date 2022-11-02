using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;

namespace TravelPal.Classes
{
    public class Trip : Travel
    {
        private TripType triptype;
        

        public Trip(TripType type, string destination, int country, int travellers) : base()
        {
            triptype = type;
        }

        





       
        public override string GetInfo()
        {
            return $"Destination: {Destination} Country: {Country.ToString()} Travellers: {travelers.ToString()}";
        }

        public override string GetCountryInfoName()
        {
            return $"{Country}";
        }
    }
}
