using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess.IRepository
{
    public interface IConnection
    {
        public OracleConnection connnection();
        public IDbConnection idbconnnection();
    }
}
