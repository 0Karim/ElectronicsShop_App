using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicShop.Infrastructure.Helpers
{
    public class Constants
    {
        public const int PageSize = 5;

        #region Messages

        public const string SuccessMessage = "SuccessMessage";
        public const string WarningMessage = "WarningMessage";
        public const string ErrorMessage = "ErrorMessage";

        #endregion

        #region Keys

        public const string AllDdlItemValue = "0";

        public const int SuccessStatus = 1;

        public const int FailStatus = 0;

        #endregion

        public const string FullNameClaimType = "FullName";
        public const string RoleClaimType = "Role";

        public const string RoleAdmin = "admin";

        #region localization

        public static string ARCultureCode => "ar";

        public static string ENCultureCode => "en";

        public const string ArabicLang = "ar";
        public const string EnLang = "en";

        public const string RTL = "RTL";
        public const string LTR = "LTR";

        #endregion
    }
}
