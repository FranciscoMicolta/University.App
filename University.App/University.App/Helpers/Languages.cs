using University.App.Interfaces;
using University.App.Resources;
using Xamarin.Forms;

namespace University.App.Helpers
{
    public static class Languages
    {
        static Languages()
        {
            var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }

        public static string Accept { get { return Resource.Accept; } }
        public static string Notification { get { return Resource.Notification; } }
        public static string NoInternetConnection { get { return Resource.NoInternetConnection; } }
        public static string FieldsRequired { get { return Resource.FieldsRequired; } }
        public static string RegisterSuccessfull { get { return Resource.RegisterSuccessfull; } }
        public static string TheProcessSuccessfull { get { return Resource.TheProcessSuccessfull; } }
        public static string ChangedPasswordSuccessfully { get { return Resource.ChangedPasswordSuccessfully; } }
        public static string MenuPageAbout { get { return Resource.MenuPageAbout; } }
        public static string MenuPageProfile { get { return Resource.MenuPageProfile; } }
        public static string MenuPageChangedPassword { get { return Resource.MenuPageChangedPassword; } }
        public static string MenuPageLogOut { get { return Resource.MenuPageLogOut; } }
        public static string PQRSPetition { get { return Resource.PQRSPetition; } }
        public static string PQRSComplain { get { return Resource.PQRSComplain; } }
        public static string PQRSClaim { get { return Resource.PQRSClaim; } }
        public static string PQRSSuggestion { get { return Resource.PQRSSuggestion; } }
        public static string PQRSBad { get { return Resource.PQRSBad; } }
        public static string PQRSRegular { get { return Resource.PQRSRegular; } }
        public static string PQRSWell { get { return Resource.PQRSWell; } }
        public static string PQRSAcceptable { get { return Resource.PQRSAcceptable; } }
        public static string PQRSExcellent { get { return Resource.PQRSExcellent; } }
        public static string TakePicture { get { return Resource.TakePicture; } }
        public static string FromGallery { get { return Resource.FromGallery; } }
        public static string WhereTakePhoto { get { return Resource.WhereTakePhoto; } }
        public static string Cancel { get { return Resource.Cancel; } }
    }
}
