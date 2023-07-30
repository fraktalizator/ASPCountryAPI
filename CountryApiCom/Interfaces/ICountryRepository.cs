using CityApiCom.Models;

namespace CityApiCom.Interfaces
{
    public interface ICountryRepository
    {
        IEnumerable<CountryDTO> GetCountry();

        IEnumerable<CountryDTO> GetCountryByRegion(string region);
        CountryDTO GetCountryById(int id);

        bool AddCountry(CountryDTO country);

        bool Exists(int id);
    }
}
