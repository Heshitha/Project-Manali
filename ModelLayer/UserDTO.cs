﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class UserDTO
    {
        public int userID { get; set; }
        public string Name { get; set; }
        public string NIC { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ImagePath { get; set; }
    }
}
