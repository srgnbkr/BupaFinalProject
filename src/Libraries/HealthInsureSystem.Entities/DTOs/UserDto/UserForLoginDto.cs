﻿using HealthInsureSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthInsureSystem.Entities.DTOs.UserDto
{
    public class UserForLoginDto :IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
