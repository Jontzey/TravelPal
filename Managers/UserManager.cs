using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TravelPal.Classes;
using TravelPal.Enums;
using TravelPal.Interface;

namespace TravelPal.Managers;

public class UserManager
{
    List<IUser> users = new List<IUser>();
    List<Travel> travels;
    TravelManager TravelManager;
    public IUser SignedInUser { get; set; }

    public UserManager()
    {
        
        //this.travels = travelManager.GetList();
        // Created a Admin 
        UserAdmin Admin = new UserAdmin()
        {
            Username = "Admin",
            Password = "Password",
            
        };
        User user = new User()
        {
            Username = "Gandalf",
            Password = "Password",
            Location = Countries.Argentina,
            
        };
      
        Vacation vacation = new(true, "justin Bieber Concert", Countries.Afghanistan, 2);
        Vacation vacation1 = new(true, "Im going to Mecka to pray", Countries.Belgium, 1);
        Vacation vacation2 = new(true, "Im going to find wife", Countries.Saint_Helena, 5);

        
        user.travels.Add(vacation);
        user.travels.Add(vacation1);
        user.travels.Add(vacation2);
        users.Add(Admin);
        users.Add(user);
        


        
        
        
    }

   
    //Summary//
    //Add user with its properties//
    // this method not used!!! //
   

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

    //public void hmm()
    //{

    //    foreach (IUser user in users)
    //    {
    //        if (user is User)
    //        {
    //            users.Add(user as User);
    //        }
    //    }
    //    foreach (User user in users)
    //    {
            
    //    }
    //}


    // method not used yet
    public bool UpdateUsername (IUser user,string Update)
    {
        return true;
    }

    //summary//
    // Checks if the same username exists in Username
    public bool ValidateUsername (string username)
    {

        foreach (IUser user in users)
        {
            if (user.Username == username)
            {
                return false;
            }
        }
        return true;
        
    }

    // Adds a new User //
    public bool AddUser(string username, string password, Countries Location, TravelManager travelManager)
    {
       if(ValidateUsername(username))
        {
            this.TravelManager = travelManager;



            User user = new();
            user.Username = username;
            user.Password = password;
            user.Location = Location;
            
            


            
            users.Add((user));

            return true;
        } 
        
            MessageBox.Show("already exists!");
            return false;
        
       
        
    }

    //summar//
    // a method to confirm password //
    public bool IsPasswordTheSame(string confirmPassword, string password)
    {
        if (password == confirmPassword)
        {
            return true;
        }
        else
        {
            MessageBox.Show("password does not match");
            return false;
        }
    }


    // Changes users info //
    public void UserDetailUpdate(string username, string password, Countries location, IUser currentUser)
    {
        //foreach (IUser user in users)
        //{
        //}
            
            User user = SignedInUser as User;

            SignedInUser.Username = username;
            SignedInUser.Password = password;
            SignedInUser.Location = location;

        //    user.Username = username;
        //    user.Password = password;
        //    user.Location = location;
    }
  

    // method not in use //
    public bool SignInUser(string username, string password)
    {
        foreach(IUser user in users)
        {
             
            //Checks if in the list there is a user with the username //
            if (user.Username == username && user.Password == password)
            {
                // if it exists, do this //
                
                SignedInUser = user;
                
                return true;
            }
        }
        return false;
    }

    

    public List<Travel> AllTravelsFromUser ()
    {
        return travels;
    }
    
}
