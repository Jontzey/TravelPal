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


        //Summary//
        //Add user with its properties//

        public bool AddUser(IUser user)
        {
            //string username = user.Username;
            //string password = user.Password;
            //var location = user.Location;

            users.Add(user);
            return true;
        }

        // summary //
        // Gets all users //
        public List<IUser> GetAllUsers ()
        {
            return users;
        }

        //summary//
        //Removes a user in the list IUser//
        public void RemoveUser(IUser user)
        {

        }

        public bool UpdateUsername (IUser user,string Update)
        {
            return true;
        }

        public bool ValidateUsername ()
        {
            return false;
        }
    }
}
