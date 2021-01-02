using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElectronicShop.WebUI.Models.Shared;

namespace ElectronicShop.WebUI.Common.DataTables
{
    public class DataTablesHelper
    {
        internal static string GetOrderStringFromDtParams(string defaultOrder, DtParameters dtParameters,
                        Dictionary<string,string> replacementProperties=null)
        {
            string order = defaultOrder;
            if (dtParameters.Order != null && dtParameters.Order.Length > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var dtOrder in dtParameters.Order)
                {
                    string fieldName = dtParameters.Columns[dtOrder.Column].Data;
                    if (replacementProperties != null && replacementProperties.Any(r => r.Key.ToLower() == fieldName.ToLower()))
                    {
                        fieldName = replacementProperties.First(r => r.Key.ToLower() == fieldName.ToLower()).Value;
                    }
                    sb.Append($"{fieldName} {dtOrder.Dir},");
                }

                //order = sb.ToString();
                if (order.EndsWith(","))
                {
                    order = order.Substring(0, order.Length - 1);
                }
            }

            return order;
        }
    }
}
