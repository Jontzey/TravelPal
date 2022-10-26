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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RegisterWindow RegisterWindow = new RegisterWindow();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // If left mouse button is "Pressed" then Drag and move
            if (e.LeftButton == MouseButtonState.Pressed)
            
                DragMove();
            
        }

        

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            // when register button is pressed, open register window
            // When that happens Hide Mainwindow
            RegisterWindow.Show();
            Hide();

        }

        private void btnCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            // A button for closing down the program because of the design choice
            // Before shutting down give a message
            MessageBox.Show("Thanks for traveling with Travel Pals!");
            App.Current.Shutdown();
        }
    }
}
