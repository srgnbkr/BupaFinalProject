using HealthInsureSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthInsureSystem.Entities.Concrete
{
    public class Insured : IEntity
    {
        public int Id { get; set; }
        public string InsuredFirstName { get; set; }
        public string InsuredLastName { get; set; }    
        public string IdentityNumber { get; set; }
        public int BirthYear { get; set; }
        public string Gender { get; set; }
        public string Degree { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal BodyMassIndex { get; set; }
        public bool Status { get; set; }
        public int CustomerId { get; set; }
        public int PolicyId { get; set; }
    }
}
