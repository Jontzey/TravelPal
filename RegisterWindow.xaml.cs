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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();

            var EuOrNot = Enum.GetNames(typeof(EUorNotEU));
            foreach(var isEu in EuOrNot)
            {
                cbxIsItEu.Items.Add(isEu);
            }


        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)

                DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
        MainWindow mainWindow = new MainWindow();
            Close();
            mainWindow.Show();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbxIsItEu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbxIsItEu.SelectedIndex == (int)EUorNotEU.EU)
            {
                cbxCountry.IsEnabled = true;
                var isEu = Enum.GetNames(typeof(EuropeanCountries));

                foreach (var NotEu in isEu)
                {
                    cbxCountry.Items.Add(NotEu);
                }
            }
            else if(cbxIsItEu.SelectedIndex == (int)EUorNotEU.Other)
            {
                cbxCountry.IsEnabled = true;
                var isNotEu = Enum.GetNames(typeof(Countries));

                foreach (var NotEu in isNotEu)
                {
                    cbxCountry.Items.Add(NotEu);
                }
            }
        }
    }
}
