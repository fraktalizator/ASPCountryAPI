using CityApiCom.Dto;
using CityApiCom.Models;

namespace CityApiCom.Interfaces
{
    public interface IRegionRepository
    {
        ICollection<RegionDTO> GetRegions();
        RegionDTO GetRegion(int id);

        bool Exists(int id);
    }
}
