﻿using HealthInsureSystem.Core.DataAccess.Concrete;
using HealthInsureSystem.DataAccess.Abstract;
using HealthInsureSystem.DataAccess.Concrete.EntityFramework.Context;
using HealthInsureSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthInsureSystem.DataAccess.Concrete.EntityFramework.Repository
{
    public class UserRepository : EfEntityRepositoryBase<User, InsureDbContext>, IUserRepository
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new InsureDbContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim
                             {
                                 Id = operationClaim.Id,
                                 Name = operationClaim.Name
                             };
                return result.ToList();
            }
        }
    }
}
