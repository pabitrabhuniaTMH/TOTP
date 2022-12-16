using Microsoft.AspNetCore.Mvc;
using Moq;
using OTPapi.Controllers;
using OTPServices.Entity;
using OTPServices.Models;
using OTPServices.ServiceHelper;
using OTPServices.Services.IRepository;

namespace TOTP.Test
{
    public class Tests
    {
        #region Test OTP Validation

        [Test]
        public void OTPValidateTest()
        {
            Mock<IOTPGenerateService> mockObject = new Mock<IOTPGenerateService>();
            var expectedValue = new ApiResponseModel
            {
                MsgHdr = new BaseResponseModel
                {
                    Id = TimeStamp.GetTimeStamp(),
                    Message = "OTP Validate Successfully",
                    Status = "SUCCESS",
                    StatusCode = 200
                },
                MsgBdy = new ResponseModel<OTPValidateModel> { Data = new OTPValidateModel { Id = 123456798, TimeStepMatched = 213456879 } }
            };
            mockObject.Setup(x => x.validateOTP(It.IsAny<UserOTPModel>())).Returns(expectedValue);
            var oTPController = new OtpController(mockObject.Object);
            var actualValue = oTPController.Validate(new UserOTPModel { UserName = "example@gmail.com", OTP = "234587" });
            OkObjectResult okObjectActualValue = actualValue as OkObjectResult;
            Assert.That(okObjectActualValue.Value, Is.EqualTo(expectedValue));
        }
        #endregion End Test

        #region Test OTP Generation
        [Test]
        public void OTPGenerateTest()
        {
            Mock<IOTPGenerateService> mockObject = new Mock<IOTPGenerateService>();
            var expectedValue = new ApiResponseModel
            {
                MsgHdr = new BaseResponseModel
                {
                    Id = TimeStamp.GetTimeStamp(),
                    Message = "OTP Generated Successfully",
                    Status = "SUCCESS",
                    StatusCode = 200
                },
                MsgBdy = new ResponseModel<OTPGenerateModel> { Data = new OTPGenerateModel { OTP = "234587" } }
            };
            mockObject.Setup(x => x.generateOTP(It.IsAny<UserDetailsModel>())).Returns(expectedValue);
            OtpController s = new OtpController(mockObject.Object);
            var actualValue = s.Generate(new UserDetailsModel { Name = "Pabitra Bhunia", Phone = "9876543210", Email = "abc@gmail.com" });
            OkObjectResult okObjectActualValue = actualValue as OkObjectResult;
            Assert.That(okObjectActualValue.Value, Is.EqualTo(expectedValue));
        }
        #endregion End Test
    }
}