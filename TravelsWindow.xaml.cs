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
        // Field variable //
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
            
            User theuser = userManager.SignedInUser as User;
            UserAdmin userAdmin = userManager.SignedInUser as UserAdmin;
            this.userManager = userManager;

            
            

            if (theuser is User)
            {
                    btnAddTravel.Visibility = Visibility.Visible;
                    btnAddTravel.Visibility = Visibility.Visible;
                    btnDetails.Visibility = Visibility.Visible;
                    btnUser.Visibility = Visibility.Visible;
                foreach (Travel travel in theuser.travels)
                {
                    
                    
                    ListViewItem selectitem = new ListViewItem();
                    selectitem.Content = travel.GetCountryInfoName();
                    selectitem.Tag = travel;
                    
                    
                    

                    LvAddedTravels.Items.Add($"{theuser.Username} {""} {selectitem}");
                    
                    
                    LvAddedTravels.SelectedItem = btnDetails;
                    


                }

            }
            if (userAdmin is UserAdmin)
            {
                        btnAddTravel.Visibility = Visibility.Hidden;
                        btnDetails.Visibility = Visibility.Hidden;
                        btnUser.Visibility = Visibility.Hidden;
                        btnUser.Visibility = Visibility.Hidden;

                        travels = travelManager.GetList();
                

                        foreach (Travel travel in travels)
                        {
                            
                            ListViewItem item = new();
                            item.Content = travel
                            item.Tag = travel;
                            
                             LvAddedTravels.Items.Add(travel.GetInfo());
                        }
               
                
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

                
                Travel TravelSelected = selectedItem.Tag as Travel;
                 

                user.travels.Remove(selectedItem.Tag as Travel);
            

                 travelManager.RemoveTravel(selectedItem.Tag as Travel);


           

            LvAddedTravels.Items.RemoveAt(LvAddedTravels.SelectedIndex);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Welcome to TravelPal!\r This company");

        }
    }
}
