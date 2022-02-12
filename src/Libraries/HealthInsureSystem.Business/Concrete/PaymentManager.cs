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
    public class PaymentManager : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentManager(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public IResult Add(Payment payment)
        {
            _paymentRepository.Add(payment);
            return new SuccessResult();
        }

        public IDataResult<List<Payment>> GetAll()
        {
           
            return new SuccessDataResult<List<Payment>>(_paymentRepository.GetAll());
        }

        public IDataResult<Payment> GetPayment(int id)
        {
            return new SuccessDataResult<Payment>(_paymentRepository.Get(p => p.Id == id));
        }
    }
}
