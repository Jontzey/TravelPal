using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;

namespace TravelPal.Classes
{
    public class Vacation : Travel
    {
      

        public bool allInClusive { get; set; }

        

        public Vacation(bool allinclusive, string destination, Countries country, int travellers) : base(destination, country, travellers)
        {
            
            allinclusive = allInClusive;
            this.Destination = destination;
            this.Country = country;
            
            

          
        }
       

        public override string GetInfo()
        {
            return $"Destination: {Destination} Country: {Country.ToString()} Travellers: {travelers.ToString()} Allinclusive: {allInClusive.ToString()}";
        }

        public override string GetCountryInfoName()
        {
            return $"{Country.ToString()}";
        }
    }
}
