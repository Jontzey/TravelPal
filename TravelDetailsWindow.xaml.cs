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
        
        public TravelDetailsWindow(UserManager userManager, TravelManager travelmanager)
        {
            InitializeComponent();
            
            this.userManager = userManager;
            this.TravelManager = travelmanager;

            
            foreach(Travel travel in travels)
            {
               
                if (travel is Vacation)
                {
                    
                    
                    
                    lvlAllTravels.Items.Add(travel.GetInfo());
                }
                if (travel is Trip)
                {
                    
                    
                    lvlAllTravels.Items.Add(travel.GetInfo());
                }
            }


        }

       

       
    }
}
