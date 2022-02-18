using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthInsureSystem.Business.Constants
{

    public static class Messages
    {

        public static string Error()
        {
            return "Bir hata oluştu";

        }
        public static string NotFound()
        {
            return "Hiç bir kayıt bulunamadı.";

        }
        public static class User
        {



            public static string Add()
            {
                return $"Kullanıcı sisteme başarı ile eklenmiştir.";

            }
            public static string Update()
            {
                return $"Kullanıcı bilgileri başarılı bir şekilde güncellenmiştir.";

            }
            public static string Delete()
            {
                return $"Kullanıcı sistemden başarılı bir şekilde silinmiştir.";

            }
            public static string Exists(string emailAddress)
            {
                return $"{emailAddress} bilgilerine sahip bir kullanıcı sistemde kayıtlıdır.";

            }
            public static string NotFound()
            {
                return "Kullanıcı bulunamadı";

            }
            public static string PasswordChange()
            {
                return $"Şifre başarılı bir şekilde değiştirildi.";
            }
        }


        public static class Authentication
        {
            public static string PasswordError = "Şifre hatalı";
            public static string SuccessfulLogin = "Sisteme giriş başarılı";
            public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
            public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
            public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";


        }

        public static class Authorization
        {
            public static string AuthorizationDenied()
            {
                return "Yetkiniz Yok.";
                
            }
        }
    }
}
