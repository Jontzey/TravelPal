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

   


    //summary//
    // Checks if the same username exists in Username
    public bool ValidateUsername (string username)
    {
        // foreach user in the list
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
       if(ValidateUsername(username)) // Method to Validate
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
         //if the two variables matches
        if (password == confirmPassword)
        {
            return true;
        }
        else  // Show message does not match
        {
            MessageBox.Show("password does not match");
            return false;
        }
    }


    // Changes users info //
    public void UserDetailUpdate(string username, string password, Countries location, IUser currentUser)
    {
        
            // if the signed in user is a user
            // properties in signed in user is available
            User user = SignedInUser as User;
            // set the user who is logged in, and update props with data we gathered
            SignedInUser.Username = username;
            SignedInUser.Password = password;
            SignedInUser.Location = location;

        
    }
  


    /////////////////            NOTE!                    \\\\\\\\\\\\\\\\\\\\\\\
     //Method to check if user exists in IUser list
    ///////////////////// Method not in use\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
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
