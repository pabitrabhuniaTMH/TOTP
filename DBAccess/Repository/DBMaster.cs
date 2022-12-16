using DBAccess.IRepository;
using Oracle.ManagedDataAccess.Client;
using OTPServices.Entity;
using OTPServices.Models;
using OTPServices.Services.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess.Repository
{
    public class DBMaster : IDBMaster
    {
        private OracleConnection _con;
        public DBMaster(IConnection connection)
        {
            _con = connection.connnection();
        }
        public void OTPGenerate(UserDetailsModel userDetailsModel)
        {
            OracleCommand command = new OracleCommand();
            command.Connection = _con;
            command.CommandText = "";
        }        
        public void verifyValidation(OTPValidateModel oTPValidateModel)
        {
                                                                                                                                                                                                                  
            throw new NotImplementedException();
        }
    }
}
