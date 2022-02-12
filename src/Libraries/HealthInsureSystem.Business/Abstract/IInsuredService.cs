using HealthInsureSystem.Core.Utilities;
using HealthInsureSystem.Core.Utilities.Results;
using HealthInsureSystem.Entities.Concrete;
using HealthInsureSystem.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthInsureSystem.Business.Abstract
{
    public interface IInsuredService
    {
        IDataResult<List<Insured>> GetAll();
        IDataResult<Insured> GetInsured(int id);
        IResult Add(Insured insured);
        IDataResult<List<Insured>> GeyByCustomerId(int customerId);

        IDataResult<List<InsuredDetailDto>> GetInsuredDetail();

        
    }
}
