using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicShop.Infrastructure.Helpers
{
    public class Constants
    {
        public const int PageSize = 5;

        public const string SuccessMessage = "SuccessMessage";
        public const string WarningMessage = "WarningMessage";
        public const string ErrorMessage = "ErrorMessage";

        public const string FullNameClaimType = "FullName";
        public const string RoleClaimType = "Role";

        #region localization

        public static string ARCultureCode => "ar";

        public static string ENCultureCode => "en";


        public const string RTL = "RTL";
        public const string LTR = "LTR";

        #endregion
    }
}
