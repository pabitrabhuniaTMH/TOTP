using OTPServices.Entity;
using OTPServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTPServices.Services.IRepository
{
    public interface IOTPGenerateService
    {
        public ApiResponseModel generateOTP(UserDetailsModel model);
        public ApiResponseModel validateOTP(UserOTPModel model);
    }
}
