﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DECommerce.Models
{
    internal class User
    {
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
    }
}
