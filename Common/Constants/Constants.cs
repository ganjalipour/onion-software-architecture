using Consulting.Common.Utility.Extentions;

namespace Consulting.Common.Constants
{
    /// <summary>
    /// شناسه کاربران ویژه 
    /// </summary> 
    public static class ConstSpecialInfoes
    {
        /// <summary>
        /// کاربر سوپرادمین
        /// </summary>
        public const int SuperVisorAdmin = 1;

    }

    public static class ConstUserIDs
    {
        public const int Administrator = 1;
    }

    /// <summary>
    /// نوع Request 
    /// </summary> 
    public static class RequestType
    {
        public const int Post = 1;

        public const int Get = 2;
    }


    /// <summary>
    /// نوع فایل
    /// </summary>
    public static class ConstAttachmentTypes
    {
        /// <summary>
        ///  پرسنلی 
        /// </summary>
        public const int PersonImage = 1;
        /// <summary>
        ///  شناسنامه
        /// </summary>
        public const int BirthCertificateImage = 2;

        /// <summary>
        ///  کارت ملی
        /// </summary>
        public const int NationalIdImage = 3;

        /// <summary>
        ///  کارت پایان خدمت
        /// </summary>
        public const int CardService = 4;

        /// <summary>
        ///  مدرک تحصیلی
        /// </summary>
        public const int EducationDegree = 5;

        /// <summary>
        ///  گذرنامه
        /// </summary>
        public const int Passport = 6;

        public const int Signature = 7;
    }

    /// <summary>
    /// گروه فایل
    /// </summary>
    /// 
    public static class ConstAttachmentTypeCategory
    {
        /// <summary>
        /// مشتریان
        /// </summary>
        public const int Customer = 1;
        /// <summary>
        /// کاربران
        /// </summary>
        public const int User = 2;
        /// <summary>
        /// مصوبات
        /// </summary>
        public const int Session = 3;
    }


    /// <summary>
    /// فعالیت های دسترسی
    /// </summary>
    public static class ConstActivities
    {
        public const int dashboard = 1;
        public const int SecurityMenuRoot = 2;
        public const int userManagement = 3;
        public const int branchesManagement = 4;
        public const int changePassword = 5;
        public const int roleManagement = 6;
        public const int CustomerMenuRoot = 7;
        public const int CustomerManagement = 8;
        public const int WaitingPage = 9;
        public const int Sessions = 10;
        public const int MessagesManagement = 11;
        public const int SessionsManagement = 12;
        public const int ExitMenu = 13;
        public const int OrderExitMenu = 2000;
    }



    /// <summary>
    /// نوع جزئیات مشتری
    /// </summary>
    public static class ConstCustomerDetailsTypes
    {
        /// <summary>
        /// موبایل 
        /// </summary>
        public const int Mobile = 1;

        /// <summary>
        ///تلفن منزل
        /// </summary>
        public const int HomePhone = 2;

        /// <summary>
        ///تلفن محل کار
        /// </summary>
        public const int WorkPhone = 3;

        /// <summary>
        /// آدرس منزل
        /// </summary>
        public const int HomeAddress = 4;

        /// <summary>
        /// آدرس محل کار
        /// </summary>
        public const int WorkAddress = 5;

        /// <summary>
        /// عکس شناسنامه
        /// </summary>
        public const int CertificateImage = 6;

        /// <summary>
        /// عکس پرسنلی
        /// </summary>
        public const int PersonalImage = 7;

        /// <summary>
        /// عکس امضا
        /// </summary>
        public const int SignatureImage = 8;

    }
 
    /// <summary>
    /// نوع خطا
    /// </summary>
    public static class ConstErrorTypes
    {
        /// <summary>
        /// خطای سرور
        /// </summary>
        public const string ServerError = "ServerError";

        /// <summary>
        /// خطای منطقی
        /// </summary>
        public const string BussinessError = "BussinessError";

        /// <summary>
        /// خطای مدل
        /// </summary>
        public const string ModelError = "ModelError";

    }

    public static class ConstSessionState
    {
        public const int Cancellation = 1;

        public const int Held = 2;

        public const int Current = 3;

        public const int Future = 4;
    }


    /// <summary>
    /// وضعیت فعال بودن کاربر  
    /// </summary> 
    public static class ConstIsActive
    {
        /// <summary>
        /// فعال
        /// </summary>
        public const string Active = "فعال";

        /// <summary>
        /// غیر فعال
        /// </summary>
        public const string Disable = "غیر فعال";
    }

    /// <summary>
    /// نوع نقش  
    /// </summary> 
    public static class ConstRoles
    {
        /// <summary>
        /// مدیر ارشد
        /// </summary>
        public const int Admin = 1;

        /// <summary>
        /// رئیس دفتر
        /// </summary>
        public const int SuperViser = 2;

        /// <summary>
        /// مشاور
        /// </summary>
        public const int Consultant = 3;

        /// <summary>
        /// کاربر
        /// </summary>
        public const int User = 4;

        /// <summary>
        /// مشتری
        /// </summary>
        public const int Customer = 5;

    }

    /// <summary>
    /// الویت نقش  
    /// </summary> 
    public static class ConstRolesOrder
    {
        /// <summary>
        /// مدیر ارشد
        /// </summary>
        public const int Admin = 1;


        /// <summary>
        /// رئیس دفتر
        /// </summary>
        public const int Supervisor = 2;

        /// <summary>
        /// مشاور
        /// </summary>
        public const int Consultant = 3;

        /// <summary>
        /// کاربر
        /// </summary>
        public const int User = 4;

        /// <summary>
        /// مشتری
        /// </summary>
        public const int Customer = 5;

    }

    public static class ConstFaqType
    {
        public const int Question = 0;
        public const int Reply = 1;
    }


    public static class ConstMonths
    {
        [ConstDescriptor("فروردین")]
        public const int Farvardin = 1;
        [ConstDescriptor("اردیبهشت")]
        public const int Ordibehesht = 2;
        [ConstDescriptor("خرداد")]
        public const int Khordad = 3;
        [ConstDescriptor("تیر")]
        public const int Tir = 4;
        [ConstDescriptor("مرداد")]
        public const int Mordad = 5;
        [ConstDescriptor("شهریور")]
        public const int Shahrivar = 6;
        [ConstDescriptor("مهر")]
        public const int Mehr = 7;
        [ConstDescriptor("آبان")]
        public const int Aban = 8;
        [ConstDescriptor("آذر")]
        public const int Azar = 9;
        [ConstDescriptor("دی")]
        public const int Day = 10;
        [ConstDescriptor("بهمن")]
        public const int Bahman = 11;
        [ConstDescriptor("اسفند")]
        public const int Esfand = 12;
    }

}
