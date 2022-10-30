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
        List<IUser> users = new();
        string username,password;
        public UserDetailsWindow(UserManager userManager,string username,string password)
        {
            InitializeComponent();
            this.UserManager = userManager;
            this.username = username;
            this.password = password;

             txbShowusername.Text = username;

            
            
           
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            // Close userdetailswindow
            // if cancel send back the info that was set from before
            TravelsWindow travelsWindow = new(UserManager,username,password);
            travelsWindow.Show();
            Close();
        }

        private void btnChangeDetails_Click(object sender, RoutedEventArgs e)
        {
            
            
            
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
                

                Close();
                username = txbUsername.Text;
                password = txbPassword.Text;

                MessageBox.Show($"Updated: Username: {username}  password: {password}");

                TravelsWindow travelsWindow = new(UserManager,username,password);
                travelsWindow.Show();
                
                
                
            }

        }
    }
}
