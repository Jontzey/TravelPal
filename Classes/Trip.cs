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
        TripType type { get; set; }



        public Trip (TripType type)
        {
            this.type = type;
        } 
       public string GetInfo()
        {
            return "TODO";
        }
    }
}
