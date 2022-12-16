using DBAccess.IRepository;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Data;


namespace DBAccess.Repository
{
    public class Connection:IConnection
    {
        private readonly IConfiguration _configuration;
        private readonly string? _connectionString;
        public Connection(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        public OracleConnection connnection()
        {
            OracleConnection con = new OracleConnection(_connectionString);
            return con;
        }
        public IDbConnection idbconnnection()
        {
            var conn = new OracleConnection(_connectionString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }
    }
}
