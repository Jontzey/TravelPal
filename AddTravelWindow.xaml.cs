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

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window
    {
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
        }
    }
}
