using HealthInsureSystem.Core.Utilities.Results;
using HealthInsureSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthInsureSystem.Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int userId);
        IDataResult<User> GetByEmail(string userEmail);
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);

       
        IDataResult<List<OperationClaim>> GetClaims(User user);
        
    }
}
