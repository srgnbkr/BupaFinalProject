using HealthInsureSystem.Business.Abstract;
using HealthInsureSystem.Business.BusinessAspects;
using HealthInsureSystem.Business.Constants;
using HealthInsureSystem.Core.Utilities.Results;
using HealthInsureSystem.DataAccess.Abstract;
using HealthInsureSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthInsureSystem.Business.Concrete
{
    public class UserManager : IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IResult Add(User user)
        {
            var result = _userRepository.Any(u => u.Email == user.Email);
            if (result)
            {
                return new ErrorResult(Messages.User.Exists(user.Email));
            }
            _userRepository.Add(user);
            return new SuccessResult(Messages.User.Add());
        }

        public IResult Delete(User user)
        {
            var result = _userRepository.Any(u => u.Id == user.Id);
            if (!result)
            {
                return new ErrorResult(Messages.NotFound());
            }
            _userRepository.Delete(user);
            return new SuccessResult(Messages.User.Delete());
        }

        //[SecuredOperation("admin,user.getall")]
        public IDataResult<List<User>> GetAll()
        {
            var result = _userRepository.Count();
            if (result == 0)
            {
                return new ErrorDataResult<List<User>>(Messages.NotFound());
            }
            return new SuccessDataResult<List<User>>(_userRepository.GetAll());
        }

        public IDataResult<User> GetByEmail(string userEmail)
        {
            var result = _userRepository.Any(u => u.Email == userEmail);
            if (!result)
            {
                return new ErrorDataResult<User>(Messages.NotFound());
            }
            return new SuccessDataResult<User>(_userRepository.Get(u => u.Email == userEmail));
        }

        public IDataResult<User> GetById(int userId)
        {
            var result = _userRepository.Any(u => u.Id == userId);
            if (!result)
            {
                return new ErrorDataResult<User>(Messages.NotFound());
            }
            return new SuccessDataResult<User>(_userRepository.Get(u => u.Id == userId));;
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var result = _userRepository.Any(u => u.Id == user.Id);
            if (!result)
            {
                return new ErrorDataResult<List<OperationClaim>>(Messages.Authorization.AuthorizationDenied());
            }
            return new SuccessDataResult<List<OperationClaim>>(_userRepository.GetClaims(user));
        }

        public IResult Update(User user)
        {
            var result = _userRepository.Any(u => u.Id == user.Id);
            if (!result)
            {
                return new ErrorResult(Messages.NotFound());
            }

            _userRepository.Update(user);
            return new SuccessResult(Messages.User.Update());
        }
    }
}
