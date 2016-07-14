using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class CountriesRepository : ICountriesRepository
    {
        private IConfigurationRoot config;

        private IDbConnection connection
        {
            get
            {
                return new SqlConnection(config.GetConnectionString("DefaultConnection"));
            }
        }

        public CountriesRepository(IConfigurationRoot config)
        {
            this.config = config;
        }

        public List<Country> GetCountries()
        {
            using (var db = connection)
            {
                return db.Query<Country>("SELECT * FROM Countries").ToList();
            }
        }

    }
}
