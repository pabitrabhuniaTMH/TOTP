using OTPServices.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTPServices.Models
{
    public class UserOTPModel
    {
        [Required(ErrorMessage ="OTP is required")]
        [StringLength(6,MinimumLength =6,ErrorMessage = "OTP must be only SIX characters")]
        public string? OTP { get; set; }
        [Required(ErrorMessage = "UserName is required")]
        public string? UserName { get; set; }
    }
    public class OTPGenerateModel
    {
        public string? OTP { get; set; }
        public string? Email { get; set; }
        public DateTime Created { get; set; }
        public string? KEY { get; set; }
        public int Size { get; set; }
        public int Period { get; set; }
    }
    public class OTPValidateModel:BaseModel
    {
        public bool Validation { get; set; }
        public long TimeStepMatched { get; set; }
    }
}
