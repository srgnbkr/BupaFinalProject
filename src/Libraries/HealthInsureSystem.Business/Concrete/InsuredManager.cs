using HealthInsureSystem.Business.Abstract;
using HealthInsureSystem.Core.Utilities;
using HealthInsureSystem.Core.Utilities.Results;
using HealthInsureSystem.DataAccess.Abstract;
using HealthInsureSystem.Entities.Concrete;
using HealthInsureSystem.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthInsureSystem.Business.Concrete
{
    public class InsuredManager : IInsuredService
    {
        private readonly IInsuredRepository _insuredRepository;

        public InsuredManager(IInsuredRepository insuredRepository)
        {
            _insuredRepository = insuredRepository;
        }

        public IResult Add(Insured insured)
        {

            insured.BodyMassIndex = (insured.Weight) / (insured.Height * insured.Height);
            _insuredRepository.Add(insured);
            return new SuccessResult();
        }

        public IDataResult<List<Insured>> GetAll()
        {
            return new SuccessDataResult<List<Insured>>(_insuredRepository.GetAll());
        }

        public IDataResult<Insured> GetInsured(int id)
        {
            return new SuccessDataResult<Insured>(_insuredRepository.Get(i => i.Id == id));
        }

        public IDataResult<List<InsuredDetailDto>> GetInsuredDetail()
        {
            return new SuccessDataResult<List<InsuredDetailDto>>(_insuredRepository.GetİnsuredWithDetails());
        }

        public IDataResult<List<Insured>> GeyByCustomerId(int customerId)
        {
            var data = _insuredRepository.GetAll().Where(x => x.CustomerId == customerId).ToList();
            return new SuccessDataResult<List<Insured>>(data);
        }
    }
}
