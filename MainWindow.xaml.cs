using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection.Metadata;
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
using TravelPal.Enums;
using TravelPal.Interface;
using TravelPal.Managers;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // field variables
        TravelManager TravelManager = new();
        UserManager userManager;
        private List<IUser> users = new();
        private IUser SignedInUser;
        

        
        // MainWindow constructor
        public MainWindow()
        {

            InitializeComponent();
            userManager = new(TravelManager);
            
        }

        // Made another constructor for when opening a new Mainwindow//
        // because could not get information from the other windows //

        public MainWindow(UserManager usermanager, TravelManager travelManager, IUser SignedInUser)
        {
            InitializeComponent();

            // Saying that the Data we recovered is the same as the field variables we created
            this.TravelManager = travelManager;
            
            this.userManager = usermanager;
            this.SignedInUser = SignedInUser;

           

            // Note! to myself //
            // is this required? //
            // when opening a new window it gets the users? //
            userManager.GetAllUsers();

            
            
        }

        // A method to make the window move //
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // If left mouse button is "Pressed" then Drag and move
            if (e.LeftButton == MouseButtonState.Pressed)
                
                // a method that exist in visual studio //
                DragMove();
            
        }

        

      
        // Button to open register window //
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            
            RegisterWindow registerWindow = new(userManager,TravelManager);
            // when register button is pressed, open register window
            // When that happens close Mainwindow
            registerWindow.Show();
           Close();

            

        }
        // button to close down the window and end the program //
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
            // this is to call the list in usermanager and say that the item in this list we will send and have those item in this list created in this cs.file //
            users = userManager.GetAllUsers();


            // the textboxes text saved in a string //
            string username = txbUsername.Text;
            string password = pBoxPassword.Password;

            bool isUserExisting = false;

            //For every user in the list //
            foreach (IUser user in users)
            {

                //Checks if in the list there is a user with the username //
                if (user.Username == username && user.Password == password)
                {
                    // if it exists, do this //
                    isUserExisting = true;
                    userManager.SignedInUser = user;
                    

                    //Open new window and send data //
                    TravelsWindow travelsWindow = new(userManager, TravelManager, SignedInUser);
                    travelsWindow.Show();
                    Close();
                }
                else if (user is UserAdmin)
                {
                    
                }



            }


            // If statement that says, if the user does not exists
            if (!isUserExisting)
            {
                MessageBox.Show("No user found");
            }
        }
    }
}
