using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window
    {
        TravelManager TravelManager;
        UserManager UserManager;
        IUser currentUser;
        
        
        
        Countries location;
        public AddTravelWindow(UserManager usermanager, Countries Location, IUser user,TravelManager travelManager)
        {
            InitializeComponent();
            
            this.UserManager = usermanager;
            this.TravelManager = travelManager;
            this.location = Location;
            this.currentUser = user;
            usermanager.GetAllUsers();
            var country = Enum.GetValues(typeof(Countries));



            // Put all enum in the comboboxes
            foreach(var countries in country)
            {
                cbxCountrySelection.Items.Add(countries);
            }

            var travellers = Enum.GetValues(typeof(TravelersEnum));

            foreach(var travellersEnum in travellers)
            {
                cbxTravellers.Items.Add(travellersEnum);
            }

            var TravelType = Enum.GetValues(typeof(TravelType));

            foreach(var TypeTravel in TravelType)
            {
                cbxTravelType.Items.Add(TypeTravel);
            }

            var TripType = Enum.GetValues(typeof(TripType));

            foreach (var TripTypeTravel in TripType)
            {
                cbxTripType.Items.Add(TripTypeTravel);
            }
            //
            


            
        }

        private void btnSaveTravel_Click(object sender, RoutedEventArgs e)
        {
                // try the code if something goes wrong, send exeption to catch
            try
            {
                

                // Save all inputs from user, from the add travel window
                string Destination = txbDestination.Text;
                Countries Country = (Countries)cbxCountrySelection.SelectedItem;
                var Travellers = cbxTravellers.SelectedIndex;
                var TravelType = cbxTravelType.SelectedIndex;
                var TripType = cbxTripType.SelectedIndex;

                
                
                


                if (cbxTravelType.SelectedIndex == 0)
                {



                    TripType triptype = (TripType)cbxTripType.SelectedItem;


                    Trip trip = new(triptype, Destination, Country, Travellers);

                    TravelManager.AddTravel(trip);

                    User theuser = UserManager.SignedInUser as User;
                    
                    theuser.travels.Add(trip);
                    

                }
                if (cbxTravelType.SelectedIndex == 1)
                {



                    bool allinclusive = (bool)CbAllInClusive.IsChecked;
                    Vacation vacation = new(allinclusive, Destination, Country, Travellers);

                    TravelManager.AddTravel(vacation);
                    User theuser = UserManager.SignedInUser as User;
                    theuser.travels.Add(vacation);
                    


                }

                TravelsWindow travelsWindow = new(UserManager, TravelManager,currentUser);
                travelsWindow.Show();
                Close();
            }
            // if something when wrong pop up a window with the error
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void cbxTravelType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxTravelType.SelectedIndex == (int)TravelType.Trip)
            {
                cbxTripType.Visibility = Visibility.Visible;
                lblTripType.Visibility = Visibility.Visible;

                CbAllInClusive.Visibility = Visibility.Hidden;

            }
            else if (cbxTravelType.SelectedIndex == (int)TravelType.vacation)
            {
                CbAllInClusive.Visibility = Visibility.Visible;

                cbxTripType.Visibility = Visibility.Hidden;
                lblTripType.Visibility = Visibility.Hidden;
            }
        }


        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelsWindow = new(UserManager, TravelManager,currentUser);
            travelsWindow.Show();
            Close();
        }
    }
}
