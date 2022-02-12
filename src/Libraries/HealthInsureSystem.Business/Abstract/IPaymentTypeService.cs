
using HealthInsureSystem.Core.Utilities.Results;
using HealthInsureSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthInsureSystem.Business.Abstract
{
    public interface IPaymentTypeService
    {
        IDataResult<List<PaymentType>> GetAll();
        IDataResult<PaymentType> GetPaymentType(int id);
        IResult Add(PaymentType paymentType);
    }
}
