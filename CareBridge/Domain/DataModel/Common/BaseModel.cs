using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataModel.Common
{
    public class BaseModel
    {
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; } = string.Empty;
        public DateTime ModifiedDate { get; set; }
        public string DeletedBy { get; set; } = string.Empty;
        public DateTime DeletedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }


    }
}
