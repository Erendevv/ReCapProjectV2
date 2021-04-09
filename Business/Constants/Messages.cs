using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araç başarıyla eklendi";
        public static string CarDeleted = "Araç silindi";
        public static string CarUpdated = "Araç güncellendi";
        public static string NameInvalid = "İsim geçersiz";
        public static string PriceInvalid = "Fiyat geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductsListed = "Ürünler listelendi";
        public static string BrandAdded = "Marka başarıyla eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string ColorAdded = "Renk başarıyla eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string CustomerAdded = "Müşteri başarıyla eklendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string RentalAdded = "Kiralama başarılı";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string CarImageLimit = "Daha fazla fotoğraf yükleyemezsiniz";
        public static string CarImageAdded = "Araba resmi eklendi";
        public static string CarImageUpdated = "Araba resmi güncellendi";
        public static string CarImageDeleted = "Araba resmi silindi";
        public static string CarImageCountOfCarError = "";
        public static string CarImageLimitExceeded = "";
        public static string UserRegistered = "Kayıt olundu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı zaten mevcut";
        public static string AccessTokenCreated = "Token yaratıldı";
        public static string AuthorizationDenied = "";

        public static string CarImagesDeleted = "";
        public static string CarImageNotFound;
        public static string CarImageCountExceeded;
        public static string CarListed;
        public static string RentalListed;
        public static string CarIsStillRentalled;
        public static string RentalDeleted;
        public static string RentalUpdated;
        public static string RentalUndeliveredCar;
        public static string CustomerListed;
        public static string RentalReturnDateError;
        public static string RentalGetAll;
        public static string GetRentalByRentalId;
        public static string RentalDateOk;
        public static string RentalNotDelivered;
        public static string RentedCarAlreadyExists;
        public static string Added;
        public static string Deleted;
        public static string RentalsListed;
        public static string Updated;
        public static string FindeksError = "Bu arabayı kiralayabilecek yeterli findeks puanınız yok";
        public static string FindeksSuccess = "Bu araba için yeterli findeks puanınız var";
        public static string UserListed ="Kullanıcı listelendi";
        public static string UserUpdated ="Kullanıcı güncellendi";
        public static string UserDeleted ="Kullanıcı silindi";
        public static string ColorListed;
        public static string BrandListed;
        internal static string Listed;
    }
}
