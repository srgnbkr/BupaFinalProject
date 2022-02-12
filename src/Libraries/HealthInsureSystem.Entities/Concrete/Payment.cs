using HealthInsureSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthInsureSystem.Entities.Concrete
{
    public class Payment : IEntity
    {
        public int Id { get; set; }
        public string CreditCardNumber { get; set; }
        public string Cvv { get; set; }
        public decimal PaymentPrice { get; set; }
        public int CustomerId { get; set; }
        public int InsuredId { get; set; }
        public int PaymentTypeId { get; set; }

    }
}
