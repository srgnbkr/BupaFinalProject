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
    public class PaymentTypeManager : IPaymentTypeService
    {
        private readonly IPaymentTypeRepository _paymentTypeRepository;

        public PaymentTypeManager(IPaymentTypeRepository paymentTypeRepository)
        {
            _paymentTypeRepository = paymentTypeRepository;
        }

        public IResult Add(PaymentType paymentType)
        {
            _paymentTypeRepository.Add(paymentType);
            return new SuccessResult();
           
        }

        public IDataResult<List<PaymentType>> GetAll()
        {
            return new SuccessDataResult<List<PaymentType>>(_paymentTypeRepository.GetAll());
        }

        public IDataResult<PaymentType> GetPaymentType(int id)
        {
            return new SuccessDataResult<PaymentType>(_paymentTypeRepository.Get(p =>p.Id ==id)); ;
        }
    }
}
