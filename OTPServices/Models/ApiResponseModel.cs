using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTPServices.Entity
{
    public class ResponseModel<T>
    {
        public T? Data { get; set; }
    }
    public class ApiResponseModel
    {
        public object? MsgHdr { get; set; }       
        public object? MsgBdy { get; set; }
    }
    public class BaseResponseModel:BaseModel
    {
        public int StatusCode { get; set; }
        public string? Status { get; set; }
        public string? Message { get; set; }
    }
   
}
