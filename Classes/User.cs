﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TravelPal.Enums;
using TravelPal.Interface;

namespace TravelPal.Classes
{
    public class User : IUser
    {

        public string Username { get; set; }
        public string Password { get; set; }
        public Countries Location { get; set; } = new();

        List<Travel> travels = new ();

        public bool AddUser()
        {
            return true;
        }
    }
}
