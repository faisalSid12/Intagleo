using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intagleo.Models
{
    public class ResponseModel
    {
        public ResponseModel(bool status, string message)
        {
            this.Status = status;
            this.Message = message;
        }

        public ResponseModel(bool status, string message, string token)
        {
            this.Status = status;
            this.Message = message;
            
        }
        public ResponseModel(bool status, string message, string token, Object data)
        {
            this.Status = status;
            this.Message = message;
            this.Data = data;
        }

        public ResponseModel(bool status, string message, string token, Object data, Object data1)
        {
            this.Status = status;
            this.Message = message;
            this.Data = data;
            this.Data1 = data1;
        }


        public ResponseModel(bool status, string message, Object model)
        {
            this.Status = status;
            this.Message = message;
            this.Data = model;
        }


        public bool Status { get; set; }
        public string Message { get; set; }
        public Object Data { get; set; }
        public Object Data1 { get; set; }
    }
}
