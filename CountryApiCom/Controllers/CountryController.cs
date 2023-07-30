using AutoMapper;
using CityApiCom.Interfaces;
using CityApiCom.Models;
using CityApiCom.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CityApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public CountryController(
            ICountryRepository cityRepository,
            IRegionRepository regionRepository,
            IMapper mapper
            ) {
            this._countryRepository = cityRepository;
            this._regionRepository = regionRepository;
            this._mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CountryDTO>))]
        public IActionResult GetCountries()
        {
            return Ok(_countryRepository.GetCountry());
        }


        [HttpGet("{id?}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CountryDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CountryDTO))]
        public IActionResult GetCountry(int id = -1)
        {
            var count = _countryRepository.GetCountry().Count();
            id = (id == -1) ? new Random().Next(0, count+1) : id;

            if (!_countryRepository.Exists(id))
                return NotFound();

            CountryDTO? country = _countryRepository.GetCountry().FirstOrDefault(p => p.Id == id);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(country);
        }

        [HttpGet("byRegion/{name}:string")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CountryDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<CountryDTO>))]
        public IActionResult GetCountryByRegion(string name)
        {
            name = name ?? "NULL";

/*            if (!_countryRepository.Exists(id)) REGION REPO IF EXISTS
                return NotFound();*/

            var country = _countryRepository.GetCountry().Where(p => p.Region.Name.Equals(name));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(country);
        }

        [HttpPost]
        public IActionResult PostCountry([FromBody] CountryDTO countryDTO)
        {
            var RegionDTO = countryDTO.Region;
            //if(!_regionRepository.Exists(RegionDTO.Id)) return BadRequest();


            var resoult = _countryRepository.AddCountry(countryDTO);

            return Ok(resoult);
        }


/*        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CountryDTO>))]
        [Route("/cities")]
        public async Task<IActionResult> GetCountry()
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            else return Ok(_countryRepository.GetCountry());
        }

        [HttpPost]
        [Route("/add")]
        public string Add()
        {
            return "Added City";
        }


        [HttpGet]
        [Route("/ragion")]
        public string GetRegion()
        {
            return "Region";
        }
        public class inp
        {
            public int id { get; set; }
            public int b { get; set; }
        }

        [HttpPost]
        [Route("/test")]
        public async Task<IActionResult> TestObjectEater([FromBody] inp i)
        {
            return Ok("object consumed");
        }*/
    }
}
