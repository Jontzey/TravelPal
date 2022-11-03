using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TravelPal.Classes;
using TravelPal.Enums;
using TravelPal.Interface;

namespace TravelPal.Managers
{
    public class TravelManager
    {

        //private UserManager userManager;


        List<Travel> Travels = new();

        
       
       public void AddTravel(Vacation vacation)
        {

          Travels.Add(vacation);
            
        }

        public void AddTravel(Trip trip)
        {

            Travels.Add(trip);
            
        }


        public List<Travel> GetList()
        {

            return Travels;
        }

        public void RemoveTravel(Travel travel)
        {
            Travels.Remove(travel);
            
        }

      

       
    }
}
