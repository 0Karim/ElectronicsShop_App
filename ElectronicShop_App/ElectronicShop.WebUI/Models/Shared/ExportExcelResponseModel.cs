using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicShop.WebUI.Models.Shared
{
    public class ExportExcelResponseModel
    {
        public int OperationStatus { get; set; }
        public string Message { get; set; }
        public string FileId { get; set; }
        public string FileName { get; set; }
    }
}
