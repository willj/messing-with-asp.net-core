using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ElephantsRepository
    {
        private IConfigurationRoot config;

        private IDbConnection connection
        {
            get
            {
                return new SqlConnection(config.GetConnectionString("DefaultConnection"));
            }
        }

        public ElephantsRepository(IConfigurationRoot config)
        {
            this.config = config;
        }

        public List<Elephant> GetElephants()
        {
            using (var db = connection)
            {
                return db.Query<Elephant>("SELECT * FROM Elephants").ToList();
            }
        }

    }
}
