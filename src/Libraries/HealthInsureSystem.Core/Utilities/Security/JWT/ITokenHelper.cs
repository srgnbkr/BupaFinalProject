using HealthInsureSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthInsureSystem.Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="operationClaims"></param>
        /// <returns></returns>
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
