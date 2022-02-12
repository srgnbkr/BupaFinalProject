using HealthInsureSystem.Core.DataAccess.Concrete;
using HealthInsureSystem.DataAccess.Abstract;
using HealthInsureSystem.DataAccess.Concrete.EntityFramework.Context;
using HealthInsureSystem.Entities.Concrete;
using HealthInsureSystem.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HealthInsureSystem.DataAccess.Concrete.EntityFramework.Repository
{
    public class InsuredRepository : EfEntityRepositoryBase<Insured, InsureDbContext>, IInsuredRepository
    {
        public List<InsuredDetailDto> GetİnsuredWithDetails(Expression<Func<Insured, bool>> filter = null)
        {
            using(InsureDbContext dbContext = new InsureDbContext())
            {
                var result = from i in (filter == null ? dbContext.Insureds : dbContext.Insureds.Where(filter))
                             join p in dbContext.Policies on i.PolicyId equals p.Id
                             join c in dbContext.Customers on i.CustomerId equals c.Id
                             select new InsuredDetailDto
                             {
                                 CustomerId = c.Id,
                                 FirstName = c.FirstName,
                                 LastName = c.LastName,
                                 InsuredFirstName = i.InsuredFirstName,
                                 InsuredLastName = i.InsuredLastName,
                                 IdentityNumber = i.IdentityNumber,
                                 BirthYear = i.BirthYear,
                                 Gender = i.Gender,
                                 Degree = i.Degree,
                                 Height = i.Height,
                                 Weight = i.Weight,
                                 BodyMassIndex = i.BodyMassIndex,
                                 Status = i.Status,
                                 PolicyName = p.Name,
                                 PolicyPrice = p.Price,





                             };
                return result.ToList();
            }
        }
    }
}
