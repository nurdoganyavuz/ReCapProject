using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class AspectMessages
    {
        public static string InvalidParameters = "Geçersiz parametre girişi yapıldı.";
        public static string InvalidDailyPrice = "Günlük kiralama bedeli 0'dan büyük olmalıdır.";
        public static string InvalidPasswordLength = "Parola en az 8, en fazla 24 karakterden oluşmalıdır.";
        public static string PasswordNotInvolveUppercase = "Parola en az bir adet büyük harf (A-Z) içermelidir.";
        public static string PasswordNotInvolveLowercase = "Parola en az bir adet küçük harf (a-z) içermelidir.";
        public static string PasswordNotInvolveNumber = "Parola en az bir adet rakam (0-9) içermelidir.";
        public static string PasswordNotInvolveSpecialChar = "Parola en az bir adet özel karakter (.,?!%+-*) içermelidir.";
    }
}
