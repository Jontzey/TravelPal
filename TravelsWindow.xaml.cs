using System;
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
using TravelPal.Interface;
using TravelPal.Managers;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelsWindow.xaml
    /// </summary>
    public partial class TravelsWindow : Window
    {
        UserManager userManager;
        List<IUser> users = new();
        string username;
        string password;
        
        public TravelsWindow(UserManager userManager,string username,string password)
        {
            InitializeComponent();
            this.username = username;
            this.password = password;
            this.users = userManager.GetAllUsers();
            this.userManager = userManager;
            lblUsername.Content = username;
            

           
        }

     
        // signs out the user by closing the window and open mainwindow again //
        // Note! when a new mainwindow opens data is gone because a new manager is created//
        // potential fix? = have a log in window instead of a Mainwindow//
        // mainwindow will be open always but in the backround and will not be showing //
        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you wanna sign out?", "Sign Out", MessageBoxButton.YesNo, MessageBoxImage.Asterisk) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                MainWindow mainWindow = new MainWindow(userManager);
                mainWindow.Show();
                
                 Close();

                //do yes stuff
            }
        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            UserDetailsWindow userDetailsWindow = new(userManager,username,password);
            userDetailsWindow.Show();
            Close();
        }
    }
}
