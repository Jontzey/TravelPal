using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TravelPal.Classes;
using TravelPal.Interface;

namespace TravelPal.Managers
{
    public class UserManager
    {
        List<IUser> users = new List<IUser>();
        IUser SignedInUser { get; set; }


        //Summary//
        //Add user with its properties//

        public bool AddUser(IUser user)
        {
            var username = user.Username;
            string password = user.Password;
            ValidateUsername();
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

            GetAllUsers();
            
            foreach (var user in users)
            {
                if(user.Username.Contains(user.Username))
                {
                    MessageBox.Show("hmm");
                }
            }
            
           
            return false;
        }
    }
}
