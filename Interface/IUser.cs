using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;

namespace TravelPal.Interface
{
    public interface IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
         
        Countries Location { get; set; }


        public bool AddUser()
        {
            return true;
        }
    }
}
