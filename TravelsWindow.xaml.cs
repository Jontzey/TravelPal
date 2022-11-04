using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        // Field variables //
        UserManager userManager;

        List<IUser> users;

        Countries location;

        List<Travel> travels;

        TravelManager travelManager;

        private IUser currentUser;

        User theuser;

        
        

        public TravelsWindow(UserManager userManager,TravelManager travelManager, IUser TheCurrentUser)
        {
            InitializeComponent();


            // Label text is the same as the Username //
            lblUsername.Content = userManager.SignedInUser.Username;
           

            
            // Field variable same as the data we get from another window //
            
            this.travelManager = travelManager;
            this.currentUser = TheCurrentUser;
            this.userManager = userManager;
            
            // if the current user is signed in as Admin or User
            User theuser = userManager.SignedInUser as User;
            UserAdmin userAdmin = userManager.SignedInUser as UserAdmin;

            
            
            // if signedInUser is a User
            if (theuser is User)
            {
                // IF its a User make all button functions work and visiable
                    btnAddTravel.Visibility = Visibility.Visible;
                    btnAddTravel.Visibility = Visibility.Visible;
                    btnDetails.Visibility = Visibility.Visible;
                    btnUser.Visibility = Visibility.Visible;

                // Get Data and send to travel list in Travelmanager //
                // Update the list here in TravelWindow as to the list in travelmanager
                travels = travelManager.GetList();

                // foreach travel class that exists in the User
                foreach (Travel travel in theuser.travels)
                {
                    
                    // function to give the item we gonna put in Listview
                    ListViewItem selectitem = new ListViewItem();
                    
                    // Give tag as its keeps track off whats been chosen in Listview
                    selectitem.Tag = travel;
                    
                    // the content for each item we have as a User send this when added
                    selectitem.Content = travel.GetInfo();
                    
                    

                    
                    // Add to Listview list
                    LvAddedTravels.Items.Add(selectitem);

                    // send the item to btnDetails for further use in a another window
                    LvAddedTravels.SelectedItem = btnDetails;
                    


                }

            }
           else if (userAdmin is UserAdmin)
            {
                // IF its a User make all button hidden that is not needed for Adnin
                        btnAddTravel.Visibility = Visibility.Hidden;
                        btnDetails.Visibility = Visibility.Hidden;
                        btnUser.Visibility = Visibility.Hidden;
                        btnUser.Visibility = Visibility.Hidden;

                        travels = travelManager.GetList();
                

                        foreach (Travel travel in travels)
                        {

                    //ListViewItem SelectedItem = new();
                    //SelectedItem.Content = travel;
                    //SelectedItem.Tag = travel;
                            ListViewItem listViewItem = new();
                            listViewItem.Tag = travel;
                             listViewItem.Content = travel.GetInfo();
                             LvAddedTravels.Items.Add(listViewItem);
                        }
               
                
            }






        }







        // signs out the user by closing the window and open mainwindow again //
        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            // a Messagebox with yes or no option will pop up //
            if (MessageBox.Show("Are you sure you wanna sign out?", "Sign Out", MessageBoxButton.YesNo, MessageBoxImage.Asterisk) == MessageBoxResult.No)
            {
                //if no // = the button no is pressed
            }
            else
            {
                MainWindow mainWindow = new MainWindow(userManager,travelManager,currentUser);
                mainWindow.Show();
                
                 Close();

                //if yes // = the button yes is pressed
            }
        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            //Button for opening user details window //

            UserDetailsWindow userDetailsWindow = new(userManager,location,travelManager,currentUser);
            userDetailsWindow.Show();
            Close();
        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {

            if (LvAddedTravels.SelectedItems.Count == 0)
            {
                MessageBox.Show("Nothing is Selected, is there a added travel?", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            ListViewItem selectedItem = LvAddedTravels.SelectedItem as ListViewItem;
            Travel TravelSelected = selectedItem.Tag as Travel;


            // button for opening TravelDetails Window //
            TravelDetailsWindow travelDetailsWindow = new(userManager,travelManager,theuser,location,TravelSelected);
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
            User user = userManager.SignedInUser as User;
            UserAdmin userAdmin = userManager.SignedInUser as UserAdmin;


            


            if (LvAddedTravels.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a item to Remove", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            
            ListViewItem selectedItem = LvAddedTravels.SelectedItem as ListViewItem;
            Travel selectedTravel = selectedItem.Tag as Travel;
            travelManager.RemoveTravel(selectedTravel);
            
           


            users = userManager.GetAllUsers();
            foreach (IUser dauser in users)
            {
                if (dauser is User)
                {
                    User u = dauser as User;

                    if (u.travels.Contains(selectedTravel))
                    {
                        u.travels.Remove(selectedTravel);
                        LvAddedTravels.Items.RemoveAt(LvAddedTravels.SelectedIndex);
                    }
                }
            }






        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Welcome to TravelPal!\r This company");

        }
    }
}
