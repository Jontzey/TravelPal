using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Classes;
using TravelPal.Enums;
using TravelPal.Interface;

namespace TravelPal.Managers
{
    public class TravelManager
    {

        //private UserManager userManager;


        List<Travel> Travel = new();
        
        
       
       public void AddTravel(Vacation vacation)
        {

          Travel.Add(vacation);
            
        }

        public void AddTravel(Trip trip)
        {

            Travel.Add(trip);
            
        }





        public List<Travel> GetList()
        {

            return Travel;
        }

        public void RemoveTravel(Travel travel)
        {
            Travel.Remove(travel);
        }
    }
}
