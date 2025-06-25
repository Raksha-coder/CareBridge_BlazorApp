using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ReponseModel
{
    public class JsonModel
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public JsonModel(string status, string message, object data)
        {
            Status = status;
            Message = message;
            Data = data;
        }
    }
}
