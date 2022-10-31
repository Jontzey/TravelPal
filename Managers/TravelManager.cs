using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Classes;
using TravelPal.Enums;

namespace TravelPal.Managers
{
    public class TravelManager
    {
        List<Travel> travels = new List<Travel>();


       public void AddTravel(string Destination, Countries Country, TravelersEnum Travellers, TravelType TravelType, TripType TripType)
        {
            Travel travel = new Travel();
            travel.Destination = Destination;
            travel.Country = Country;
            travel.travelers = Travellers;
            travel.TravelType = TravelType;
            travel.TravelTripType = TripType;
        }

        public void RemoveTravel()
        {

        }


        
        
    }
}
