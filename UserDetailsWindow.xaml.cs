using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TravelPal.Classes;
using TravelPal.Enums;
using TravelPal.Interface;
using TravelPal.Managers;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for UserDetailsWindow.xaml
    /// </summary>
    public partial class UserDetailsWindow : Window
    {
        UserManager UserManager;
        //List<IUser> users = new();
        string username,password;
        Countries location;
        public UserDetailsWindow(UserManager userManager,string username,string password, Countries location)
        {
            InitializeComponent();

            //summary//
            // This. = field variables are the same as the data we got from other windows //
            // by making field variables we can use them everywhere in this cs.file //

            this.UserManager = userManager;
            this.username = username;
            this.password = password;
            this.location = location;
            
            //summary //
            // Display current user //
            // the username = the textbox text
             txbShowusername.Text = username;

            
            
           
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            // Close userdetailswindow
            // if cancel send back the info that was set from before
            TravelsWindow travelsWindow = new(UserManager,username,password,location);
            travelsWindow.Show();
            Close();
        }

        private void btnChangeDetails_Click(object sender, RoutedEventArgs e)
        {
            
            
            // making a another string that saves the input from the empty box //
            // just to confirm if that the password input is the same as earlier input //
            string confirmPassword = txbConfirmpassword.Text;
            bool isAllGood = false;
            // As long it is false next window wont open
            if(isAllGood == false)
            {
                // username need to be more than 3 characters
                if (txbUsername.Text.Length < 3)
                {
                    MessageBox.Show("Username must be longer than 3 characters");
                    
                }
                // password need to be more than 5 characters
                if (txbPassword.Text.Length < 5)
                {
                    MessageBox.Show("Password have to be more than 5 characters");

                }
                // if password and other confirm password is not the same
                if (txbPassword.Text != txbConfirmpassword.Text)
                {
                    MessageBox.Show("Password does not match");
                }
                // If all conditions are met isAllGood true;
                if(txbUsername.Text.Length >= 3 && txbPassword.Text.Length >= 5 && txbPassword.Text == txbConfirmpassword.Text)
                {
                    isAllGood = true;
                }
            }
            // if true change username and password from the inputs and send it to new travelswindow
            if (isAllGood == true)
            {
                
                // Inputs are the same as the textbox
                username = txbUsername.Text;
                password = txbPassword.Text;
                // little box to show what user updated
                MessageBox.Show($"Updated: Username: {username}  password: {password}");

                // send data to usermanage to update all data
                UserManager.UserDetailUpdate(username,password,location);

                //Open new window with the new data
                TravelsWindow travelsWindow = new(UserManager,username,password, location);
                travelsWindow.Show();
                Close();
                
                
                
            }

        }
    }
}
