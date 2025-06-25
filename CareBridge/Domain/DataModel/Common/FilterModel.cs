using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataModel.Common
{
    public class FilterModel
    {
        public int pageNumber { get; set; } = 1;
        public int pageSize { get; set; } = 10;
        public string sortColumn { get; set; } = string.Empty;
        public string sortOrder { get; set; } = string.Empty;
        public string SearchKey { get; set; } = string.Empty;
    }
}
