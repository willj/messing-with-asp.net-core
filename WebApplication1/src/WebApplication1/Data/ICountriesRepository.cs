using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public interface ICountriesRepository
    {
        List<Country> GetCountries();
    }
}