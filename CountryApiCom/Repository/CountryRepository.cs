using AutoMapper;
using CityApiCom.Data;
using CityApiCom.Interfaces;
using CityApiCom.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace CityApiCom.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public CountryRepository(DataContext dataContext, IMapper mapper)
        {
            this._dataContext = dataContext;
            this._mapper = mapper;
        }

        public IEnumerable<CountryDTO> GetCountry()
        {
            var country = _dataContext.Countries.Include(p => p.Region).ToList();
            foreach (var c in country) Console.WriteLine(c.Region.Name); //for testing
            var countryDTO = _mapper.Map<List<CountryDTO>>(country);
            return countryDTO;
        }

        public CountryDTO GetCountryById(int id)
        {
            var country = _dataContext.Countries.Where(p => p.Id == id).FirstOrDefault();

            var countryDTO = _mapper.Map<CountryDTO>(country);
            return countryDTO;
        }


        public IEnumerable<CountryDTO> GetCountryByRegion(string region)
        {
            var country = _dataContext.Countries.Where(p => p.Region.Equals(region)).ToList();

            var countryDTO = _mapper.Map<List<CountryDTO>>(country);
            return countryDTO;
        }
        public bool Exists(int id)
        {
            return _dataContext.Countries.Any(p => p.Id == id);
        }

        public bool AddCountry(CountryDTO countryDTO)
        {
            var country = _mapper.Map<Country>(countryDTO);
            country.Id = _dataContext.Countries.Count() + 1;
            country.Region = _dataContext.Regions.Where(p => p.Name == country.Region.Name).FirstOrDefault() ?? country.Region;

            _dataContext.Countries.Add(country);
            var res = _dataContext.SaveChanges();
            return res > 0;
        }
    }
}
