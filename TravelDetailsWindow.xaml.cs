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
using TravelPal.Managers;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelDetailsWindow.xaml
    /// </summary>
    public partial class TravelDetailsWindow : Window
    {
        List<Travel> travels;
        UserManager userManager;
        TravelManager TravelManager;
        User user;
        Countries location;
        Travel TheTravel;
        public TravelDetailsWindow(UserManager userManager, TravelManager Travelmanager, User user, Countries location, Travel selelcted)
        {
            InitializeComponent();
            this.userManager = userManager;
            this.TravelManager = Travelmanager;
            this.user = user;
            this.location = location;
            this.TheTravel = selelcted;



            tbxDestination.Text = selelcted.Destination;
            TbxCountry.Text = selelcted.Country.ToString();
            tbxTravelers.Text = selelcted.travelers.ToString();
            

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelsWindow = new(userManager,TravelManager,user);
            travelsWindow.Show();
            Close();
        }

        private void btnChangeTravel_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sorry feature, is not implemented yet! for more information press info");
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Welcome to Info! " +
                $"As the feature to change travel details is not implemented you can delete travel in Added travels window");
        }
    }
}
