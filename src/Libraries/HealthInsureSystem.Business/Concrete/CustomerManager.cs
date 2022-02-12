using HealthInsureSystem.Business.Abstract;
using HealthInsureSystem.Business.ValidationRules.FluentValidation;
using HealthInsureSystem.Core.Aspects.Autofac.Validation;
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
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            _customerRepository.Add(customer);
            return new SuccessResult();

        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerRepository.GetAll());
        }

       

        public IDataResult<Customer> GetCustomer(int id)
        {
            return new SuccessDataResult<Customer>(_customerRepository.Get(c => c.Id ==id));
        }
    }
}
