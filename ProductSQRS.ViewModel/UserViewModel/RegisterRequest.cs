﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSQRS.ViewModel.UserViewModel
{
    public class RegisterRequest
    {
         
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int BirdDate { get; set; }
        public string Password { get; set; }
    }
}
