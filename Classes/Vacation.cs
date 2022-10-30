using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPal.Classes
{
    public class Vacation
    {
        public bool allInClusive { get; set; }

        public Vacation(bool allInClusive)
        {
            this.allInClusive = allInClusive;
        }
    }
}
