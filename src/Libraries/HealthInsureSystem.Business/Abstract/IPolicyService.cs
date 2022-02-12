using HealthInsureSystem.Core.Utilities;
using HealthInsureSystem.Core.Utilities.Results;
using HealthInsureSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthInsureSystem.Business.Abstract
{
    public interface IPolicyService
    {
        IDataResult<List<Policy>> GetAll();
    }
}
