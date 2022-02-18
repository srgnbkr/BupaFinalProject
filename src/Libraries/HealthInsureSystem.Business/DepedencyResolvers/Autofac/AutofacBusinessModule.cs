using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using HealthInsureSystem.Business.Abstract;
using HealthInsureSystem.Business.Concrete;
using HealthInsureSystem.Core.Utilities.Interceptors;
using HealthInsureSystem.Core.Utilities.Security.JWT;
using HealthInsureSystem.DataAccess.Abstract;
using HealthInsureSystem.DataAccess.Concrete.EntityFramework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthInsureSystem.Business.DepedencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {


            // Authentication
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            // User
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<UserRepository>().As<IUserRepository>().SingleInstance();




            builder.RegisterType<PolicyManager>().As<IPolicyService>().SingleInstance(); // PolicyManager IPolicyService gibi davransın..
            builder.RegisterType<PolicyRepository>().As<IPolicyRepository>().SingleInstance();

            builder.RegisterType<PaymentManager>().As<IPaymentService>().SingleInstance();
            builder.RegisterType<PaymentRepository>().As<IPaymentRepository>().SingleInstance();

            builder.RegisterType<PaymentTypeManager>().As<IPaymentTypeService>().SingleInstance();
            builder.RegisterType<PaymentTypeRepository>().As<IPaymentTypeRepository>().SingleInstance();

            builder.RegisterType<InsuredManager>().As<IInsuredService>().SingleInstance();
            builder.RegisterType<InsuredRepository>().As<IInsuredRepository>().SingleInstance();

            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>().SingleInstance();



            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
