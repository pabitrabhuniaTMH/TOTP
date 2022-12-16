using OTPServices.Entity;
using OTPServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTPServices.Services.IRepository
{
    public interface IDBMaster
    {
        public void OTPGenerate(UserDetailsModel userDetailsModel);
        public void verifyValidation(OTPValidateModel oTPValidateModel);
    }
}
