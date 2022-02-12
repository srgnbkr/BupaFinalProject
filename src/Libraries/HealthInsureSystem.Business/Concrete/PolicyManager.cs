using HealthInsureSystem.Business.Abstract;
using HealthInsureSystem.Core.Utilities;
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
    public class PolicyManager : IPolicyService
    {
        private readonly IPolicyRepository _policyRepository;

        public PolicyManager(IPolicyRepository policyRepository)
        {
            _policyRepository = policyRepository;
        }

        public IDataResult<List<Policy>> GetAll()
        {
            var result = _policyRepository.GetAll();
            return new SuccessDataResult<List<Policy>>(result,"Listelendi");
        }
    }
}
