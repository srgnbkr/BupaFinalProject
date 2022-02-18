using HealthInsureSystem.Business.Abstract;
using HealthInsureSystem.Business.Constants;
using HealthInsureSystem.Core.Utilities.Results;
using HealthInsureSystem.Core.Utilities.Security.Hashing;
using HealthInsureSystem.Core.Utilities.Security.JWT;
using HealthInsureSystem.Entities.Concrete;
using HealthInsureSystem.Entities.DTOs.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthInsureSystem.Business.Concrete
{
    public class AuthManager : IAuthService
    {

        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }



        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            if (claims.Success)
            {
                var accessToken = _tokenHelper.CreateToken(user, claims.Data);
                return new SuccessDataResult<AccessToken>(accessToken, Messages.Authentication.AccessTokenCreated);
            }
            return new ErrorDataResult<AccessToken>(claims.Message);
        }


        /// <summary>
        ///  Email Adresineg
        /// </summary>
        /// <param name="userForLoginDto"></param>
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByEmail(userForLoginDto.Email);
            if (userToCheck.Data == null)
            {
                return new ErrorDataResult<User>(Messages.User.NotFound());
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.Authentication.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck.Data, Messages.Authentication.SuccessfulLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var user = new User
            {
                
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
                JoinDate = DateTime.Now
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.Authentication.UserRegistered);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByEmail(email).Data != null)
            {
                return new ErrorResult(Messages.Authentication.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
