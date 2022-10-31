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
using TravelPal.Enums;
using TravelPal.Managers;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window
    {
        TravelManager TravelManager = new();
        public AddTravelWindow()
        {
            InitializeComponent();

            var country = Enum.GetValues(typeof(Countries));
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


            
        }

        public void AddTravels()
        {
            string Destination = txbDestination.Text;
            var Country = cbxCountrySelection.SelectedValue;
            var Travellers = cbxTravellers.SelectedValue;
            var TravelType = cbxTravelType.SelectedValue;
            var TripType = cbxTripType.SelectedValue;


            TravelManager.AddTravel(Destination, (Countries)Country, (TravelersEnum) Travellers, (TravelType)TravelType, (TripType)TripType);
        }
    }
}
