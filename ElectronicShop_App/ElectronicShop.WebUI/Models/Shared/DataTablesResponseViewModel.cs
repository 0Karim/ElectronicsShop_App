using System.Collections;

namespace ElectronicShop.WebUI.Models.Shared
{
    public class DataTablesResponseViewModel
    {
        public DataTablesResponseViewModel(int draw, IEnumerable data, int recordsFiltered, int recordsTotal)
        {
            this.draw = draw;
            this.data = data;
            this.recordsFiltered = recordsFiltered;
            this.recordsTotal = recordsTotal;
        }
        public int draw { get; }
        public IEnumerable data { get; }
        public int recordsTotal { get; }
        public int recordsFiltered { get; }
    }
}
