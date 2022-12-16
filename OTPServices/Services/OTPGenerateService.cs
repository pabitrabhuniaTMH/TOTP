using Microsoft.Extensions.Configuration;
using OtpNet;
using OTPServices.Entity;
using OTPServices.Models;
using OTPServices.ServiceHelper;
using OTPServices.Services.IRepository;
using System.Reflection;

namespace OTPServices.Services
{
    public class OTPGenerateService: IOTPGenerateService
    {
        private const string _KEY = "SX54ZXK5SD5JSAI4FXHQ";
        private readonly int _OTPSize;
        private readonly int _OTPStep;
        private readonly TOTPLog _tOTPLog;
        private readonly long _timeStamp;
        public OTPGenerateService(IConfiguration configuration)
        {
            _timeStamp= TimeStamp.GetTimeStamp();
            _tOTPLog = new TOTPLog(_timeStamp);
            _OTPSize = Convert.ToInt32(configuration.GetSection("OTPSize").Value);
            _OTPStep = Convert.ToInt32(configuration.GetSection("OTPStep").Value);
        }

        #region OTPGeneraate
        public ApiResponseModel generateOTP(UserDetailsModel model)
        {
            try
            {
                _tOTPLog.WriteLogMessage("OTP Generate Started");
                var secret = Helper.GetLocalAddress().ToUpper()+model.Email.ToUpper()+_KEY;
                var secretKey =Helper.RemoveSpecialCharacters(secret).Substring(0,32);
                var base32Secret = Base32Encoding.ToBytes(secretKey);
                _tOTPLog.WriteLogMessage("Secret Key = " + secretKey);
                var totp = new Totp(base32Secret, mode: OtpHashMode.Sha256, step: _OTPStep, totpSize: _OTPSize);
                var result = totp.ComputeTotp();
                if (result == null) { _tOTPLog.WriteLogMessage("Generated OTP is Null"); throw new NullReferenceException("OTP will not be null"); }
                _tOTPLog.WriteLogMessage("OTP : " + result + " Valid Time : " + _OTPStep + " Sec.");
                ResponseModel<OTPGenerateModel> responseModel = new ResponseModel<OTPGenerateModel>
                {
                    Data = new OTPGenerateModel
                    {
                        Created = DateTime.Now,
                        Size = _OTPSize,
                        Period = _OTPStep,
                        Email = model.Email,
                        KEY = secretKey,
                        OTP = result
                    }
                };
                _tOTPLog.WriteLogMessage("OTP Has Been Successfully Generated");
                return new ApiResponseModel
                {
                    MsgHdr = new BaseResponseModel
                    {
                        Id = _timeStamp,
                        StatusCode = 200,
                        Status = "SUCCESS",
                        Message = "OTP Generated Successfully"
                    },
                    MsgBdy = responseModel.Data
                };
            }
            catch (Exception e)
            {
                _tOTPLog.WriteLogMessage(e.ToString());
                return new ApiResponseModel
                {
                    MsgHdr = new BaseResponseModel
                    {
                        Id = _timeStamp,
                        StatusCode = 400,
                        Status = "Failed",
                        Message = e.ToString()
                    }
                };
            }
                                    
        }
        #endregion End OTPGenerate

        #region OTPValidation
        public ApiResponseModel validateOTP(UserOTPModel model)
        {
            try
            {
                _tOTPLog.WriteLogMessage("OTP Validation Started");
                var secret = Helper.GetLocalAddress().ToUpper() + model.UserName.ToUpper() + _KEY;
                var secretKey = Helper.RemoveSpecialCharacters(secret).Substring(0, 32);
                var bytes = Base32Encoding.ToBytes(secretKey);
                var totp = new Totp(bytes, mode: OtpHashMode.Sha256, step: _OTPStep, totpSize: _OTPSize);
                bool result = totp.VerifyTotp(model.OTP, out long timeStepMatched, VerificationWindow.RfcSpecifiedNetworkDelay);
                _tOTPLog.WriteLogMessage("Validation= " + result + " TimeStepMatched= " + timeStepMatched);
                ResponseModel<OTPValidateModel> response = new ResponseModel<OTPValidateModel>
                {
                    Data = new OTPValidateModel { TimeStepMatched = timeStepMatched, Validation = result },
                };
                return new ApiResponseModel
                {
                    MsgHdr = new BaseResponseModel
                    {
                        Id = _timeStamp,
                        Message = result == true ? "OTP Validate Successfully" : "OTP Is Not Validated",
                        Status = result == true ? "SUCCESS" : "FAILED",
                        StatusCode = result == true ? 200 : 420
                    },
                    MsgBdy = response.Data
                };
            }
            catch (Exception e)
            {
                return new ApiResponseModel
                {
                    MsgHdr = new BaseResponseModel
                    {
                        Id = _timeStamp,
                        Message = e.ToString(),
                        Status ="FAILED",
                        StatusCode = 420
                    }
                };
            }
            
        }
        #endregion End OTPValidation
    }
}
