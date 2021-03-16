using Core.Entities.Concrete;
using Core.Utilities.Security.JWT;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string InvalidParameters = "Geçersiz parametre girişi yapıldı.";
        public static string UpdatedMessage = "Güncelleme tamamlandı.";
        public static string MaintenanceTime = "Sistem bakımda...";

        public static string CarAddedMessage = "Araba sisteme eklendi.";
        public static string CarsListed = "Arabalar listelendi.";
        public static string CarDeletedMessage = "Araba sistemden silindi.";

        public static string BrandAdded = "Marka sisteme eklendi.";
        public static string BrandDeletedMessage = "Marka sistemden silindi.";
        public static string BrandsListed = "Markalar listelendi.";

        public static string ColorAddedMessage = "Renk sisteme eklendi.";
        public static string ColorDeletedMessage = "Renk sistemden silindi.";
        public static string ColorsListed = "Renkler listelendi.";

        public static string UserAddedMessage = "Kullanıcı sisteme eklendi.";
        public static string UserDeletedMessage = "Kullanıcı sistemden silindi.";
        public static string UsersListed = "Kullanıcılar listelendi.";

        public static string CustomerAddedMessage = "Müşteri sisteme eklendi.";
        public static string CustomerDeletedMessage = "Müşteri sistemden silindi.";
        public static string CustomersListed = "Müşteriler listelendi.";

        public static string RentalDetailListed = "Kiralama detayları listelendi.";
        public static string RentalListed = "Kiralanan arabalar listelendi.";
        public static string RentalDeleted = "Araba teslim alındı. Yeniden kiralanabilir.";
        public static string RentalNotDeleted = "Araba teslim alınmadığı için kiralanma bilgisi silinemez.";
        public static string RentalNotAdded = "Araba henüz teslim alınmadığı için kiralanamaz.";
        public static string RentalAdded = "Araba kiralanmıştır.";

        public static string ImageLimitExceded = "Bir araba için en fazla 5 adet görsel eklenebilir.";
        public static string CarImageUploaded = "Görsel sisteme eklendi.";
        public static string NotFoundImage = "Görsel bulunamadı.";
        public static string CarImageDeleted = "Görsel sistemden silindi";
        public static string CarImageUpdated = "Görsel güncellendi.";
        public static string DefaultImageMessage = "Arabaya ait görsel bulunmamaktadır";

        public static string UserRegistered = "Kullanıcı sisteme kayıt oldu.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Parola hatası!";
        public static string SuccessfulLogin = "Giriş başarılı..";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut.";
        public static string AccessTokenCreated = "Access Token başarıyla oluşturuldu.";
        public static string AccessTokenNotCreated = "Access Token oluşturulamadı.";
        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string Updated = "Güncelleme tamamlandı";

    }
}
