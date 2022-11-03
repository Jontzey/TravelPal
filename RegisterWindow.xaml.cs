using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        //Summary//
        //making a field variable//
        // connect variables with called variable == this. //
        private TravelManager TravelManager;
        private UserManager userManager;
        private IUser currentUser;
        
       
        
        public RegisterWindow(UserManager userManager, TravelManager travelManager)
        {
            InitializeComponent();

            // connected with field variables//
            this.userManager = userManager;
            this.TravelManager = travelManager;
            this.userManager.GetAllUsers();
            
            

            //Summary//
            //String array to get the name in enum//
            var EuOrNot = Enum.GetValues(typeof(EUorNotEU));
            //Foreach item in the Enum add to combobox items//
            foreach(var isEu in EuOrNot)
            {
             cbxIsItEu.Items.Add(isEu);

            }
            // button is false as long condition is met //
            btnRegister.IsEnabled = false;


        }

       

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ///Summary///
            //If Left mousebutton is click//
            //if left is clicked and hold down//
            // Move window//



            /////// Do i want this implemented on this window? //////

            if (e.LeftButton == MouseButtonState.Pressed)

                DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            //Summary//
            //Open a new instance of Mainwindow//
            //Close current window//
            //Open MainWindow //
            // we send no data because we close the window instead of saving data //
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            // this closes register window
            Close();
            
        }

                
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            // Try and catch //
            // It runs the code in the parameters and if exception is casted we catch that //
            try
            {


                btnRegister.IsEnabled = false;
                



                // capture the inputs from register window //
                string username = txbRegisterUsername.Text;
                string password = txtBoxRegisterPassword.Text;
                string ConfirmPassword = txtConfirmPassword.Text;
                Countries Location = (Countries)cbxCountry.SelectedItem;

              


                // is passwords the same //

                if (password == ConfirmPassword)
                {
                    // Check if user exists //
                    bool userExistsOrNot = userManager.AddUser(username, password, Location,TravelManager);

                    // if true
                    if (userExistsOrNot == true)
                    {
                        MessageBox.Show("Welcome new user!");
                        MainWindow mainWindow = new MainWindow(userManager,TravelManager,currentUser);
                        mainWindow.Show();
                        Close();
                    }
                    // else false
                    else if (userExistsOrNot == false)
                    {

                    }
                }
                // if passwords does not match
                else
                {

                    MessageBox.Show("Passwords does not match");
                }

                














            }
            // when exception is catched //
            catch (Exception ex)
            {
                // show the error //
                MessageBox.Show(ex.Message);
            }
        }

        private void cbxIsItEu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Summary//
            // if Eu is choosen //
            // show all countries in Eu //
            if(cbxIsItEu.SelectedIndex == (int)EUorNotEU.EU)
            {
                //When something exists in the combo box, make combo box enabled //
                cbxCountry.IsEnabled = true;
                //Saves items from enum class in a variable // 
                var isEu = Enum.GetValues(typeof(EuropeanCountries));
                // Loop all items in the Enum EU countries //
                foreach (var NotEu in isEu)
                {
                    cbxCountry.Items.Add(NotEu);
                }
            }
            // Summary//
            // if Eu is not choosen //
            // show all countries //
            else if (cbxIsItEu.SelectedIndex == (int)EUorNotEU.Other)
            {
                //When something exists in the combo box, make combo box enabled //
                cbxCountry.IsEnabled = true;
                //Saves items from enum class in a variable // 
                var isNotEu = Enum.GetValues(typeof(Countries));

                // Loop all items in the Enum countries //
                foreach (var NotEu in isNotEu)
                {
                    // Add all items to combo box
                    cbxCountry.Items.Add(NotEu);
                }
            }
        }

        // When something happens to the combobox //
        private void cbxCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // When the last combo box is filled with item //
            // make button register available to press //
            btnRegister.IsEnabled = true;
        }
    }
}
