using HealthInsureSystem.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthInsureSystem.DataAccess.Concrete.EntityFramework.Context
{
    public class InsureDbContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=InsureDb;Trusted_Connection=true");
        }


        

        public DbSet<Policy> Policies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Insured> Insureds { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
    }
}
