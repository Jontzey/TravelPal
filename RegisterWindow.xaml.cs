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
        //making a field property//
        // connect property with called variable//
        private UserManager userManager = new();
        private List<IUser> users;
        public RegisterWindow(UserManager userManager)
        {
            InitializeComponent();

            // connected with field propert//
            this.userManager = userManager;

           

            //Summary//
            //String array to get the name in enum//
            var EuOrNot = Enum.GetNames(typeof(EUorNotEU));
            //Foreach item in the Enum add to combobox items//
            foreach(var isEu in EuOrNot)
            {
             cbxIsItEu.Items.Add(isEu);

            }





        }

       

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ///Summary///
            //If Left mousebutton is click//
            //if left is clicked and hold down//
            // Move window//
            if (e.LeftButton == MouseButtonState.Pressed)

                DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            //Summary//
            //Open a new instance of Mainwindow//
            //Close current window//
            //Open MainWindow //
            
            Close();
            
        }

                
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                
                // Create a new user
                User user = new();
                // capture the inputs from register window //
                string username = txbRegisterUsername.Text;
                string password = txtBoxRegisterPassword.Text;
                string ConfirmPassword = txtConfirmPassword.Text;

                //Countries location = (Countries)cbxCountry.SelectedItem;

                //foreach(Countries country in )


                //Validate if username exists


                if (password == ConfirmPassword)
                {
                    userManager.GetAllUsers();
                    bool userExistsOrNot = userManager.AddUser(username, password);

                    if (userExistsOrNot == true)
                    {
                        MessageBox.Show("Welcome new user!");
                        Close();
                    }
                    else if (userExistsOrNot == false)
                    {

                    }
                }
                else
                {

                    MessageBox.Show("Passwords does not match");
                }

                














            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void cbxIsItEu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Summary//
            // if Eu is choosen //
            // show all countries in Eu //
            if(cbxIsItEu.SelectedIndex == (int)EUorNotEU.EU)
            {
                cbxCountry.IsEnabled = true;
                var isEu = Enum.GetNames(typeof(EuropeanCountries));

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
                cbxCountry.IsEnabled = true;
                var isNotEu = Enum.GetNames(typeof(Countries));

                foreach (var NotEu in isNotEu)
                {
                    cbxCountry.Items.Add(NotEu);
                }
            }
        }
    }
}
