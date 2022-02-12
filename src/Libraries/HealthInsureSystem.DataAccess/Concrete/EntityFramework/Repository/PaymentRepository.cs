using HealthInsureSystem.Core.DataAccess.Concrete;
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
    public class PaymentRepository : EfEntityRepositoryBase<Payment, InsureDbContext>, IPaymentRepository
    {
    }
}
