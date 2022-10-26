using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Classes;
using TravelPal.Interface;

namespace TravelPal.Managers
{
    public class UserManager
    {
        List<IUser> users = new List<IUser>();
        IUser? SignedInUser { get; set; }

        public bool AddUser(IUser user)
        {
            string username = user.Username;
            string password = user.Password;
            
            
            return true;
        }

        public void RemoveUser(IUser user)
        {

        }

        public bool UpdateUsername (IUser user,string Update)
        {
            return true;
        }
    }
}
