using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronicShop.Infrastructure.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace ElectronicShop.WebUI.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        private string _currentLang;
        public string CurrentLang => _currentLang;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            // Culture contains the information of the requested culture
            //ViewBag.RequestCulture = rqf.RequestCulture.UICulture;
            //ViewBag.LangDirection = rqf.RequestCulture.UICulture.TextInfo.IsRightToLeft ? Constants.RTL : Constants.LTR;
            ViewBag.LangDirection = Constants.LTR;
            //ViewBag.CurrentLang = _currentLang = rqf.RequestCulture.UICulture.Name.Contains(Constants.ARCultureCode) ? Constants.ARCultureCode : Constants.ENCultureCode;
            ViewBag.CurrentLang =  Constants.ENCultureCode;

            //var currentUserLoggedInRule = context.HttpContext.User.Claims.Where(c => c.Type == Constants.RoleClaimType).Select(x => x.Value).FirstOrDefault();

            base.OnActionExecuting(context);
        }
    }
}
