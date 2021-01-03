using ElectronicShop.Domain.Common;
using ElectronicShop.Infrastructure.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicShop.WebUI.Common.UiUtilities
{
    public class DdlHelper
    {
        public static List<SelectListItem> GetSelectListItems(List<IdNameDto> items,
    bool addAllItem, bool addPleaseSelectItem, bool nameIsValue = false)
        {
            var selectListItems = new List<SelectListItem>();

            if (items != null && items.Count > 0)
            {
                items.ForEach(i =>
                    selectListItems.Add(new SelectListItem(i.NameEn, nameIsValue ? i.NameEn : i.Id.ToString())));
            }

            if (addAllItem)
                selectListItems.Insert(0, new SelectListItem("All", Constants.AllDdlItemValue.ToString()));

            if (addPleaseSelectItem)
                selectListItems.Insert(0, new SelectListItem("Choose", ""));

            return selectListItems;
        }
    }
}
