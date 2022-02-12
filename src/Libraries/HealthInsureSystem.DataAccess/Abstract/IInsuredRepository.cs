using HealthInsureSystem.Core.DataAccess.Abstract;
using HealthInsureSystem.Entities.Concrete;
using HealthInsureSystem.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HealthInsureSystem.DataAccess.Abstract
{
    public interface IInsuredRepository : IEntityRepository<Insured>
    {
        List<InsuredDetailDto> GetİnsuredWithDetails(Expression<Func<Insured, bool>> filter = null);
    }
}
