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
        



        // constructor
        public Trip(TripType type, string destination, Countries country, int travellers) : base(destination, country, travellers)
        {
            triptype = type;
        }

        




        // Trip Methods
       
        public override string GetInfo()
        {
            return $"Destination: {Destination}\rCountry: {Country.ToString()}\rTravellers: {travelers.ToString()}\rtripType: {triptype.ToString()} ";
        }

        public override string GetCountryInfoName()
        {
            return $"{Country}";
        }

        
    }
}
