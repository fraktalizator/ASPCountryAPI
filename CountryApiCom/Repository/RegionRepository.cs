using AutoMapper;
using CityApiCom.Data;
using CityApiCom.Dto;
using CityApiCom.Interfaces;
using CityApiCom.Models;

namespace CityApiCom.Repository
{
    public class RegionRepository : IRegionRepository
    {

        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public RegionRepository(DataContext dataContext, IMapper mapper)
        {
            this._dataContext = dataContext;
            this._mapper = mapper;
        }


        public bool Exists(int id)
        {
            return _dataContext.Regions.Any(region => region.Id == id);
        }

        public RegionDTO GetRegion(int id)
        {
            var region = _dataContext.Regions.Where(region => region.Id == id).FirstOrDefault();
            var regionDTO = _mapper.Map<RegionDTO>(region);
            return regionDTO;
        }

        public ICollection<RegionDTO> GetRegions()
        {
            var region = _dataContext.Regions.ToList();
            var regionDTO = _mapper.Map<List<RegionDTO>>(region);
            return regionDTO;
        }
    }
}
