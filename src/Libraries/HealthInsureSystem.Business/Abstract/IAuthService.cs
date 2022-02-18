﻿using HealthInsureSystem.Core.Utilities.Results;
using HealthInsureSystem.Core.Utilities.Security.JWT;
using HealthInsureSystem.Entities.Concrete;
using HealthInsureSystem.Entities.DTOs.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthInsureSystem.Business.Abstract
{
    public interface IAuthService
    {
       
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
       
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        
        IResult UserExists(string email);
       
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
