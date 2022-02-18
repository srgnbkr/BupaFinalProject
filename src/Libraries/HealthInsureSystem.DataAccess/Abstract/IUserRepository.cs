using HealthInsureSystem.Core.DataAccess.Abstract;
using HealthInsureSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthInsureSystem.DataAccess.Abstract
{
    public interface IUserRepository : IEntityRepository<User>
    {


    
        List<OperationClaim> GetClaims(User user);
    }
}
