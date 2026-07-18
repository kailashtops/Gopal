using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace InferaLayer.Data
{
    public class DBConnectionFactory
    {
        private readonly IConfiguration _config;

        public DBConnectionFactory(IConfiguration config)
        {
            _config = config;
        }

        public string CreateConnection()
        {
            return _config.GetSection("DefaultConnection").ToString();
        }
    }
}
