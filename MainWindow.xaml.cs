using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TravelPal.Classes;
using TravelPal.Interface;
using TravelPal.Managers;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        private UserManager userManager = new();
        public List<IUser> users;

       



        public MainWindow()
        {

            InitializeComponent();

            
        }
        public MainWindow (UserManager usermanager)
        {
            InitializeComponent();
            this.userManager = usermanager;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // If left mouse button is "Pressed" then Drag and move
            if (e.LeftButton == MouseButtonState.Pressed)
            
                DragMove();
            
        }

        

      

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            
            RegisterWindow registerWindow = new(userManager);
            // when register button is pressed, open register window
            // When that happens Hide Mainwindow
            registerWindow.Show();
            

        }

        private void btnCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            // A button for closing down the program because of the design choice
            // Before shutting down give a message
            MessageBox.Show("Thanks for traveling with Travel Pals!");
            App.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //summary//
            // users get information from usermanager method //
            //
            User TheUser = new();
            users = userManager.GetAllUsers();
            
            string username = txbUsername.Text;
            string password = pBoxPassword.Password;

            bool isUserExisting = false;

            foreach (IUser user in users)
            {
                
                    if (user.Username == username && user.Password == password)
                    {
                        
                        isUserExisting = true;
                        TravelsWindow travelsWindow = new(userManager, username,password);
                        travelsWindow.Show();
                        Close();
                    }

                
                
                
            }
            if (!isUserExisting)
            {
                MessageBox.Show("No user found");
            }
        }
    }
}
