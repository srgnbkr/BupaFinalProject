using HealthInsureSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthInsureSystem.Entities.Concrete
{
    public class Customer : User
    {
        
        
        public string IdentityNumber { get; set; }
        public string PhoneNumber { get; set; }
        public int BirthYear { get; set; }


    }
}
