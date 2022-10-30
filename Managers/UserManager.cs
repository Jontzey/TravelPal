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

    IUser SignedInUser { get; set; } = null;

    public UserManager()
    {
        UserAdmin Admin = new UserAdmin()
        {
            Username = "Admin",
            Password = "Admin",
        };
        users.Add(Admin);
        GetAllUsers();
        
    }

   
    //Summary//
    //Add user with its properties//

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

    public bool AddUser(string username, string password, Countries Location)
    {
       if(ValidateUsername(username))
        {
            User user = new();
            user.Username = username;
            user.Password = password;
            user.Location = Location;


            ShowUsername(username);
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

    // a method to Show Username
    // note! this method is not used anywhere
    public string ShowUsername(string username)
    {

        return $"{username}";
    }

    
}
