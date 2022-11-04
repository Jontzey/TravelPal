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

        // field variables
        UserManager UserManager;
        TravelManager TravelManager;
        IUser currentUser;
        
       
        public UserDetailsWindow(UserManager userManager, Countries location,TravelManager travelManager ,IUser theUser)
        {
            InitializeComponent();

            //summary//
            // This. = field variables are the same as the data we got from other windows //
            // by making field variables we can use them everywhere in this cs.file //

            this.UserManager = userManager;
            
            this.TravelManager = travelManager;
            this.currentUser = theUser;
            //summary //
            // Display current user //
            // the username = the textbox text

            User theuser = userManager.SignedInUser as User;
            txbShowusername.Text = userManager.SignedInUser.Username;



            // puts enum class in combo box
           var countries = Enum.GetValues(typeof(Countries));


            foreach (var country in countries)
            {
                cbxCountry.Items.Add(country);
            }


        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            // Close userdetailswindow
            // if cancel send back the info that was set from before
            TravelsWindow travelsWindow = new(UserManager,TravelManager,currentUser);
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
                string username = txbUsername.Text;
                string password = txbPassword.Text;
                Countries countries = (Countries)cbxCountry.SelectedIndex; 
                // little box to show what user updated
                MessageBox.Show($"Updated: Username: {username}  password: {password}");

                // send data to usermanage to update all data
                UserManager.UserDetailUpdate(username,password,countries,currentUser);

                //Open new window with the new data
                TravelsWindow travelsWindow = new(UserManager, TravelManager,currentUser);
                travelsWindow.Show();
                Close();
                
                
                
            }

        }
    }
}
