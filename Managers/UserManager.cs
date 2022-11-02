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
    List<IUser> users = new();
    List<Travel> travels;
    TravelManager TravelManager;
    public IUser SignedInUser { get; set; }

    public UserManager()
    {
        // Created a Admin 
        UserAdmin Admin = new UserAdmin()
        {
            Username = "Admin",
            Password = "Admin",
        };
        User user = new User()
        {
            Username = "Gandalf",
            Password = "Password",
            Location = Countries.Argentina,

           

        };
        users.Add(user);
        users.Add(Admin);
        GetAllUsers();
        
    }

   
    //Summary//
    //Add user with its properties//
    // this method not used!!! //
    public bool addUser(IUser user)
    {

       return false;
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
    public void UserDetailUpdate(string username, string password, Countries location)
    {
        foreach (IUser user in users)
        {
            user.Username = username;
            user.Password = password;
            user.Location = location;
        }
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
