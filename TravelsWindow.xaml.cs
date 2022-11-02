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
using TravelPal.Enums;
using TravelPal.Interface;
using TravelPal.Managers;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelsWindow.xaml
    /// </summary>
    public partial class TravelsWindow : Window
    {
        // Field variable //
        UserManager userManager;

        

        Countries location;

        List<Travel> travels;

        TravelManager travelManager;

        private IUser currentUser;


        User theuser;

        
        

        public TravelsWindow(UserManager userManager, Countries Location,TravelManager travelManager, IUser user)
        {
            InitializeComponent();


           

            
            // Field variable same as the data we get from another window //
            this.location = Location;
            this.travelManager = travelManager;
            
            User theuser = userManager.SignedInUser as User;
            this.userManager = userManager;


            
            
            

            




            // Label text is the same as the Username //
            lblUsername.Content = userManager.SignedInUser.Username;

            

            foreach (Travel travel in theuser.travels)
            {
             

                ListViewItem selectitem = new ListViewItem();
                selectitem.Content = travel.GetInfo();
                selectitem.Tag = travel; 
                
                LvAddedTravels.Items.Add(selectitem);

            }
            


            // all inputs from added travel window, add to listview


            // if travelmanager is null or not //
            // NOTE! needed becuase exception will be casted //
            if (travelManager != null)
            {


              
            }
            else
            {
                

            }





        }

       


        // signs out the user by closing the window and open mainwindow again //
        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            // a Messagebox with yes or no option will pop up //
            if (MessageBox.Show("Are you sure you wanna sign out?", "Sign Out", MessageBoxButton.YesNo, MessageBoxImage.Asterisk) == MessageBoxResult.No)
            {
                //if no //
            }
            else
            {
                MainWindow mainWindow = new MainWindow(userManager,travelManager,currentUser);
                mainWindow.Show();
                
                 Close();

                //if yes //
            }
        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            //Button for opening user details window //

            UserDetailsWindow userDetailsWindow = new(userManager,location);
            userDetailsWindow.Show();
            Close();
        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            // button for opening TravelDetails Window //
            TravelDetailsWindow travelDetailsWindow = new(userManager,travelManager);
            travelDetailsWindow.Show();
            Close();

        }

        private void btnAddTravel_Click(object sender, RoutedEventArgs e)
        {
            

            AddTravelWindow addTravelWindow = new(userManager,location,currentUser,travelManager);
            addTravelWindow.Show();
            Close();
        }

        private void LvAddedTravels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void btnRemoveTravel_Click(object sender, RoutedEventArgs e)
        {
            if (LvAddedTravels.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a item to Remove", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            ListViewItem selectedItem = LvAddedTravels.SelectedItem as ListViewItem;
            travelManager.RemoveTravel(selectedItem.Tag as Travel);
            theuser.travels.Remove(selectedItem.Tag as Travel);
            LvAddedTravels.Items.RemoveAt(LvAddedTravels.SelectedIndex);
        }
    }
}
